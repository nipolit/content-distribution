using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace DACM.ContentDistribution.Daos;

public class RedisCacheDao
{
    private readonly ConnectionMultiplexer _redis;

    public RedisCacheDao()
    {
        _redis = ConnectionMultiplexer.Connect("redis");
    }

    private IDatabase Database() => _redis.GetDatabase();

    public async Task<IDictionary<string, T>> GetData<T>(IEnumerable<string> keys)
    {
        var redisKeys = keys.Select(key => (RedisKey)key).ToArray();
        var redisValues = await Database().StringGetAsync(redisKeys);

        var redisKeysAndValues = redisKeys.Zip(redisValues, (key, value) => new { Key = key, Value = value });
        return redisKeysAndValues
            .Where(redisKeyAndValue => redisKeyAndValue.Value.HasValue)
            .ToDictionary(
                redisKeyAndValue => (string)redisKeyAndValue.Key,
                redisKeyAndValue => JsonConvert.DeserializeObject<T>(redisKeyAndValue.Value)
            );
    }

    public void SetData<T>(IDictionary<string, T> valuesByKeys)
    {
        var convertedKeyValuePairs = valuesByKeys.Select(keyValuePair =>
            KeyValuePair.Create(
                (RedisKey)keyValuePair.Key,
                (RedisValue)JsonConvert.SerializeObject(keyValuePair.Value)
            )
        ).ToArray();
        Database().StringSetAsync(convertedKeyValuePairs, flags: CommandFlags.FireAndForget);
    }

    public void SetData<T>(string key, T value, TimeSpan expirationTime)
    {
        var valueJson = JsonConvert.SerializeObject(value);
        Database().StringSetAsync(key, valueJson, expirationTime, flags: CommandFlags.FireAndForget);
    }
}