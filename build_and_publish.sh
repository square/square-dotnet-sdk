#!/usr/bin/env bash

if [ ! `git diff --name-only ${TRAVIS_COMMIT_RANGE/.../..} -- Square` ]
then
  echo -e "\033[1;32mSkip packaging because no change was made to 'Square'"
  echo -e "\033[1;32mThis could also because of missing commit caused by force push."
  exit 0
fi

echo "[INFO] Run 'dotnet' to build bin/Square.dll"
dotnet build Square/Square.csproj -o bin

if [ $? -ne 0 ]
then
  echo -e "\033[1;31m[ERROR] Compilation failed with exit code $?"
  exit 1
else
  echo -e "\033[1;32m[INFO] build bin/Square.dll was created successfully"
fi

# pack
echo "Packing for release..."
dotnet pack Square/Square.csproj -o bin

# publish when it's not a pull request and it's on master branch.
if [ "${TRAVIS_PULL_REQUEST_BRANCH}" = "" -a "${TRAVIS_BRANCH}" = "master" ];
then
  echo -e "\033[1;32mPublishing version ${packageVersion} to Nuget..."
  dotnet nuget push bin/*.nupkg -k $NUGET_APIKEY -s https://api.nuget.org/v3/index.json
else
  echo -e "\033[1;32mNot uploading pending changes until it's merged into master."
fi
