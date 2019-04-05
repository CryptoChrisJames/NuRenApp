using Microsoft.AspNetCore.Http;
using NuRen.Services.Abstractions;
using NuRen.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NuRen.Services.Services
{
    public class VideoService : IVideoService
    {
        public IVideoRepository _vr { get; set; }

        public VideoService(IVideoRepository vr)
        {
            _vr = vr;
        }

        public async Task<Guid> UploadVideo(IFormFile file)
        {
            var newVideo = new Video()
            {
                ID = Guid.NewGuid(),
                FileName = file.FileName,
                UploadDate = DateTime.Now
            };

            return await _vr.SaveVideo(file, newVideo);
        }
    }
}
