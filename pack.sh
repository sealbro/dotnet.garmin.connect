#!/bin/bash

PACKAGE_VERSION=$1
VERSION_SUFFIX=$2

if [ "$PACKAGE_VERSION" ]; then
  echo "PACKAGE_VERSION=$PACKAGE_VERSION"
  PACKAGE_VERSION="-p:PackageVersion=$PACKAGE_VERSION"
fi

if [ "$VERSION_SUFFIX" ]; then
  echo "VERSION_SUFFIX=$VERSION_SUFFIX"
  VERSION_SUFFIX="--version-suffix $VERSION_SUFFIX"
fi

# rm -rf ./output

cd ./Garmin.Connect

dotnet build -c Release
dotnet pack -c Release --no-restore -o ../output $PACKAGE_VERSION $VERSION_SUFFIX