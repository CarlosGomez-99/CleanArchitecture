using StreamCasa.Entities;
using StreamCasa.Entities.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCasa.Repository.EFCore
{
    internal class UsersVideoRepository : IUsersVideosRepository
    {
        private readonly StreamCasaDBContext _dbContext;

        public UsersVideoRepository(StreamCasaDBContext context)
        {
            _dbContext = context;
        }

        public async Task<UsersVideos> AddOrUpdate(UsersVideos usersVideos)
        {
            if (usersVideos.Id != Guid.Empty)
            {
                _dbContext.UsersVideos.Update(usersVideos);
            }
            else
            {
                await _dbContext.UsersVideos.AddAsync(usersVideos);
            }
            await _dbContext.SaveChangesAsync();
            return usersVideos;
        }

        public async Task<UsersVideos> Delete(UsersVideos usersVideos)
        {
            _dbContext.UsersVideos.Remove(usersVideos);
            await _dbContext.SaveChangesAsync();
            return usersVideos;
        }
    }
}
