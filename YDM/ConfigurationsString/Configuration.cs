using System;
using System.Collections.Generic;
using System.Text;

namespace YDM.ConfigurationsString
{
    internal static class Configuration
    {
        public static string Host { get => "www.youtube.com"; }
        public static int MaxRetries { get => 3; }
        public static string ScriptBegin { get=> "var ytInitialPlayerResponse ="; }
        public static string ScriptEnd { get=> ";</script><div id=\"player\" class=\"skeleton flexy\">"; }

    }
}
