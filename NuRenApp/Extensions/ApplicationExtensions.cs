using Microsoft.Extensions.DependencyInjection;
using NuRen.Services.Abstractions;
using NuRen.Services.Repositories;
using NuRen.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuRenApp.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services)
        {
            services.AddSingleton<IVideoService, VideoService>();
            services.AddTransient<IVideoRepository, VideoRepository>();

            return services;
        }
    }
}
