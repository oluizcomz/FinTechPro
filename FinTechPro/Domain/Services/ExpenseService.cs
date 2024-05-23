using Domain.Interfaces.ICategoryService;
using Domain.Interfaces.IExpense;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IExpenseService
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseService iExpenseService;
        public ExpenseService(IExpenseService iExpenseService)
        {
            this.iExpenseService = iExpenseService;
        }
        public async Task InsertExpense(Expenses expense)
        {
            expense.CreatedDate =  DateTime.Now;
            expense.Month = expense.CreatedDate.Month;
            expense.Year = expense.CreatedDate.Year;
            var isValid = expense.ValidatePropertyString(expense.Name, "Name");
            if (isValid)
            {
                await iExpenseService.InsertExpense(expense);
            }
        }

        public Task UpdateExpense(Expenses expense)
        {
            throw new NotImplementedException();
        }
    }
}
