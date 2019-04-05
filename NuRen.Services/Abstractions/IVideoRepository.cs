using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NuRen.Services.Models;

namespace NuRen.Services.Abstractions
{
    public interface IVideoRepository
    {
        Task<Guid> SaveVideo(IFormFile file, Video newVideo);
    }
}
