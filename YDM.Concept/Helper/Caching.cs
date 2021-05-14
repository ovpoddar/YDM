using System;
using System.Runtime.Caching;

namespace YDM.Concept.Helper
{
    public static class Caching
    {
        private static readonly MemoryCache _memoryCache = new MemoryCache("YDM");

        public static void AddItem(string key, string value) =>
            _memoryCache.Add(key, value, DateTimeOffset.Now.AddDays(1));

        public static void DeleteItem(string key) =>
            _memoryCache.Remove(key);

        public static string GetItem(string key) =>
            (string)_memoryCache[key];
    }
}
