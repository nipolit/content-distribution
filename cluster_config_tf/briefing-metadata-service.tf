resource "kubernetes_manifest" "service_briefing_metadata" {
  manifest = {
    "apiVersion" = "v1"
    "kind" = "Service"
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
      "ports" = [
        {
          "name" = "5000"
          "port" = 5000
          "targetPort" = 5000
        },
      ]
      "selector" = {
        "io.kompose.service" = "briefing-metadata"
      }
    }
  }
}
