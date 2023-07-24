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

        public VideosController(IAddVideosInputPort addVideosInputPort, IAddVideosOutputPort addVideosOutputPort, IGetAllVideosInputPort getAllVideosInputPort, IGetAllVideosOutputPort getAllVideosOutputPort)
        {
            _addVideosInputPort = addVideosInputPort;
            _addVideosOutputPort = addVideosOutputPort;
            _getAllVideosInputPort = getAllVideosInputPort;
            _getAllVideosOutputPort = getAllVideosOutputPort;
        }
        [HttpGet]
        public async Task<IActionResult> GetVideos()
        {
            await _getAllVideosInputPort.Handle();
            var response = ((IPresenter<List<VideosDTO>>)_getAllVideosOutputPort).Content;
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
