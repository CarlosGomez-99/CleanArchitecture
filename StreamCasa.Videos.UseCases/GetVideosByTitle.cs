using StreamCasa.Builders;
using StreamCasa.Entities.Abstractions.Repositories.Queries;
using StreamCasa.Interactors.Abstractions.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCasa.Videos.UseCases
{
    internal class GetVideosByTitle : IGetVideosByTitleInputPort
    {
        private readonly IGetVideosByTitleOutputPort _getVideosByTitleOutputPort;
        private readonly IQueryVideosRepository _queryVideosRepository;
        private readonly VideosBuilder _videosBuilder;

        public GetVideosByTitle(IGetVideosByTitleOutputPort getVideosByTitleOutputPort, IQueryVideosRepository queryVideosRepository, VideosBuilder videosBuilder)
        {
            _getVideosByTitleOutputPort = getVideosByTitleOutputPort;
            _queryVideosRepository = queryVideosRepository;
            _videosBuilder = videosBuilder;
        }
        public async Task Handle(string Title)
        {
            var videos = await _queryVideosRepository.GetAllVideosByTitle(Title);
            var ToList = _videosBuilder.Convert(videos);
            await _getVideosByTitleOutputPort.Handle(ToList);
        }
    }
}
