using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace YDM.Concept.Helper
{
    public static class YouTubeVideo
    {
        public static string Decrypt(Uri uri, string js, StringBuilder stringBuilder) =>
            Decrypt(uri.AbsoluteUri, js, stringBuilder);

        public static string Decrypt(string uri, string js, StringBuilder stringBuilder)
        {
            var signature = string.Empty;
            var paths = string.Empty;
            var sp = string.Empty;

            var pairs = uri.Split('&');
            foreach (var pair in pairs)
            {
                var key = pair.Split('=');
                if (key[0] == "s")
                {
                    signature = DecryptSignature(js, Uri.UnescapeDataString(key[1]), stringBuilder);
                }
                else if (key[0] == "url")
                {
                    paths = Uri.UnescapeDataString(key[1]);
                }
                else
                {
                    sp = key[1];
                }
            }

            return $"{paths}&{sp}={signature}";
        }

        private static string DecryptSignature(string js, string signature, StringBuilder stringBuilder)
        {
            var functionNameRegex = new Regex(@"\w+(?:.|\[)(\""?\w+(?:\"")?)\]?\(");
            var functionLines = GetDecryptionFunctionLines(js);
            var decryptor = new Decryptor();
            var decipherDefinitionName = Regex.Match(string.Join(";", functionLines), "([\\$_\\w]+).\\w+\\(\\w+,\\d+\\);").Groups[1].Value;
            if (string.IsNullOrEmpty(decipherDefinitionName))
            {
                throw new Exception("Could not find signature decipher definition name. Please report this issue to us.");
            }

            var decipherDefinitionBody = Regex.Match(js, $@"var\s+{Regex.Escape(decipherDefinitionName)}=\{{(\w+:function\(\w+(,\w+)?\)\{{(.*?)\}}),?\}};", RegexOptions.Singleline).Groups[0].Value;
            if (string.IsNullOrEmpty(decipherDefinitionBody))
            {
                throw new Exception("Could not find signature decipher definition body. Please report this issue to us.");
            }
            foreach (var functionLine in functionLines)
            {
                if (decryptor.IsComplete)
                {
                    break;
                }

                var match = functionNameRegex.Match(functionLine);
                if (match.Success)
                {
                    decryptor.AddFunction(decipherDefinitionBody, match.Groups[1].Value);
                }
            }

            foreach (var functionLine in functionLines)
            {
                var match = functionNameRegex.Match(functionLine);
                if (match.Success)
                {
                    signature = decryptor.ExecuteFunction(signature, functionLine, match.Groups[1].Value, stringBuilder);
                }
            }

            return signature;
        }
        private static string[] GetDecryptionFunctionLines(string js)
        {
            var decipherFuncName = Regex.Match(js, @"(\w+)=function\(\w+\){(\w+)=\2\.split\(\x22{2}\);.*?return\s+\2\.join\(\x22{2}\)}");
            return decipherFuncName.Success ? decipherFuncName.Groups[0].Value.Split(';') : null;
        }

        private class Decryptor
        {
            private static readonly Regex ParametersRegex = new Regex(@"\(\w+,(\d+)\)");

            private readonly Dictionary<string, FunctionType> _functionTypes = new Dictionary<string, FunctionType>();

            public bool IsComplete =>
                _functionTypes.Count == Enum.GetValues(typeof(FunctionType)).Length;

            public void AddFunction(string js, string function)
            {
                var escapedFunction = Regex.Escape(function);
                FunctionType? type = null;
                /* Pass  "do":function(a){} or xa:function(a,b){} */
                if (Regex.IsMatch(js, $@"(\"")?{escapedFunction}(\"")?:\bfunction\b\([a],b\).(\breturn\b)?.?\w+\."))
                {
                    type = FunctionType.Slice;
                }
                else if (Regex.IsMatch(js, $@"(\"")?{escapedFunction}(\"")?:\bfunction\b\(\w+\,\w\).\bvar\b.\bc=a\b"))
                {
                    type = FunctionType.Swap;
                }
                if (Regex.IsMatch(js, $@"(\"")?{escapedFunction}(\"")?:\bfunction\b\(\w+\){{\w+\.reverse"))
                {
                    type = FunctionType.Reverse;
                }
                if (type.HasValue)
                {
                    _functionTypes[function] = type.Value;
                }
            }

            public string ExecuteFunction(string signature, string line, string function, StringBuilder stringBuilder)
            {
                if (!_functionTypes.TryGetValue(function, out var type))
                {
                    return signature;
                }

                switch (type)
                {
                    case FunctionType.Reverse:
                        return Reverse(signature, stringBuilder);
                    case FunctionType.Slice:
                    case FunctionType.Swap:
                        var index =
                            int.Parse(
                                ParametersRegex.Match(line).Groups[1].Value,
                                NumberStyles.AllowThousands,
                                NumberFormatInfo.InvariantInfo);
                        return
                            type == FunctionType.Slice
                                ? Slice(signature, index)
                                : Swap(signature, index, stringBuilder);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type));
                }
            }

            private string Reverse(string signature, StringBuilder stringBuilder)
            {
                stringBuilder.Clear();
                for (var index = signature.Length - 1; index >= 0; index--)
                {
                    stringBuilder.Append(signature[index]);
                }

                return stringBuilder.ToString();
            }

            private string Slice(string signature, int index) =>
                signature.Substring(index);

            private string Swap(string signature, int index, StringBuilder stringBuilder)
            {
                stringBuilder.Clear();
                stringBuilder.Append(signature);
                stringBuilder[0] = stringBuilder[index % stringBuilder.Length];
                stringBuilder[index % stringBuilder.Length] = signature[0];
                return stringBuilder.ToString();
            }

            private enum FunctionType
            {
                Reverse,
                Slice,
                Swap
            }
        }
    }

}
