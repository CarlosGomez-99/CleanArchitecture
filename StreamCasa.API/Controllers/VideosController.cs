using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreamCasa.Interactors.Abstractions.DTO;
using StreamCasa.Interactors.Abstractions.Videos;
using StreamCasa.Presenters;

namespace StreamCasa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IAddVideosInputPort _addVideosInputPort;
        private readonly IAddVideosOutputPort _addVideosOutputPort;
        private readonly IGetAllVideosInputPort _getAllVideosInputPort;
        private readonly IGetAllVideosOutputPort _getAllVideosOutputPort;
        private readonly IGetVideosByTitleInputPort _getVideosByTitleInputPort;
        private readonly IGetVideosByTitleOutputPort _getVideosByTitleOutputPort;

        public VideosController(IAddVideosInputPort addVideosInputPort, IAddVideosOutputPort addVideosOutputPort, IGetAllVideosInputPort getAllVideosInputPort, IGetAllVideosOutputPort getAllVideosOutputPort, IGetVideosByTitleInputPort getVideosByTitleInputPort, IGetVideosByTitleOutputPort getVideosByTitleOutputPort)
        {
            _addVideosInputPort = addVideosInputPort;
            _addVideosOutputPort = addVideosOutputPort;
            _getAllVideosInputPort = getAllVideosInputPort;
            _getAllVideosOutputPort = getAllVideosOutputPort;
            _getVideosByTitleInputPort = getVideosByTitleInputPort;
            _getVideosByTitleOutputPort = getVideosByTitleOutputPort;
        }
        [HttpGet]
        public async Task<IActionResult> GetVideos()
        {
            await _getAllVideosInputPort.Handle();
            var response = ((IPresenter<List<VideosDTO>>)_getAllVideosOutputPort).Content;
            return Ok(response);
        }
        [HttpGet("Title")]
        public async Task<IActionResult> GetVideosByTitle(string title)
        {
            await _getVideosByTitleInputPort.Handle(title);
            var response = ((IPresenter<List<VideosDTO>>)_getVideosByTitleOutputPort).Content;
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddVideo(VideosDTO videosDTO)
        {
            await _addVideosInputPort.Handle(videosDTO);
            var response = ((IPresenter<VideosDTO>)_addVideosOutputPort).Content;
            return Ok(response);
        }
    }
}
