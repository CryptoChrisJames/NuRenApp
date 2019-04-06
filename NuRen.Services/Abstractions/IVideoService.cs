using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NuRen.Services.Abstractions
{
    public interface IVideoService
    {
        Task<Guid> UploadVideo(IFormFile file, string videoTitle);
    }
}
