FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

ENV DOTNET_CLI_TELEMETRY_OPTOUT 1
ENV PROJECT_DIR="BriefingMetadataService/src/DACM.BriefingMetadataService"

# copy csproj and restore as distinct layers
COPY "$PROJECT_DIR/*.csproj" ./
RUN dotnet restore

# copy everything else and build
COPY "$PROJECT_DIR" ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ADD resources/Metadata/BriefingMetadata.json /app/resources/Metadata/BriefingMetadata.json

ENV ASPNETCORE_URLS http://+:5000
ENV DOTNET_URLS=http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "DACM.BriefingMetadataService.dll"]
