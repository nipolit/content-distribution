resource "kubernetes_manifest" "service_redis" {
  manifest = {
    "apiVersion" = "v1"
    "kind" = "Service"
    "metadata" = {
      "annotations" = {
        "kompose.cmd" = "kompose convert"
        "kompose.version" = "1.34.0 (HEAD)"
      }
      "labels" = {
        "io.kompose.service" = "redis"
      }
      "name" = "redis"
      "namespace" = "content-distribution"
    }
    "spec" = {
      "ports" = [
        {
          "name" = "6379"
          "port" = 6379
          "targetPort" = 6379
        },
      ]
      "selector" = {
        "io.kompose.service" = "redis"
      }
    }
  }
}
