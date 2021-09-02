using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;
using YDM.Concept;
using YDM.Concept.Models;
using YDM.CustomeUserControl;
using YDM.Model;

namespace YDM.Helper
{
    public static class SettingHelper
    {
        public static Dictionary<int, FileDownloadControl> Lists()
        {
            var result = new Dictionary<int, FileDownloadControl>();
            foreach (var item in _lists)
            {
                if (item.Files.Count == 1)
                    result.Add(result.Count, new FileDownloadControl(new YDMDownloader(item.Files[0], item.FilePath, item.FileName)));
                else
                    result.Add(result.Count, new FileDownloadControl(new YDMDownloader(item.Files[0], item.Files[1], item.FilePath, item.FileName)));
            }
            return result;
        }

        private static List<YDMDownloadArguments> _lists
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Properties.Settings.Default.Queue))
                    return new List<YDMDownloadArguments>();
                return JsonSerializer.Deserialize<List<YDMDownloadArguments>>(Properties.Settings.Default.Queue);

            }
        }
        internal static void AddItem(string finalFile, List<FileInformation> files)
        {
            var current = _lists;
            var filename = Path.GetFileName(finalFile);
            var filepath = Path.GetDirectoryName(finalFile);

            var args = new YDMDownloadArguments()
            {
                Files = files,
                FileName = filename,
                FilePath = filepath
            };

            current.Add(args);

            Properties.Settings.Default.Queue = JsonSerializer.Serialize(current);
            Properties.Settings.Default.Save();
        }
    }
}
