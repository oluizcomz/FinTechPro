using Domain.Interfaces.IExpense;
using Domain.Interfaces.IExpenseService;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.ExpenseService
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpense iExpense;
        public ExpenseService(IExpense iExpenseService)
        {
            this.iExpense = iExpenseService;
        }
        public async Task InsertExpense(Expenses expense)
        {
            expense.CreatedDate =  DateTime.Now;
            expense.Month = expense.CreatedDate.Month;
            expense.Year = expense.CreatedDate.Year;
            var isValid = expense.ValidatePropertyString(expense.Name, "Name");
            if (isValid)
            {
                await iExpense.Insert(expense);
            }
        }

        public async Task UpdateExpense(Expenses expense, bool wasPaid)
        {
            Expenses expenseBefore = await iExpense.GetExpensesByID(expense.Id);
            expense.UpdateDate = DateTime.Now;

            if (expense.IsPaid && !expenseBefore.IsPaid)
            {
                expense.DueDate = expense.UpdateDate;
            }
            else if(!expense.IsPaid && expenseBefore.IsPaid)
            {
                expense.DueDate = null;
            }

            var isValid = expense.ValidatePropertyString(expense.Name, "Name");
            if (isValid)
            {
                await iExpense.Update(expense);
            }
        }
        public async Task<object> LoadsGraphics(string emailUser)
        {
            var despesasUsuario = await iExpense.ListExpensesByUser(emailUser);
            var despesasAnterior = await iExpense.ListUnpaidExpensesPrevious(emailUser);

            var despesas_naoPagasMesesAnteriores = despesasAnterior.Any() ?
                despesasAnterior.ToList().Sum(x => x.Value) : 0;

            var despesas_pagas = despesasUsuario.Where(d => d.IsPaid && d.ExpenseType == Entities.Enums.ExpensesType.Payment)
                .Sum(x => x.Value);

            var despesas_pendentes = despesasUsuario.Where(d => !d.IsPaid && d.ExpenseType == Entities.Enums.ExpensesType.Payment)
                .Sum(x => x.Value);

            var investimentos = despesasUsuario.Where(d => d.ExpenseType == Entities.Enums.ExpensesType.Investment)
                .Sum(x => x.Value);

            return new
            {
                sucesso = "OK",
                despesas_pagas = despesas_pagas,
                despesas_pendentes = despesas_pendentes,
                despesas_naoPagasMesesAnteriores = despesas_naoPagasMesesAnteriores,
                investimentos = investimentos
            };

        }
    }
}
