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
    internal class UsersRepository : IUsersRepository
    {
        private readonly StreamCasaDBContext _dbContext;

        public UsersRepository(StreamCasaDBContext context)
        {
            _dbContext = context;
        }

        public async Task<Users> Add(Users users)
        {
            if (users.Id != Guid.Empty)
            {
                _dbContext.Users.Update(users);
            }
            else
            {
                await _dbContext.Users.AddAsync(users);
            }
            await _dbContext.SaveChangesAsync();
            return users;
        }

        public async Task<Users> Delete(Users users)
        {
            _dbContext.Users.Remove(users);
            await _dbContext.SaveChangesAsync();
            return users;
        }

        public async Task<Users> GetByUsernameAndPassword(string username)
        {
            return await _dbContext.Users.Where(u => u.Name == username).FirstOrDefaultAsync();
        }
    }
}
