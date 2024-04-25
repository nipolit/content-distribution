# DACM.BriefingMetadataService - ASP.NET Core 2.0 Server

Service providing briefing metadata

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
cd src/DACM.BriefingMetadataService
docker build -t dacm.briefingmetadataservice .
docker run -p 5000:5000 dacm.briefingmetadataservice
```
