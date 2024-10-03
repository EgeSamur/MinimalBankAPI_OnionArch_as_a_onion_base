using MediatR;
using MinimalBankAPI_OnionArch.Application.Common.Interfaces.RedisCache;

namespace MinimalBankAPI_OnionArch.Application.Common.Pipelines
{
    public class RedisCacheBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService _redisCacheService;
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is ICacheableQuery query)
            {
                var cachKey = query.CacheKey;
                var cachTime = query.CacheTime;

                var cacheData = await _redisCacheService.GetAsync<TResponse>(cachKey);
                if (cacheData is not null)
                {
                    return cacheData;
                }

                var response = await next();
                if (response is not null)
                {
                    await _redisCacheService.SetAsync(cachKey, response, DateTime.Now.AddMinutes(cachTime));
                }
                return response;
            }

            return await next();
        }
    }
}
