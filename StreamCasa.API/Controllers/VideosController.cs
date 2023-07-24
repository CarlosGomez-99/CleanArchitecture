using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreamCasa.Interactors.Abstractions.DTO;
using StreamCasa.Interactors.Abstractions.Videos;

namespace StreamCasa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IAddVideosInputPort _addVideosInputPort;
        private readonly IAddVideosOutputPort _addVideosOutputPort;

        public VideosController(IAddVideosInputPort addVideosInputPort, IAddVideosOutputPort addVideosOutputPort)
        {
            _addVideosInputPort = addVideosInputPort;
            _addVideosOutputPort = addVideosOutputPort;
        }
        [HttpPost]
        public async Task<IActionResult> AddVideo(VideosDTO videosDTO)
        {
            await _addVideosInputPort.Handle(videosDTO);
            var response = _addVideosOutputPort.Content;
            return Ok(response);
        }
    }
}
