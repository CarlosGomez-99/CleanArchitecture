using Microsoft.EntityFrameworkCore;
using StreamCasa.Entities;
using StreamCasa.Entities.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCasa.Repository.EFCore
{
    public class VideosRepository : IVideosRepository
    {
        private readonly StreamCasaDBContext _dbContext;

        public VideosRepository(StreamCasaDBContext context)
        {
            _dbContext = context;
        }

        public async Task<Videos> AddOrUpdate(Videos videos)
        {
            if (videos.Id != Guid.Empty)
            {
                _dbContext.Videos.Update(videos);
            }
            else
            {
                await _dbContext.Videos.AddAsync(videos);
            }
            await _dbContext.SaveChangesAsync();
            return videos;
        }

        public async Task<Videos> Delete(Videos videos)
        {
            if (videos.Id != Guid.Empty)
            {
                _dbContext.Remove(videos);
            }
            await _dbContext.SaveChangesAsync();
            return videos;
        }

        public async Task<List<Videos>> GetAll()
        {
            return await _dbContext.Videos.ToListAsync();
        }
    }
}
