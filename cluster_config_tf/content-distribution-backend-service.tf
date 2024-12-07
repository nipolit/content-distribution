resource "kubernetes_manifest" "service_content_distribution_backend" {
  manifest = {
    "apiVersion" = "v1"
    "kind" = "Service"
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
      "ports" = [
        {
          "name" = "5001"
          "port" = 5001
          "targetPort" = 5000
        },
      ]
      "selector" = {
        "io.kompose.service" = "content-distribution-backend"
      }
    }
  }
  depends_on = [kubernetes_manifest.namespace_content_distribution]
}
