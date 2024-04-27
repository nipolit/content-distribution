using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DACM.ContentDistribution.Models;

namespace DACM.ContentDistribution.Services;

public class ContentDistributionMetadataService
{
    private readonly IAssetDistributionMetadataService _assetDistributionMetadataService =
        new CachingAssetDistributionMetadataService();

    public async Task<ContentDistributionMetadata> ProcessOrder(OrderListMetadata orderListMetadata)
    {
        var assetIds = orderListMetadata.Assets!.Select(assetOrderMetadata => assetOrderMetadata.AssetId).ToList();
        var distributionMetadataForAssetIds =
            await _assetDistributionMetadataService.FetchAssetDistributionMetadata(assetIds);
        var isoDateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat.UniversalSortableDateTimePattern;
        var isoDate = DateTime.Today.ToString(isoDateTimeFormat)[..10];

        return new ContentDistributionMetadata
        {
            DistributionDate = isoDate,
            DistributionChannel = "Online Store",
            DistributionMethod = "Digital Download",
            Assets = distributionMetadataForAssetIds
        };
    }
}