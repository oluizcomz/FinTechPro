using Domain.Interfaces.IExpense;
using Domain.Interfaces.IExpenseService;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
        [Authorize]
        [Route("api/[controller]")]
        [ApiController]
        public class ExpenseController : ControllerBase
        {
            private readonly IExpense iExpense;
            private readonly IExpenseService iExpenseService;
            public ExpenseController(IExpense iExpense, IExpenseService iExpenseService)
            {
                this.iExpense = iExpense;
                this.iExpenseService = iExpenseService;
            }

            [HttpGet("/api/expenses")]
            [Produces("application/json")]
            public async Task<object> ListExpenses(string email)
            {
                return await iExpense.ListExpensesByUser(email);
            }

            [HttpPost("/api/expense")]
            [Produces("application/json")]
            public async Task<object> AdicionarDespesa(Expenses expense)
            {
                await iExpenseService.InsertExpense(expense);

                return expense;

            }

            [HttpPut("/api/expense")]
            [Produces("application/json")]
            public async Task<object> AtualizarDespesa(Expenses expense)
            {
                var expenseExist = await iExpense.GetEntityById(expense.Id);
                await iExpenseService.UpdateExpense(expense, expenseExist.IsPaid);

                return expense;

            }


            [HttpGet("/api/expense")]
            [Produces("application/json")]
            public async Task<object> GetExpense(int id)
            {
                return await iExpense.GetEntityById(id);
            }


            [HttpDelete("/api/expense")]
            [Produces("application/json")]
            public async Task<object> DeleteExpense(int id)
            {
                try
                {
                    var categoria = await iExpense.GetEntityById(id);
                    await iExpense.Delete(categoria);

                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }

            [HttpGet("/api/loadsGraphics")]
            [Produces("application/json")]
            public async Task<object> LoadsGraphics(string emailUsuario)
            {
                return await iExpenseService.LoadsGraphics(emailUsuario);
            }


        }
}
