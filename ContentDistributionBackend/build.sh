#!/usr/bin/env bash
#
# Generated by: https://github.com/swagger-api/swagger-codegen.git
#

dotnet restore src/DACM.ContentDistribution/ && \
    dotnet build src/DACM.ContentDistribution/ && \
    echo "Now, run the following to start the project: dotnet run -p src/DACM.ContentDistribution/DACM.ContentDistribution.csproj --launch-profile web"