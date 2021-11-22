# Garmin.Connect

Unofficial dotnet garmin connect client

The library has been ported from [cyberjunky/python-garminconnect](https://github.com/cyberjunky/python-garminconnect)

[![Build](https://github.com/pachman/dotnet.garmin.connect/actions/workflows/build.yml/badge.svg)](https://github.com/pachman/dotnet.garmin.connect/actions/workflows/build.yml)
[![NuGet Version](http://img.shields.io/nuget/v/Unofficial.Garmin.Connect.svg)](https://www.nuget.org/packages/Unofficial.Garmin.Connect/)
[![NuGet Downloads](http://img.shields.io/nuget/dt/Unofficial.Garmin.Connect.svg)](https://www.nuget.org/packages/Unofficial.Garmin.Connect/)

## About

This package allows you to request your device, activity and health data from your Garmin Connect account.

See <https://connect.garmin.com/>

## Installation

```bash
dotnet add package Unofficial.Garmin.Connect
```

## Using

```dotnet
var login = "<garmin login>";
var password = "<garmin password>";
var authParameters = new BasicAuthParameters(login, password);

var client = new GarminConnectClient(new GarminConnectContext(new HttpClient(), authParameters));
```

## Build and publish

- build `./pack.sh`
- pack `./publish.sh`

## Tests

- set enviroment variables `GARMIN_LOGIN` and `GARMIN_PASSWORD`
  - JB Rider `File | Settings | Build, Execution, Deployment | Unit Testing | Test Runner`

## Thanks

- Icons made by [Freepik](https://www.freepik.com) from [www.flaticon.com](https://www.flaticon.com/)
- VS Code plugin [Paste JSON as Code](https://marketplace.visualstudio.com/items?itemName=quicktype.quicktype)
- JetBrains Rider [EAP](https://www.jetbrains.com/rider/nextversion/)
- and [Garmin](https://connect.garmin.com) for the best devices
