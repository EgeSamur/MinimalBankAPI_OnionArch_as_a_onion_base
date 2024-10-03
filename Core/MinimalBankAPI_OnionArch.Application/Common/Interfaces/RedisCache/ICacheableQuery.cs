namespace MinimalBankAPI_OnionArch.Application.Common.Interfaces.RedisCache
{
    public interface ICacheableQuery
    {
        string CacheKey { get; }
        double CacheTime { get; }
    }
}
