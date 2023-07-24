using StreamCasa.Interactors.Abstractions.DTO;
using StreamCasa.Interactors.Abstractions.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCasa.Presenters
{
    public class GetAllVideosPresenter : IGetAllVideosOutputPort, IPresenter<List<VideosDTO>>
    {
        public List<VideosDTO> Content { get; private set; }

        public Task Handle(List<VideosDTO> videos)
        {
            Content = videos;
            return Task.CompletedTask;
        }
    }
}
