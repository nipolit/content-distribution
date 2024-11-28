resource "kubernetes_manifest" "namespace_content_distribution" {
  manifest = {
    "apiVersion" = "v1"
    "kind" = "Namespace"
    "metadata" = {
      "labels" = {
        "name" = "content-distribution"
      }
      "name" = "content-distribution"
    }
  }
}
