#!/bin/bash

check_minikube_status() {
    echo "Checking minikube status..."
    minikube status
    if [ $? -ne 0 ];
    then
        echo "Please start minikube. Exiting."
        exit 1;
    fi
}

build_if_not_exists() {
    echo "Checking if docker image $1 exists..."
    if [ -z "$(docker images -q $1:latest 2> /dev/null)" ]; then
        echo "Docker image $1:latest does not exist. Building from Dockerfile $2"
        docker build . -f "$2" -t "$1:latest"
    fi
}

check_minikube_status

dockerImageNameAndDockerfiles=("dacm.assetmetadataservice AssetMetadataService/src/DACM.AssetMetadataService/Dockerfile")
dockerImageNameAndDockerfiles+=("dacm.briefingmetadataservice BriefingMetadataService/src/DACM.BriefingMetadataService/Dockerfile")
dockerImageNameAndDockerfiles+=("dacm.contentdistributionbackend ContentDistributionBackend/src/DACM.ContentDistribution/Dockerfile")

for dockerImageNameAndDockerfile in "${dockerImageNameAndDockerfiles[@]}"; do
    set -- $dockerImageNameAndDockerfile # Convert the "tuple" into the param args $1 $2

    dockerImageName="$1"
    dockerfile="$2"

    build_if_not_exists "$dockerImageName" "$dockerfile"

    minikube image load "$dockerImageName:latest" --overwrite=false
done

kubectl apply -f cluster_config/content-distribution-namespace.yaml
kubectl apply -f cluster_config --namespace=content-distribution
