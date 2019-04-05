
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

        public VideoRepository(IHostingEnvironment env)
        {
            _env = env;
        }

        public async Task<Guid> SaveVideo(IFormFile file, Video newVideo)
        {
            
            return newVideo.ID;
        }
    }
}
