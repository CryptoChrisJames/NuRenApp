
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NuRen.Services.Abstractions;
using NuRen.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NuRen.Services.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private IHostingEnvironment _env;
        string _uploadPath { get; set; }

        public VideoRepository(IHostingEnvironment env)
        {
            _env = env;
            _uploadPath = Path.Combine(_env.WebRootPath, "videos");
        }

        public async Task<Guid> SaveVideo(IFormFile file, Video newVideo)
        {
            Directory.CreateDirectory(_uploadPath);
            string filename = file.FileName;
            using (FileStream fs = new FileStream(Path.Combine(_uploadPath, filename), FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }
            return newVideo.ID;
        }
    }
}
