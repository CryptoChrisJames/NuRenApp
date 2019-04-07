
using Amazon.S3;
using Amazon.S3.Model;
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
        private IAmazonS3 _s3;

        public VideoRepository(IHostingEnvironment env, ApplicationDbContext context, IAmazonS3 s3)
        {
            _env = env;
            _uploadPath = Path.Combine(_env.WebRootPath, "videos");
            _context = context;
            _s3 = s3;
        }

        public async Task<Guid> SaveVideo(IFormFile file, Video newVideo)
        {
            Stream fileStream = file.OpenReadStream();
            var request = new PutObjectRequest()
            {
                BucketName = "nu-ren-bucket",
                Key = newVideo.ID.ToString(),
                InputStream = fileStream,
                ContentType = file.ContentType
            };
            var response = await _s3.PutObjectAsync(request);
            //Directory.CreateDirectory(_uploadPath);
            //string filename = file.FileName;
            //var filepath = Path.Combine(_uploadPath, filename);
            //using (FileStream fs = new FileStream(filepath, FileMode.Create))
            //{
            //    await file.CopyToAsync(fs);
            //}
            //newVideo.FilePath = filepath;
            //await _context.Videos.AddAsync(newVideo);
            //await _context.SaveChangesAsync();
            return newVideo.ID;
        }
    }
}
