resource "kubernetes_manifest" "deployment_content_distribution_backend" {
  manifest = {
    "apiVersion" = "apps/v1"
    "kind" = "Deployment"
    "metadata" = {
      "annotations" = {
        "kompose.cmd" = "kompose convert"
        "kompose.service.expose" = "true"
        "kompose.version" = "1.34.0 (HEAD)"
      }
      "labels" = {
        "io.kompose.service" = "content-distribution-backend"
      }
      "name" = "content-distribution-backend"
      "namespace" = "content-distribution"
    }
    "spec" = {
      "replicas" = 1
      "selector" = {
        "matchLabels" = {
          "io.kompose.service" = "content-distribution-backend"
        }
      }
      "template" = {
        "metadata" = {
          "annotations" = {
            "kompose.cmd" = "kompose convert"
            "kompose.service.expose" = "true"
            "kompose.version" = "1.34.0 (HEAD)"
          }
          "labels" = {
            "io.kompose.service" = "content-distribution-backend"
          }
        }
        "spec" = {
          "containers" = [
            {
              "image" = "dacm.contentdistributionbackend:latest"
              "imagePullPolicy" = "IfNotPresent"
              "name" = "content-distribution-backend"
              "ports" = [
                {
                  "containerPort" = 5000
                  "protocol" = "TCP"
                },
              ]
            },
          ]
          "restartPolicy" = "Always"
        }
      }
    }
  }
}
