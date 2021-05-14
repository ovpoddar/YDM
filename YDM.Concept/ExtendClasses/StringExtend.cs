using System;

namespace YDM.Concept.ExtendClasses
{
    public static class StringExtend
    {
        internal static bool ParseJSONKey(this string source, string key, out string value)
        {
            key = '"' + key + "\"";
            var startIndex = source.IndexOf(key, 0, StringComparison.Ordinal);
            var endIndex = source.IndexOf("\",", startIndex);

            startIndex = source.IndexOf('"', startIndex + key.Length) + 1;

            value = source.AsSpan()[startIndex..endIndex]
                .ToString();

            return true;
        }
    }
}
