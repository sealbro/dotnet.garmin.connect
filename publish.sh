#!/bin/bash

API_KEY=$1

cd ./output
ls

files=$(ls -t *.nupkg | head -1)
PACKAGE_FILE="${files[0]}"

echo "$PACKAGE_FILE"

if [ "$API_KEY" ]; then
  dotnet nuget push $PACKAGE_FILE --api-key $API_KEY --source https://api.nuget.org/v3/index.json
fi