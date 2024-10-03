using Microsoft.Extensions.Options;
using MinimalBankAPI_OnionArch.Application.Common.Interfaces.RedisCache;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MinimalBankAPI_OnionArch.Application.Common.CCC.Caches.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly ConnectionMultiplexer _redisConnection;
        private readonly IDatabase _redisDatabase;
        private readonly RedisCacheSettings _redisSettings;

        public RedisCacheService(IOptions<RedisCacheSettings> options)
        {
            _redisSettings = options.Value;
            var opt = ConfigurationOptions.Parse(_redisSettings.ConnectionString);
            _redisConnection = ConnectionMultiplexer.Connect(opt);
            _redisDatabase = _redisConnection.GetDatabase();
        }
        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _redisDatabase.StringGetAsync(key);
            if (value.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }

            return default;
        }

        public async Task SetAsync<T>(string key, T value, DateTime? expratimTime = null)
        {
            // Saniye cinsine çevirmek için yapıyoruz.
            TimeSpan timeUntilExp = expratimTime.Value - DateTime.Now;
            await _redisDatabase.StringSetAsync(key, JsonConvert.SerializeObject(value), timeUntilExp);
        }
    }
}
