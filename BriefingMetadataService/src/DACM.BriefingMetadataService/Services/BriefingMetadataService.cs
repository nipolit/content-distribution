using System.Collections.Generic;
using System.IO;
using System.Linq;
using DACM.BriefingMetadataService.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DACM.BriefingMetadataService.Services;

public class BriefingMetadataService
{
    private readonly IDictionary<string, BriefingMetadata> _briefingMetadataExamplesByAssetId;

    public BriefingMetadataService()
    {
        const string filePath = "../../../resources/Metadata/BriefingMetadata.json";

        // Deserialize the list from the file
        using var file = File.OpenText(filePath);
        using var reader = new JsonTextReader(file);
        var jArray = (JArray)JToken.ReadFrom(reader);
        var briefingMetadataExamples = jArray.ToObject<IList<BriefingMetadata>>();

        _briefingMetadataExamplesByAssetId = new Dictionary<string, BriefingMetadata>();
        var index = 1;
        foreach (var briefingMetadata in briefingMetadataExamples)
        {
            var assetId = "ASSET" + index.ToString("D3");
            index++;
            _briefingMetadataExamplesByAssetId.Add(assetId, briefingMetadata);
        }
    }

    public IList<BriefingMetadata> FetchBriefingMetadata(IList<string> assetIds)
    {
        return (from assetId in assetIds
            where _briefingMetadataExamplesByAssetId.ContainsKey(assetId)
            select _briefingMetadataExamplesByAssetId[assetId]).ToList();
    }
}