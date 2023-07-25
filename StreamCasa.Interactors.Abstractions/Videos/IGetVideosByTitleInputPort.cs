using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCasa.Interactors.Abstractions.Videos
{
    public interface IGetVideosByTitleInputPort
    {
        Task Handle(string Title);
    }
}
