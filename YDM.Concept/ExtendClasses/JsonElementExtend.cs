using System;
using System.Text.Json;
using YDM.Concept.Models;

namespace YDM.Concept.ExtendClasses
{
    internal static class JsonElementExtend
    {
        private static bool _isFound = false;
        internal static JsonElement FindElement(this JsonElement element, string propertyName)
        {
            if (!(element.TryGetProperty(propertyName, out var result) && _isFound))
            {
                try
                {
                    using (var enumarator = element.EnumerateObject())
                    {
                        foreach (var emumarate in enumarator)
                        {
                            if (_isFound)
                                break;
                            result = FindElement(emumarate.Value, propertyName);

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
                                if (_isFound)
                                    break;
                                result = FindElement(emumarate, propertyName);
                            }
                        }
                    }
                    catch
                    {
                        _isFound = false;
                        return result;
                    }
                }
            }
            _isFound = true;
            return result;
        }

        internal static string TryToParseProprity(this JsonElement element, string[] queryes)
        {
            var result = new JsonElement();
            for (int i = 0; i < queryes.Length; i++)
            {
                if (element.TryGetProperty(queryes[i], out result))
                    break;
            }
            return result.ToString();
        }

        internal static JsonElement GetProperty(this JsonElement element, JSONPath path)
        {
            var result = element;
            var success = true;
            for (int i = 0; i < path.PathDirectory.Length; i++)
            {
                if (!result.TryGetProperty(path.PathDirectory[i], out result))
                {
                    result = new JsonElement();
                    success = false;
                    break;
                }
            }
            if (!success)
            {
                try
                {
                    result = (JsonElement)element.SelectElement(path.DeclearedPath);
                }
                catch
                {
                    result = new JsonElement();
                }
            }
            return result;
        }
    }
}
