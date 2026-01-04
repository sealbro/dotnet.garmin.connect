using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Garmin.Connect.Auth;
using Garmin.Connect.Auth.External;
using Garmin.Connect.Converters;
using Garmin.Connect.Exceptions;
using Garmin.Connect.Models;

namespace Garmin.Connect;

public class GarminConnectContext
{
    private readonly HttpClient _httpClient;
    private readonly IAuthParameters _authParameters;
    private OAuth2Token _oAuth2Token;

    private const int Attempts = 3;
    private const int DelayAfterFailAuth = 300;
    private readonly GarminAuthenticationService _garminAuthenticationService;

    public GarminConnectContext(HttpClient httpClient, IAuthParameters authParameters)
        : this(httpClient, authParameters, new NotImplementedMfaCode())
    {
    }

    public GarminConnectContext(HttpClient httpClient, IAuthParameters authParameters, IMfaCodeProvider userMfaService)
    {
        _httpClient = httpClient;
        _authParameters = authParameters;
        _garminAuthenticationService = new GarminAuthenticationService(_httpClient, authParameters, userMfaService);
    }

    public async Task ReLoginIfExpired(bool force = false, CancellationToken cancellationToken = default)
    {
        if (force || _oAuth2Token is null)
        {
            var oAuth2Token = await _garminAuthenticationService.RefreshGarminAuthenticationAsync(cancellationToken);

            _oAuth2Token = oAuth2Token;
        }
    }

    internal GarminSocialProfile Profile { get; set; }

    public async Task<T> GetAndDeserialize<T>(string url, CancellationToken cancellationToken = default)
    {
        var response = await MakeHttpGet(url, cancellationToken: cancellationToken);
        if (response.StatusCode == HttpStatusCode.NoContent)
        {
            return default;
        }

        var json = await response.Content.ReadAsByteArrayAsync(cancellationToken);
#if DEBUG
        try
        {
            return GarminSerializer.To<T>(json);
        }
        catch (FormatException ex)
        {
            throw new FormatException($"Error deserializing JSON for {url}:\n{System.Text.Encoding.UTF8.GetString(json)}", ex);
        }
#else
        return GarminSerializer.To<T>(json);
#endif
    }

    public Task<HttpResponseMessage> MakeHttpGet(string url,
        IReadOnlyDictionary<string, string> headers = null, CancellationToken cancellationToken = default) =>
        MakeHttpRequest(url, HttpMethod.Get, headers, null, cancellationToken);

    public Task<HttpResponseMessage> MakeHttpPut<TBody>(string url, TBody body,
        IReadOnlyDictionary<string, string> headers = null, CancellationToken cancellationToken = default) =>
        MakeHttpRequest(url, HttpMethod.Put, headers, JsonContent.Create(body), cancellationToken);

    public Task<HttpResponseMessage> MakeHttpPost<TBody>(string url, TBody body,
        IReadOnlyDictionary<string, string> headers = null, CancellationToken cancellationToken = default) =>
        MakeHttpRequest(url, HttpMethod.Post, headers, JsonContent.Create(body), cancellationToken);

    public Task<HttpResponseMessage> MakeHttpDelete(string url,
        IReadOnlyDictionary<string, string> headers = null, CancellationToken cancellationToken = default) =>
        MakeHttpRequest(url, HttpMethod.Delete, headers, null, cancellationToken);

    internal async Task<HttpResponseMessage> MakeHttpRequest(string url, HttpMethod method,
        IReadOnlyDictionary<string, string> headers, HttpContent content, CancellationToken cancellationToken)
    {
        var force = false;
        Exception exception = null;

        for (var i = 0; i < Attempts; i++)
        {
            try
            {
                await ReLoginIfExpired(force, cancellationToken);

                var requestUri = new Uri($"{_authParameters.BaseUrl}{url}");
                var httpRequestMessage = new HttpRequestMessage(method, requestUri);

                if (headers != null)
                {
                    foreach (var (key, value) in headers)
                    {
                        httpRequestMessage.Headers.Add(key, value);
                    }
                }

                httpRequestMessage.Headers.Add("cookie", _authParameters.Cookies);
                httpRequestMessage.Headers.Add("authorization", $"Bearer {_oAuth2Token.Access_Token}");
                httpRequestMessage.Headers.Add("di-backend", "connectapi.garmin.com");
                httpRequestMessage.Content = content;

                var response = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);

                await RaiseForStatus(response, cancellationToken);

                return response;
            }
            catch (GarminConnectRequestException ex)
            {
                exception = ex;
                if (ex.Status is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden)
                {
                    await Task.Delay(DelayAfterFailAuth, cancellationToken);
                    force = true;
                    continue;
                }

                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        throw new GarminConnectAuthenticationException($"Authentication fail after {Attempts} attempts", exception);
    }

    private static async Task RaiseForStatus(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.TooManyRequests:
                throw new GarminConnectTooManyRequestsException();
            case HttpStatusCode.NoContent:
            case HttpStatusCode.OK:
                return;
            default:
                {
                    var message = $"{response.RequestMessage?.Method.Method}: {response.RequestMessage?.RequestUri}";
#if DEBUG
                    var content = await response.Content.ReadAsStringAsync(cancellationToken);
                    message += $"\n{content}";
#else
                    await Task.CompletedTask;
#endif
                    throw new GarminConnectRequestException(message, response.StatusCode);
                }
        }
    }
}