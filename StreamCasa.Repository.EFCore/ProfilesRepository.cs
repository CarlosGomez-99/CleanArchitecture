using StreamCasa.Entities;
using StreamCasa.Entities.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCasa.Repository.EFCore
{
    internal class ProfilesRepository : IProfilesRepository
    {
        private readonly StreamCasaDBContext _dbContext;

        public ProfilesRepository(StreamCasaDBContext context)
        {
            _dbContext = context;
        }

        public async Task<Profiles> Add(Profiles profiles)
        {
            if (profiles.Id != Guid.Empty)
            {
                _dbContext.Profiles.Update(profiles);
            }
            else
            {
                await _dbContext.Profiles.AddAsync(profiles);
            }
            await _dbContext.SaveChangesAsync();
            return profiles;
        }

        public async Task<Profiles> Delete(Profiles profiles)
        {
            _dbContext.Profiles.Remove(profiles);
            await _dbContext.SaveChangesAsync();
            return profiles;
        }
    }
}
