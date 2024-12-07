resource "kubernetes_manifest" "deployment_briefing_metadata" {
  manifest = {
    "apiVersion" = "apps/v1"
    "kind" = "Deployment"
    "metadata" = {
      "annotations" = {
        "kompose.cmd" = "kompose convert"
        "kompose.version" = "1.34.0 (HEAD)"
      }
      "labels" = {
        "io.kompose.service" = "briefing-metadata"
      }
      "name" = "briefing-metadata"
      "namespace" = "content-distribution"
    }
    "spec" = {
      "replicas" = 1
      "selector" = {
        "matchLabels" = {
          "io.kompose.service" = "briefing-metadata"
        }
      }
      "template" = {
        "metadata" = {
          "annotations" = {
            "kompose.cmd" = "kompose convert"
            "kompose.version" = "1.34.0 (HEAD)"
          }
          "labels" = {
            "io.kompose.service" = "briefing-metadata"
          }
        }
        "spec" = {
          "containers" = [
            {
              "image" = "dacm.briefingmetadataservice:latest"
              "imagePullPolicy" = "IfNotPresent"
              "name" = "briefing-metadata"
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
