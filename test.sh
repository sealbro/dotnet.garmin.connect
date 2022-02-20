#!/bin/bash

GARMIN_LOGIN=$1
GARMIN_PASSWORD=$2

if [ "$GARMIN_LOGIN" ]; then
  echo "GARMIN_LOGIN detected!"
fi

if [ "$GARMIN_PASSWORD" ]; then
  echo "GARMIN_PASSWORD detected!"
fi

export GARMIN_LOGIN=$GARMIN_LOGIN
export GARMIN_PASSWORD=$GARMIN_PASSWORD

dotnet build -c Release
dotnet test -c Release --no-restore 