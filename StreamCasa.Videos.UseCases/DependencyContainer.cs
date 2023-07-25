using Microsoft.Extensions.DependencyInjection;
using StreamCasa.Interactors.Abstractions.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCasa.Videos.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddVideosUseCases(this IServiceCollection services)
        {
            services.AddScoped<IAddVideosInputPort, AddVideos>();
            services.AddScoped<IGetAllVideosInputPort, GetAllVideos>();
            services.AddScoped<IGetVideosByTitleInputPort, GetVideosByTitle>();
            return services;
        }
    }
}
