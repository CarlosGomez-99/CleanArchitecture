using StreamCasa.Entities;
using StreamCasa.Interactors.Abstractions.DTO;

namespace StreamCasa.Builders
{
    public class VideosBuilder : BuilderBase<Videos, VideosDTO>
    {
        public override Videos Convert(VideosDTO param)
        {
            return new Videos()
            {
                Id = param.Id,
                Title = param.Title,
                Source = param.Source,
                Description = param.Description
            };
        }

        public override VideosDTO Convert(Videos param)
        {
            return new VideosDTO()
            {
                Id = param.Id,
                Title = param.Title,
                Source = param.Source,
                Description = param.Description
            };
        }
    }
}