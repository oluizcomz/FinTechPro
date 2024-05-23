using Domain.Interfaces.IAccountService;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AccountService
{
    public class AccountService : IAccountService
    {
        public Task InsertAccount(Accounts account)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAccount(Accounts account)
        {
            throw new NotImplementedException();
        }
    }
}
