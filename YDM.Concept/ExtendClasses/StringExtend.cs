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

        internal static string HumanReadAbleLong(this string source)
        {
            string[] sizes = { "Bytes", "Kb", "Mb", "Gb", "Tb" };
            int order = 0;
            double len = double.Parse(source);
            while (len >= 1024d && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024d;
            }

            return string.Format("{0:0.##} {1}", len, sizes[order]);
        }
    }
}
