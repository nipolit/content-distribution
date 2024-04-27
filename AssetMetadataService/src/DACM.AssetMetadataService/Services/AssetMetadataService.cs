using System.Collections.Generic;
using System.IO;
using System.Linq;
using DACM.AssetMetadataService.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DACM.AssetMetadataService.Services;

public class AssetMetadataService
{
    private readonly IDictionary<string, AssetMetadata> _assetMetadataExamplesByAssetId;

    public AssetMetadataService()
    {
        const string filePath = "/app/resources/Metadata/AssetMetadata.json";

        // Deserialize the list from the file
        using var file = File.OpenText(filePath);
        using var reader = new JsonTextReader(file);
        var jArray = (JArray)JToken.ReadFrom(reader);
        var assetMetadataExamples = jArray.ToObject<IList<AssetMetadata>>();

        _assetMetadataExamplesByAssetId = new Dictionary<string, AssetMetadata>();
        foreach (var assetMetadata in assetMetadataExamples)
        {
            _assetMetadataExamplesByAssetId.Add(assetMetadata.AssetId, assetMetadata);
        }
    }

    public IList<AssetMetadata> FetchAssetMetadata(IList<string> assetIds)
    {
        return (from assetId in assetIds
            where _assetMetadataExamplesByAssetId.ContainsKey(assetId)
            select _assetMetadataExamplesByAssetId[assetId]).ToList();
    }
}