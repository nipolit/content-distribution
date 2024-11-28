resource "kubernetes_manifest" "ingress_content_distribution_backend" {
  manifest = {
    "apiVersion" = "networking.k8s.io/v1"
    "kind" = "Ingress"
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
    }
    "spec" = {
      "rules" = [
        {
          "host" = "content-distribution-backend.example"
          "http" = {
            "paths" = [
              {
                "backend" = {
                  "service" = {
                    "name" = "content-distribution-backend"
                    "port" = {
                      "number" = 5001
                    }
                  }
                }
                "path" = "/"
                "pathType" = "Prefix"
              },
            ]
          }
        },
      ]
    }
  }
}
