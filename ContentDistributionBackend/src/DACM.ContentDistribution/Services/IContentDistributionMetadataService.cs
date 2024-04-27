using System.Collections.Generic;
using System.Threading.Tasks;
using DACM.ContentDistribution.Models;

namespace DACM.ContentDistribution.Services;

public interface IContentDistributionMetadataService
{
    Task<ContentDistributionMetadata> ProcessOrder(OrderListMetadata orderListMetadata);
    Task<IList<AssetDistributionMetadata>> FetchAssetDistributionMetadata(IList<string> assetIds);
}