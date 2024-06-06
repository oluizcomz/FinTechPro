using Domain.Interfaces.IGenerics;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IExpense
{
    public interface IExpense : IGeneric<Expenses>
    {
        Task<IList<Expenses>> ListExpensesByUser(string emailUser);

        /// <summary>
        /// Get List Unpaid Expenses From Previous Months
        /// </summary>
        /// <param name="emailUser"></param>
        /// <returns></returns>
        Task<IList<Expenses>> ListUnpaidExpensesPrevious(string emailUser);

        Task<Expenses> GetExpensesByID(int id);
    }
}
