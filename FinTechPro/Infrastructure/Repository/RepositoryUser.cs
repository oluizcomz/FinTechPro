using Domain.Interfaces.ICategory;
using Domain.Interfaces.IUser;
using Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generics
{
    public class RepositoryUser : RepositoryGenerics<Users>, IUser
    {
        private readonly DbContextOptions<ContextBase> optionsBuilder;
        public RepositoryUser()
        {
            optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<Users> GetUserByEmail(string email)
        {
            using (var bd = new ContextBase(optionsBuilder))
            {
                return await bd.User.Where(user => user.Email == email)
                    .AsNoTracking().FirstOrDefaultAsync();
            }
        }

        public async Task<IList<Users>> ListUsersByAccount(int id)
        {
            using (var bd = new ContextBase(optionsBuilder))
            {
                return await bd.User.Where(user => user.IdAccount == id)
                    .AsNoTracking().ToListAsync();
            }
        }

        public async Task RmoveUsers(List<Users> users)
        {
            using (var bd = new ContextBase(optionsBuilder))
            {
                bd.User.RemoveRange(users);
                await bd.SaveChangesAsync();
            }
        }
    }
}
