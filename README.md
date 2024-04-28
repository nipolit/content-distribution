# content-distribution

## Build and run

Linux:
```shell
docker-compose up && docker-compose rm -fsv
```

MacOS:
```shell
docker-compose up || docker-compose rm -fsv
```

Example request:
```shell
curl http://localhost:5000/orderlist --json '{"orderNumber": "ORD123456789","customerName": "John Doe","orderDate": "2023-07-13","totalAssets": 10,"assets": [{"assetId": "ASSET001","quantity": 2},{"assetId": "ASSET002","quantity": 1},{"assetId": "ASSET003","quantity": 3},{"assetId": "ASSET004","quantity": 1},{"assetId": "ASSET005","quantity": 2},{"assetId": "ASSET006","quantity": 1},{"assetId": "ASSET007","quantity": 1},{"assetId": "ASSET008","quantity": 1},{"assetId": "ASSET009","quantity": 1},{"assetId": "ASSET010","quantity": 2}]}'
```

## Software diagrams
Software diagrams are using the C4 model approach.
The architecture was defined using a Structurizr DSL, see file [structurizr.dsl](structurizr.dsl).
Then the views showing the system on different levels were exported as mermaid code and included below.

### System Context Diagram

```mermaid
graph LR
  linkStyle default fill:#ffffff

  subgraph diagram ["A Digital Platform - System Context"]
    style diagram fill:#ffffff,stroke:#ffffff

    1["<div style='font-weight: bold'>Consumer</div><div style='font-size: 70%; margin-top: 0px'>[Person]</div><div style='font-size: 80%; margin-top:10px'>A user of one of the digital<br />platforms.</div>"]
    style 1 fill:#dddddd,stroke:#9a9a9a,color:#000000
    2("<div style='font-weight: bold'>A Digital Platform</div><div style='font-size: 70%; margin-top: 0px'>[Software System]</div>")
    style 2 fill:#dddddd,stroke:#9a9a9a,color:#000000
    3("<div style='font-weight: bold'>Digital Asset Distribution System</div><div style='font-size: 70%; margin-top: 0px'>[Software System]</div>")
    style 3 fill:#5ad075,stroke:#3e9151,color:#000000

    1-. "<div>Gets digital content using</div><div style='font-size: 70%'></div>" .->2
    2-. "<div>Requests<br />AssetDistributionMetadata for<br />ordered assets from</div><div style='font-size: 70%'></div>" .->3
  end
```

### Container Diagram

```mermaid
graph LR
  linkStyle default fill:#ffffff

  subgraph diagram ["Digital Asset Distribution System - Containers"]
    style diagram fill:#ffffff,stroke:#ffffff

    2("<div style='font-weight: bold'>A Digital Platform</div><div style='font-size: 70%; margin-top: 0px'>[Software System]</div>")
    style 2 fill:#dddddd,stroke:#9a9a9a,color:#000000

    subgraph 3 [Digital Asset Distribution System]
      style 3 fill:#ffffff,stroke:#3e9151,color:#3e9151

      15["<div style='font-weight: bold'>Asset Metadata Service</div><div style='font-size: 70%; margin-top: 0px'>[Container]</div>"]
      style 15 fill:#8cd0f0,stroke:#6291a8,color:#000000
      16["<div style='font-weight: bold'>Briefing Metadata Service</div><div style='font-size: 70%; margin-top: 0px'>[Container]</div>"]
      style 16 fill:#8cd0f0,stroke:#6291a8,color:#000000
      17[("<div style='font-weight: bold'>Redis</div><div style='font-size: 70%; margin-top: 0px'>[Container]</div><div style='font-size: 80%; margin-top:10px'>AssetDistributionMetadata<br />cache</div>")]
      style 17 fill:#bb1010,stroke:#820b0b,color:#000000
      4["<div style='font-weight: bold'>Content Distribution Backend</div><div style='font-size: 70%; margin-top: 0px'>[Container]</div><div style='font-size: 80%; margin-top:10px'>Aggregates data about assets<br />into<br />AssetDistributionMetadata.<br />Groups data about assets in<br />the same order as<br />ContentDistributionMetadata.</div>"]
      style 4 fill:#8cd0f0,stroke:#6291a8,color:#000000
    end

    4-. "<div>Gets AssetMetadata from</div><div style='font-size: 70%'></div>" .->15
    4-. "<div>Gets BriefingMetadata from</div><div style='font-size: 70%'></div>" .->16
    4-. "<div>Caches<br />AssetDistributionMetadata in</div><div style='font-size: 70%'></div>" .->17
    2-. "<div>Requests<br />AssetDistributionMetadata for<br />ordered assets from</div><div style='font-size: 70%'></div>" .->4
  end
```

### Component Diagram

```mermaid
graph LR
  linkStyle default fill:#ffffff

  subgraph diagram ["Digital Asset Distribution System - Content Distribution Backend - Components"]
    style diagram fill:#ffffff,stroke:#ffffff

    2("<div style='font-weight: bold'>A Digital Platform</div><div style='font-size: 70%; margin-top: 0px'>[Software System]</div>")
    style 2 fill:#dddddd,stroke:#9a9a9a,color:#000000
    15["<div style='font-weight: bold'>Asset Metadata Service</div><div style='font-size: 70%; margin-top: 0px'>[Container]</div>"]
    style 15 fill:#8cd0f0,stroke:#6291a8,color:#000000
    16["<div style='font-weight: bold'>Briefing Metadata Service</div><div style='font-size: 70%; margin-top: 0px'>[Container]</div>"]
    style 16 fill:#8cd0f0,stroke:#6291a8,color:#000000
    17[("<div style='font-weight: bold'>Redis</div><div style='font-size: 70%; margin-top: 0px'>[Container]</div><div style='font-size: 80%; margin-top:10px'>AssetDistributionMetadata<br />cache</div>")]
    style 17 fill:#bb1010,stroke:#820b0b,color:#000000

    subgraph 4 [Content Distribution Backend]
      style 4 fill:#ffffff,stroke:#6291a8,color:#6291a8

      10["<div style='font-weight: bold'>CachingAssetDistributionMetadataService</div><div style='font-size: 70%; margin-top: 0px'>[Component]</div><div style='font-size: 80%; margin-top:10px'>A caching wrapper for<br />RestAssetDistributionMetadataService.</div>"]
      style 10 fill:#8cd0c0,stroke:#629186,color:#000000
      11["<div style='font-weight: bold'>RestAssetDistributionMetadataService</div><div style='font-size: 70%; margin-top: 0px'>[Component]</div><div style='font-size: 80%; margin-top:10px'>Aggregates data about assets<br />into<br />AssetDistributionMetadata</div>"]
      style 11 fill:#8cd0c0,stroke:#629186,color:#000000
      5["<div style='font-weight: bold'>DefaultApiController</div><div style='font-size: 70%; margin-top: 0px'>[Component]</div><div style='font-size: 80%; margin-top:10px'>A thin Rest controller.</div>"]
      style 5 fill:#8cd0c0,stroke:#629186,color:#000000
      9["<div style='font-weight: bold'>ContentDistributionMetadataService</div><div style='font-size: 70%; margin-top: 0px'>[Component]</div><div style='font-size: 80%; margin-top:10px'>Processes orders, creates<br />ContentDistributionMetadata.</div>"]
      style 9 fill:#8cd0c0,stroke:#629186,color:#000000
    end

    5-. "<div>Gets<br />ContentDistributionMetadata<br />from</div><div style='font-size: 70%'></div>" .->9
    9-. "<div>Gets<br />AssetDistributionMetadata<br />from</div><div style='font-size: 70%'></div>" .->10
    10-. "<div>Delegates to</div><div style='font-size: 70%'></div>" .->11
    11-. "<div>Gets AssetMetadata from</div><div style='font-size: 70%'></div>" .->15
    11-. "<div>Gets BriefingMetadata from</div><div style='font-size: 70%'></div>" .->16
    10-. "<div>Caches<br />AssetDistributionMetadata in</div><div style='font-size: 70%'></div>" .->17
    2-. "<div>Requests<br />AssetDistributionMetadata for<br />ordered assets from</div><div style='font-size: 70%'></div>" .->5
  end
```
