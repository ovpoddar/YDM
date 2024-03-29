﻿using System;

namespace YDM.Concept.Models
{
    public class ProcessingModel
    {
        public string ReadableFilesize { get; private set; }
        public int Percentage { get; set; }
        public ProcessingModel(double filesize, double totalFileSize)
        {
            string[] sizes = { "Bytes", "Kb", "Mb", "Gb", "Tb" };
            int order = 0;
            double len = filesize;
            while (len >= 1024d && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024d;
            }

            ReadableFilesize = string.Format("{0:0.##} {1}", len, sizes[order]);
            if (totalFileSize == 0 || totalFileSize < filesize)
                return;
            Percentage = Convert.ToInt16(100 / totalFileSize * filesize);
        }
    }

}
