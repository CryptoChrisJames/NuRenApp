using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuRen.Services.Abstractions;
using NuRen.Services.Models;

namespace NuRenApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        public IVideoService _vs { get; set; }

        public VideoController(IVideoService vs)
        {
            _vs = vs;
        }

        [HttpPost]
        [Route("upload/{videoTitle}")]
        public async Task<Guid> UploadVideo (IFormFile file, string videoTitle)
        {
           return await _vs.UploadVideo(file, videoTitle);
        }
    }
}