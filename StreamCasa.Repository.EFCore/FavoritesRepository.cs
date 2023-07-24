using StreamCasa.Entities;
using StreamCasa.Entities.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCasa.Repository.EFCore
{
    internal class FavoritesRepository : IFavoritesRepository
    {
        private readonly StreamCasaDBContext _dbContext;

        public FavoritesRepository(StreamCasaDBContext context)
        {
            _dbContext = context;
        }

        public async Task<Favorites> Add(Favorites favorites)
        {
            if (favorites.Id != Guid.Empty)
            {
                _dbContext.Favorites.Update(favorites);
            }
            else
            {
                await _dbContext.Favorites.AddAsync(favorites);
            }
            await _dbContext.SaveChangesAsync();
            return favorites;
        }

        public async Task<Favorites> Delete(Favorites favorites)
        {
            _dbContext.Favorites.Remove(favorites);
            await _dbContext.SaveChangesAsync();
            return favorites;
        }
    }
}
