resource "kubernetes_manifest" "service_asset_metadata" {
  manifest = {
    "apiVersion" = "v1"
    "kind" = "Service"
    "metadata" = {
      "annotations" = {
        "kompose.cmd" = "kompose convert"
        "kompose.version" = "1.34.0 (HEAD)"
      }
      "labels" = {
        "io.kompose.service" = "asset-metadata"
      }
      "name" = "asset-metadata"
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
        "io.kompose.service" = "asset-metadata"
      }
    }
  }
  depends_on = [kubernetes_manifest.namespace_content_distribution]
}
