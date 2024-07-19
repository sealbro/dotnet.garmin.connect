#!/bin/bash

set -e

NUGET_API_KEY=$1

echo "Here you see *.nupkg files:"
cd ./output
ls

files=$(ls -t *.nupkg | head -1)
PACKAGE_FILE="${files[0]}"

echo "Chosen [$PACKAGE_FILE] to push"

if [ "$NUGET_API_KEY" ]; then
  dotnet nuget push $PACKAGE_FILE --api-key $NUGET_API_KEY --source https://api.nuget.org/v3/index.json
  exit 0
else
  echo "NUGET_API_KEY was not set!"
  exit 1
fi