#!/usr/bin/env bash
#
# Generated by: https://github.com/swagger-api/swagger-codegen.git
#

dotnet restore src/DACM.AssetMetadataService/ && \
    dotnet build src/DACM.AssetMetadataService/ && \
    echo "Now, run the following to start the project: dotnet run -p src/DACM.AssetMetadataService/DACM.AssetMetadataService.csproj --launch-profile web"
