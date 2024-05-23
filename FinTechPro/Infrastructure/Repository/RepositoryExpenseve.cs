using Domain.Interfaces.IExpense;
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
    public class RepositoryExpense : RepositoryGenerics<Expenses>, IExpense
    {
        private readonly DbContextOptions<ContextBase> optionsBuilder;
        public RepositoryExpense()
        {
            optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<Expenses>> ListExpensesByUser(string emailUser)
        {
            using (var bd = new ContextBase(optionsBuilder))
            {
                return await
                    (from account in bd.Account
                     join category in bd.Category on account.Id equals category.IdAccount
                     join user in bd.User on category.Id equals user.IdAccount
                     join expense in bd.Expense on category.Id equals expense.IdCategory
                     where user.Email.Equals(emailUser) && expense.Month == account.Month && expense.Year == account.Year
                     select expense).AsNoTracking().ToListAsync();
            }
        }

            public async Task<IList<Expenses>> ListUnpaidExpensesPrevious(string emailUser)
        {
            using (var bd = new ContextBase(optionsBuilder))
            {
                return await
                    (from account in bd.Account
                     join category in bd.Category on account.Id equals category.IdAccount
                     join user in bd.User on category.Id equals user.IdAccount
                     join expense in bd.Expense on category.Id equals expense.IdCategory
                     where user.Email.Equals(emailUser) && (expense.Month < DateTime.Now.Month || expense.Year < DateTime.Now.Year) && !expense.IsPaid
                     select expense).AsNoTracking().ToListAsync();
            }
        }
    }
}
