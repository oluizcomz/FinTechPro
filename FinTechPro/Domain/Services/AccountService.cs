using Domain.Interfaces.IAccount;
using Domain.Interfaces.IAccountService;
using Domain.Interfaces.ICategory;
using Domain.Interfaces.IExpense;
using Domain.Interfaces.IExpenseService;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAccount iAccount;
        public AccountService(IAccount iAccount)
        {
            this.iAccount = iAccount;
        }
        public async Task InsertAccount(Accounts account)
        {
            DateTime data = DateTime.Now;

            account.ClosingDate = 1;
            account.Year = data.Year;
            account.Month = data.Month;
            account.YearCopy = data.Year;
            account.MonthCopy = data.Month;
            account.IsGeneratedCopy = true;
            var isValid = account.ValidatePropertyString(account.Name, "Name");
            if (isValid)
            {
                await iAccount.Insert(account);
            }
        }

        public async Task UpdateAccount(Accounts account)
        {
            DateTime data = DateTime.Now;

            var isValid = account.ValidatePropertyString(account.Name, "Name");
            if (isValid)
            {

                account.ClosingDate = 1;
                await iAccount.Update(account);
            }
        }
    }
}
