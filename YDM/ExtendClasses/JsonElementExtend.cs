using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace YDM.ExtendClasses
{
    public static class JsonElementExtend
    {
        internal static List<JsonElement> FindProperty(this JsonElement element, string propertyName)
        {
            var result = new List<JsonElement>();


            var check = element.TryGetProperty(propertyName, out var res);

            if (!check)
            {
                try
                {
                    using (var enumarator = element.EnumerateObject())
                    {
                        foreach (var emumarate in enumarator)
                        {
                            result.AddRange(FindProperty(emumarate.Value, propertyName));

                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    try
                    {
                        using (var enumarator = element.EnumerateArray())
                        {
                            foreach (var emumarate in enumarator)
                            {
                                result.AddRange(FindProperty(emumarate, propertyName));
                            }
                        }
                    }
                    catch
                    {
                        return result;
                    }
                }
            }
            if (res.ValueKind != JsonValueKind.Undefined)
                result.Add(res);
            return result;
        }
    }
}
