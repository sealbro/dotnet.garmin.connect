#!/bin/bash

set -e

# Credentials are optional here: arguments override environment variables, and when
# neither is given the tests fall back to user secrets (see README).
export GARMIN_LOGIN=${1:-$GARMIN_LOGIN}
export GARMIN_PASSWORD=${2:-$GARMIN_PASSWORD}

if [ "$GARMIN_LOGIN" ] && [ "$GARMIN_PASSWORD" ]; then
  echo "Credentials detected in the environment!"
else
  echo "No credentials in the environment, falling back to user secrets."
fi

dotnet build -c Release
dotnet test --project Garmin.Connect.Tests/Garmin.Connect.Tests.csproj -c Release --no-restore
