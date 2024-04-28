workspace "Digital Asset Distribution System" "A platform that enables content from the creatives to be made available to consumers via other digital platforms" {

    !identifiers hierarchical

    model {
        consumer = person "Consumer" "A user of one of the digital platforms."
        digitalPlatform = softwareSystem "A Digital Platform" {
            tags "Platform"
        }

        digitalAssetDistributionSystem = softwareSystem "Digital Asset Distribution System" {
            tags "Platform" "DigitalAssetDistributionSystem"
            contentDistributionBackend = container "Content Distribution Backend" "Aggregates data about assets into AssetDistributionMetadata. Groups data about assets in the same order as ContentDistributionMetadata." {
                tags "Service"
                defaultApiController = component "DefaultApiController" "A thin Rest controller." {
                    tags "Class"
                    digitalPlatform -> this "Requests AssetDistributionMetadata for ordered assets from"
                }
                contentDistributionMetadataService = component "ContentDistributionMetadataService" "Processes orders, creates ContentDistributionMetadata." {
                    tags "Class"
                }
                cachingAssetDistributionMetadataService = component "CachingAssetDistributionMetadataService" "A caching wrapper for RestAssetDistributionMetadataService." {
                    tags "Class"
                }
                restAssetDistributionMetadataService = component "RestAssetDistributionMetadataService" "Aggregates data about assets into AssetDistributionMetadata" {
                    tags "Class"
                }

                defaultApiController -> contentDistributionMetadataService "Gets ContentDistributionMetadata from" {
                    tags "Class"
                }
                contentDistributionMetadataService -> cachingAssetDistributionMetadataService "Gets AssetDistributionMetadata from" {
                    tags "Class"
                }
                cachingAssetDistributionMetadataService -> restAssetDistributionMetadataService "Delegates to" {
                    tags "Class"
                }
            }
            assetMetadataService = container "Asset Metadata Service" {
                tags "Service"
            }
            briefingMetadataService = container "Briefing Metadata Service" {
                tags "Service"
            }
            redis = container "Redis" "AssetDistributionMetadata cache" {
                tags "Database" "Redis"
            }
            contentDistributionBackend.restAssetDistributionMetadataService -> assetMetadataService "Gets AssetMetadata from"
            contentDistributionBackend.restAssetDistributionMetadataService -> briefingMetadataService "Gets BriefingMetadata from"
            contentDistributionBackend.cachingAssetDistributionMetadataService -> redis "Caches AssetDistributionMetadata in"
        }

        consumer -> digitalPlatform "Gets digital content using"
    }

    views {
        systemContext digitalPlatform "System_context" {
            include *
            autolayout lr
        }

        container digitalAssetDistributionSystem "Digital_Asset_Distribution_System" {
            include *
            autolayout lr
        }

        component digitalAssetDistributionSystem.contentDistributionBackend "Components_ContentDistributionBackend" {
            include *
            autolayout lr
        }

        styles {
            element "Person" {
                shape Person
            }
            element "Platform" {
                shape RoundedBox
            }
            element "Service" {
                shape Hexagon
                background #8CD0F0
            }
            element "Database" {
                shape Cylinder
            }
            element "Class" {
                shape Box
                background #8CD0C0
            }
            element "Redis" {
                background #BB1010
            }
            element "DigitalAssetDistributionSystem" {
                background #5AD075
            }
        }
    }
}