using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IAccountService
{
    public interface IAccountService
    {
        Task InsertAccount(Accounts account);
        Task UpdateAccount(Accounts account);
    }
}
