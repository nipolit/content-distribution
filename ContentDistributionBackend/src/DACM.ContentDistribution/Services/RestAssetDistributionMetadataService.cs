#nullable enable
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DACM.ContentDistribution.Models;
using Newtonsoft.Json;

namespace DACM.ContentDistribution.Services;

public class RestAssetDistributionMetadataService : IAssetDistributionMetadataService
{
    private const string AssetMetadataServiceUrl = "http://asset-metadata:5000";
    private const string BriefingMetadataServiceUrl = "http://briefing-metadata:5000";
    private const string CdnUrL = "https://example.com";
    private readonly HttpClient _httpClient = new();

    public RestAssetDistributionMetadataService()
    {
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public async Task<IList<AssetDistributionMetadata>> FetchAssetDistributionMetadata(IList<string> assetIds)
    {
        var assetMetadataDictionary = await FetchAssetMetadata(assetIds);
        var briefingMetadataDictionary = await FetchBriefingMetadata(assetIds);

        var assetDistributionMetadataList = new List<AssetDistributionMetadata>();
        foreach (var assetId in assetIds)
        {
            var assetMetadata = assetMetadataDictionary.TryGetValue(assetId, out var assetMetadataValue)
                ? assetMetadataValue
                : null;
            var briefingMetadata = briefingMetadataDictionary.TryGetValue(assetId, out var briefingMetadataValue)
                ? briefingMetadataValue
                : null;
            var assetDistributionMetadata = CreateAssetDistributionMetadata(assetId, assetMetadata, briefingMetadata);
            assetDistributionMetadataList.Add(assetDistributionMetadata);
        }

        return assetDistributionMetadataList;
    }

    private async Task<IDictionary<string, AssetMetadata>> FetchAssetMetadata(IList<string> assetIds)
    {
        var assetMetadataList = await RequestAssetMetadataFromRemoteService(assetIds);

        return assetMetadataList.ToDictionary(assetMetadata => assetMetadata.AssetId);
    }

    private async Task<IList<AssetMetadata>> RequestAssetMetadataFromRemoteService(IList<string> assetIds)
    {
        var assetIdsJson = JsonConvert.SerializeObject(assetIds);
        const string endpointUrl = AssetMetadataServiceUrl + "/asset-ids";
        using var response = await _httpClient.PostAsync(endpointUrl,
            new StringContent(assetIdsJson, Encoding.UTF8, "application/json")).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IList<AssetMetadata>>(responseBody)!;
    }

    private async Task<IDictionary<string, BriefingMetadata>> FetchBriefingMetadata(IList<string> assetIds)
    {
        var briefingMetadataByAssetId = new Dictionary<string, BriefingMetadata>();
        foreach (var assetId in assetIds)
        {
            // We don't know for sure how to match BriefingMetadata to the right asset when requesting many objects at once.
            // As a workaround, we request BriefingMetadata for each asset in a separate request.
            var briefingMetadataAsList = await RequestBriefingMetadataFromRemoteService(new List<string> { assetId });
            if (briefingMetadataAsList.Count == 1)
            {
                briefingMetadataByAssetId.Add(assetId, briefingMetadataAsList[0]);
            }
        }

        return briefingMetadataByAssetId;
    }

    private async Task<IList<BriefingMetadata>> RequestBriefingMetadataFromRemoteService(IList<string> assetIds)
    {
        var assetIdsJson = JsonConvert.SerializeObject(assetIds);
        const string endpointUrl = BriefingMetadataServiceUrl + "/asset-ids";
        using var response = await _httpClient.PostAsync(endpointUrl,
            new StringContent(assetIdsJson, Encoding.UTF8, "application/json")).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IList<BriefingMetadata>>(responseBody)!;
    }

    private static AssetDistributionMetadata CreateAssetDistributionMetadata(
        string assetId,
        AssetMetadata? assetMetadata,
        BriefingMetadata? briefingMetadata
    )
    {
        AssetDistributionMetadata assetDistributionMetadata = new()
        {
            AssetId = assetId,
            Name = briefingMetadata?.Name
        };
        if (assetMetadata != null)
        {
            assetDistributionMetadata.FileURL = CdnUrL + assetMetadata.Path;
        }

        return assetDistributionMetadata;
    }
}