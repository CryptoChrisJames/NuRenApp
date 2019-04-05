using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
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
        private IAmazonS3 _s3Client;

        public VideoRepository(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<Guid> SaveVideo(IFormFile file, Video newVideo)
        {
            Stream fileStream = file.OpenReadStream();
            var S3Client = new AmazonS3Client(Amazon.RegionEndpoint.USEast2);
            var request = new PutObjectRequest();
            request.BucketName = "nu-ren-bucket";
            request.Key = newVideo.ID.ToString();
            request.InputStream = fileStream;
            request.ContentType = file.ContentType;
            request.CannedACL = S3CannedACL.PublicRead;
            var response = await _s3Client.PutObjectAsync(request);
            //var uploadrequest = new TransferUtilityUploadRequest()
            //{
            //    InputStream = fileStream,
            //    Key = newVideo.ID.ToString(),
            //    BucketName = "nu-ren-bucket",
            //    CannedACL = S3CannedACL.PublicRead
            //};
            return newVideo.ID;
        }
    }
}
