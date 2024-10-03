namespace MinimalBankAPI_OnionArch.Application.Common.Interfaces.RedisCache
{
    public interface IRedisCacheService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, DateTime? expratimTime = null);
    }
}
