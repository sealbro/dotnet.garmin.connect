# Garmin.Connect

Unofficial dotnet garmin connect client

[![Build](https://github.com/pachman/dotnet.garmin.connect/actions/workflows/build.yml/badge.svg)](https://github.com/pachman/dotnet.garmin.connect/actions/workflows/build.yml)
[![NuGet Version](http://img.shields.io/nuget/v/Unofficial.Garmin.Connect.svg)](https://www.nuget.org/packages/Unofficial.Garmin.Connect/)
[![NuGet Downloads](http://img.shields.io/nuget/dt/Unofficial.Garmin.Connect.svg)](https://www.nuget.org/packages/Unofficial.Garmin.Connect/)

## About

This package allows you to request your device, activity and health data from your Garmin Connect account.

**WARNING!** Use the library only for personal automation without too many accounts. For other needs [request access](https://developer.garmin.com/gc-developer-program/overview/) to the developer program.

## Installation

```bash
dotnet add package Unofficial.Garmin.Connect
```

## Using

### Default authentication

```csharp
var authParameters = new BasicAuthParameters("<garmin login>", "<garmin password>");
var client = new GarminConnectClient(new GarminConnectContext(new HttpClient(), authParameters));
```

### Authentication with MFA (multi-factor auth)

```csharp
var authParameters = new BasicAuthParameters("<garmin login>", "<garmin password>");
var mfaCode = new StaticMfaCode();

var client = new GarminConnectClient(new GarminConnectContext(new HttpClient(), authParameters, mfaCode));
```

Example `IMfaCodeProvider` implementation:

```csharp
public class StaticMfaCode : IMfaCodeProvider
{
    public Task<string> GetMfaCodeAsync()
    {
        // 1. static code
        var code = "123456";

        // 2. wait for input from console
        // var code = Console.ReadLine().Trim();

        // 3. any other approach: read from file, env var, form input, etc.

        return Task.FromResult(code);
    }
}
```

### Token caching

To avoid re-authenticating on every startup, pass an `ITokenCache` implementation. The OAuth2 token is reused until it expires.

**In-memory cache** (default, cleared on restart):

```csharp
// InMemoryTokenCache is used automatically when no cache is specified
var client = new GarminConnectClient(new GarminConnectContext(new HttpClient(), authParameters, mfaCode));
```

**File cache** (persists across restarts):

```csharp
var tokenCache = new FileTokenCache("/path/to/token.json");
var client = new GarminConnectClient(
    new GarminConnectContext(new HttpClient(), authParameters, mfaCode, tokenCache));
```

**Custom cache** (Redis, database, etc.):

Implement `ITokenCache` to plug in any storage backend:

```csharp
public class RedisTokenCache : ITokenCache
{
    public async Task<OAuth2Token> GetOAuth2Token(CancellationToken cancellationToken)
    {
        // read and return token from Redis, or null if missing/expired
    }

    public async Task SetOAuth2Token(OAuth2Token token, CancellationToken cancellationToken)
    {
        // write token to Redis with TTL of token.ExpiresIn seconds
    }
}
```

## Build and publish

- build `./pack.sh`
- pack `./publish.sh`

## Tests

- set environment variables `GARMIN_LOGIN` and `GARMIN_PASSWORD`
  - JetBrains Rider: `File | Settings | Build, Execution, Deployment | Unit Testing | Test Runner`

## Thanks

- The first vision from [cyberjunky/python-garminconnect](https://github.com/cyberjunky/python-garminconnect)
- Icons made by [Freepik](https://www.freepik.com) from [www.flaticon.com](https://www.flaticon.com/)
- Converter JSON to C# [app.quicktype.io](https://app.quicktype.io/)
- and [Garmin](https://connect.garmin.com) for the best devices
