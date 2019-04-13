using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuRen.Services.Models
{
    public class Video
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool FeatureFilm { get; set; }
        public string FileName { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
