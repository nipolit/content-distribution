# DACM.AssetMetadataService - ASP.NET Core 2.0 Server

Service providing asset metadata

## Run

Linux/OS X:

```
sh build.sh
```

Windows:

```
build.bat
```

## Run in Docker

```
cd src/DACM.AssetMetadataService
docker build -t dacm.assetmetadataservice .
docker run -p 5000:5000 dacm.assetmetadataservice
```
