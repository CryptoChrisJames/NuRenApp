using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NuRen.Services.Abstractions;
using NuRen.Services.Data;
using NuRen.Services.Models;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NuRen.Services.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private ApplicationDbContext _context;
        private IAmazonS3 _s3;
        private RedisClient _redisClient;

        public VideoRepository(ApplicationDbContext context, IAmazonS3 s3)
        {
            _context = context;
            _s3 = s3;
            _redisClient = new RedisClient("18.223.213.232", 6379, "OathofObsidian12!");
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
            await _s3.PutObjectAsync(request);
            await _context.Videos.AddAsync(newVideo);
            await _context.SaveChangesAsync();
            var Videos = _redisClient.As<Video>();
            Videos.Store(newVideo);
            return newVideo.ID;
        }
    }
}
