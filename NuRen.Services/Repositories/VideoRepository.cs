
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NuRen.Services.Abstractions;
using NuRen.Services.Data;
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
        private ApplicationDbContext _context;
        string _uploadPath { get; set; }

        public VideoRepository(IHostingEnvironment env, ApplicationDbContext context)
        {
            _env = env;
            _uploadPath = Path.Combine(_env.WebRootPath, "videos");
            _context = context;
        }

        public async Task<Guid> SaveVideo(IFormFile file, Video newVideo)
        {
            Directory.CreateDirectory(_uploadPath);
            string filename = file.FileName;
            var filepath = Path.Combine(_uploadPath, filename);
            using (FileStream fs = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }
            newVideo.FilePath = filepath;
            await _context.Videos.AddAsync(newVideo);
            await _context.SaveChangesAsync();
            return newVideo.ID;
        }
    }
}
