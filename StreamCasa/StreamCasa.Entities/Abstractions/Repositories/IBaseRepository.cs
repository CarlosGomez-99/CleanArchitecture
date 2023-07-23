using StreamCasa.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCasa.Entities.Abstractions.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : IEntity
    {
        public Task<TEntity> AddOrUpdate(TEntity entity);
        public Task<TEntity> Delete(TEntity entity);
    }
}
