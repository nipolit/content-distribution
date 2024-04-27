using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DACM.ContentDistribution.Daos;
using DACM.ContentDistribution.Models;

namespace DACM.ContentDistribution.Services;

public class CachingAssetDistributionMetadataService : IAssetDistributionMetadataService
{
    private readonly RedisCacheDao _redisCacheDao = new();
    private readonly IAssetDistributionMetadataService _delegate = new RestAssetDistributionMetadataService();

    public async Task<IList<AssetDistributionMetadata>> FetchAssetDistributionMetadata(IList<string> assetIds)
    {
        var cachedMetadataByAssetId = await _redisCacheDao.GetData<AssetDistributionMetadata>(assetIds);
        var cacheMisses = assetIds.Where(assetId => !cachedMetadataByAssetId.ContainsKey(assetId)).ToList();

        var cachedMetadataList = cachedMetadataByAssetId.Values.ToList();
        if (cacheMisses.Count == 0)
        {
            return cachedMetadataList;
        }

        var metadataMissingInCache = await FetchAssetDistributionMetadataFromDelegate(cacheMisses);

        return metadataMissingInCache.Concat(cachedMetadataList).ToList();
    }

    private async Task<IList<AssetDistributionMetadata>> FetchAssetDistributionMetadataFromDelegate(
        IList<string> assetIds)
    {
        var assetDistributionMetadataList = await _delegate.FetchAssetDistributionMetadata(assetIds);
        _redisCacheDao.SetData(assetDistributionMetadataList.ToDictionary(metadata => metadata.AssetId));
        return assetDistributionMetadataList;
    }
}