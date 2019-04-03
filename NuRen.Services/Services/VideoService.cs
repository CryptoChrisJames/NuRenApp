using NuRen.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuRen.Services.Services
{
    public class VideoService : IVideoService
    {
        public IVideoRepository _vr { get; set; }

        public VideoService(IVideoRepository vr)
        {
            _vr = vr;
        }
    }
}
