using System;
using Microsoft.Extensions.Configuration;

namespace Garmin.Connect.Tests;

/// <summary>
/// Resolves test settings from process environment variables, falling back to user secrets.
/// IDE test runners (Rider/VS) start the test host without the shell environment, and user
/// secrets live outside the repository, so credentials never sit in the working tree.
/// </summary>
public static class TestEnvironment
{
    private static readonly Lazy<IConfiguration> UserSecrets = new(() => new ConfigurationBuilder()
        .AddUserSecrets(System.Reflection.Assembly.GetExecutingAssembly(), optional: true)
        .Build());

    public static string? Get(string name)
    {
        var value = Environment.GetEnvironmentVariable(name);

        return string.IsNullOrEmpty(value) ? UserSecrets.Value[name] : value;
    }

    public static string GetRequired(string name) =>
        Get(name) ?? throw new InvalidOperationException(
            $"'{name}' is not set. Export it as an environment variable, or run: " +
            $"dotnet user-secrets set {name} <value> --project Garmin.Connect.Tests");
}
