using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCasa.Entities.Abstractions.Repositories
{
    public interface IUsersRepository : IBaseRepository<Users>
    {
        public Task<Users> GetByUsernameAndPassword(Users users);
    }
}
