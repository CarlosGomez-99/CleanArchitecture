using StreamCasa.Builders;
using StreamCasa.Entities.Abstractions.Repositories;
using StreamCasa.Interactors.Abstractions.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCasa.Videos.UseCases
{
    public class GetAllVideos : IGetAllVideosInputPort
    {
        private readonly IGetAllVideosOutputPort _getAllVideosOutputPort;
        private readonly IVideosRepository _videosRepository;
        private readonly VideosBuilder _videosBuilder;

        public GetAllVideos(IGetAllVideosOutputPort getAllVideosOutputPort, IVideosRepository videosRepository, VideosBuilder videosBuilder)
        {
            _getAllVideosOutputPort = getAllVideosOutputPort;
            _videosRepository = videosRepository;
            _videosBuilder = videosBuilder;
        }
        public async Task Handle()
        {
            var videos =await _videosRepository.GetAll();
            var ToList = _videosBuilder.Convert(videos);
            await _getAllVideosOutputPort.Handle(ToList);
        }
    }
}
