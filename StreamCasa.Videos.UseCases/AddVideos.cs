using StreamCasa.Builders;
using StreamCasa.Entities.Abstractions.Repositories;
using StreamCasa.Interactors.Abstractions.DTO;
using StreamCasa.Interactors.Abstractions.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCasa.Videos.UseCases
{
    public class AddVideos : IAddVideosInputPort
    {
        private readonly IAddVideosOutputPort _addVideosOutputPort;
        private readonly IVideosRepository _videosRepository;
        private readonly VideosBuilder _videosBuilder;

        public AddVideos(IAddVideosOutputPort addVideosOutputPort, IVideosRepository videosRepository, VideosBuilder videosBuilder)
        {
            _addVideosOutputPort = addVideosOutputPort;
            _videosRepository = videosRepository;
            _videosBuilder = videosBuilder;
        }

        public async Task Handle(VideosDTO ToAdd)
        {
            if (ToAdd.Title.Contains("Accion"))
            {
                ToAdd.Title = "Para mayores de 16";
            }
            var ToRegistry = _videosBuilder.Convert(ToAdd);
            await _videosRepository.AddOrUpdate(ToRegistry);
            await _addVideosOutputPort.Handle(ToAdd);
        }
    }
}
