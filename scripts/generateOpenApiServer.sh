#!/usr/bin/env bash

SERVICE_NAME=$1
CODEGEN_VERSION="3.0.55"
CODEGEN="swagger-codegen-cli-$CODEGEN_VERSION.jar"

if [ ! -f "$CODEGEN" ]; then
    wget "https://repo1.maven.org/maven2/io/swagger/codegen/v3/swagger-codegen-cli/$CODEGEN_VERSION/$CODEGEN"
fi

java -jar "$CODEGEN" generate -i "resources/openapi/$SERVICE_NAME/swagger.json" -l aspnetcore -o "$SERVICE_NAME" -c "resources/openapi/$SERVICE_NAME/config.json"
