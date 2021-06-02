﻿using System;

namespace YDM.Concept.Models
{
    public class FileInformation
    {
        public string FileExtenction { get; set; }
        public FileTypeEnum FileType { get; set; }
        public Uri Uri { get; set; }
        public string Format { get; set; }
        public int Id { get; set; }
    }
}
