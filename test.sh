#!/bin/bash

set -e

GARMIN_LOGIN=$1
GARMIN_PASSWORD=$2

if [ "$GARMIN_LOGIN" ]; then
  echo "GARMIN_LOGIN detected!"
else
  echo "GARMIN_LOGIN not detected!"
  exit 1
fi

if [ "$GARMIN_PASSWORD" ]; then
  echo "GARMIN_PASSWORD detected!"
else
  echo "GARMIN_PASSWORD not detected!"
  exit 1
fi

dotnet build -c Release
dotnet test -c Release --no-restore -e GARMIN_LOGIN=$GARMIN_LOGIN -e GARMIN_PASSWORD=$GARMIN_PASSWORD