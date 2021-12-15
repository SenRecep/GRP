#nullable disable
using GRP.Services.WaterTankCalculator.BLL.Interfaces;

using Microsoft.Extensions.Caching.Memory;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class MemoryCacheStore : ICacheStore
{
    private readonly IMemoryCache _memoryCache;
    private readonly Dictionary<string, TimeSpan> _expirationConfiguration;

    public MemoryCacheStore(
        IMemoryCache memoryCache,
        Dictionary<string, TimeSpan> expirationConfiguration)
    {
        _memoryCache = memoryCache;
        this._expirationConfiguration = expirationConfiguration;
    }

    public void Add<TItem>(TItem item, ICacheKey<TItem> key)
    {
        var timespan = _expirationConfiguration[key.CacheKey];
        this._memoryCache.Set(key.CacheKey, item, timespan);
    }

    public TItem Get<TItem>(ICacheKey<TItem> key) where TItem : class
    {
        if (this._memoryCache.TryGetValue(key.CacheKey, out TItem value))
            return value;
        return null;
    }
}
