# DACM.ContentDistribution - ASP.NET Core 2.0 Server

Service providing content distribution metadata for ordered digital assets

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
cd src/DACM.ContentDistribution
docker build -t dacm.contentdistribution .
docker run -p 5000:5000 dacm.contentdistribution
```
