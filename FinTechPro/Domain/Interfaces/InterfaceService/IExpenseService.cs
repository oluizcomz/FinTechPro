using Domain.Interfaces.IExpense;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IExpenseService
{
    public interface IExpenseService
    {
        Task InsertExpense(Expenses expense);
        Task UpdateExpense(Expenses expense, bool wasPaid);
        Task<object> LoadsGraphics(string emailUser);
    }
}
