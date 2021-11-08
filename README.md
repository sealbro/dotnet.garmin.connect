# dotnet.garmin.connect

Unofficial dotnet garmin connect client

The library has been ported from [cyberjunky/python-garminconnect](https://github.com/cyberjunky/python-garminconnect)

[![NuGet Version](http://img.shields.io/nuget/v/Unofficial.Garmin.Connect.svg)](https://www.nuget.org/packages/Unofficial.Garmin.Connect/)
[![NuGet Downloads](http://img.shields.io/nuget/dt/Unofficial.Garmin.Connect.svg)](https://www.nuget.org/packages/Unofficial.Garmin.Connect/)

## About

This package allows you to request your device, activity and health data from your Garmin Connect account.
See <https://connect.garmin.com/>

## Installation

```bash
pip install garminconnect
```

## Using

```dotnet
var login = "<garmin login>";
var password = "<garmin password>";
var authParameters = new BasicAuthParameters(login, password);

var client = new GarminConnectClient(new GarminConnectContext(new HttpClient(), authParameters));
```

## Contribution

I would be grateful for any help

Current tasks:

- replace `object` field types with specialized ones
- replace the `cookie` caching mechanism with a smarter one
- replace `HttpClient` with `IHttpClientFactory`
- add `ServiceCollection` for easier use
