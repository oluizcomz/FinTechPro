using Domain.Interfaces.ICategory;
using Entities;
using Infrastructure.Persistence;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generics
{
    public class RepositoryCategory : RepositoryGenerics<Categories>, ICategory
    {
        private readonly DbContextOptions<ContextBase> optionsBuilder;
        public RepositoryCategory() {
            optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<Categories>> ListCategoriesByUser(string emailUser)
        {
            using (var bd = new ContextBase(optionsBuilder)) 
            {
                return await
                    (from account in bd.Account
                     join category in bd.Category on account.Id equals category.IdAccount
                     join user in bd.User on category.Id equals user.IdAccount
                     where user.Email.Equals(emailUser) && user.IsCurrentAccount
                     select category).AsNoTracking().ToListAsync();
            }
        }
    }
}
