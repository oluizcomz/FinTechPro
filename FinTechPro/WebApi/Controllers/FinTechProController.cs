using Domain.Interfaces.IAccount;
using Domain.Interfaces.IAccountService;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
   [Route("api/[controller]")]
        [ApiController]
        [Authorize]
        public class FinTechProController : ControllerBase
        {
            private readonly IAccount account;
            private readonly IAccountService accountService;
            public FinTechProController(IAccount account,
                IAccountService accountService)
            {
                this.account = account;
                this.accountService = accountService;
            }

            [HttpGet("/api/accounts")]
            [Produces("application/json")]
            public async Task<object> ListUsers(string emailUsuario)
            {
                return await account.ListAccountsByUser(emailUsuario);
            }

            [HttpPost("/api/account")]
            [Produces("application/json")]
            public async Task<object> InsertAccount(Accounts account)
            {
                await accountService.InsertAccount(account);

                return Task.FromResult(account);
            }

            [HttpPut("/api/account")]
            [Produces("application/json")]
            public async Task<object> UpdateAccount(Accounts account)
            {
                await accountService.UpdateAccount(account);

                return Task.FromResult(account);
            }


            [HttpGet("/api/account")]
            [Produces("application/json")]
            public async Task<object> GetAccount(int id)
            {
                return await account.GetEntityById(id);
            }


            [HttpDelete("/api/account")]
            [Produces("application/json")]
            public async Task<object> DeleteAccount(int id)
            {
                try
                {
                    var user = await account.GetEntityById(id);

                    await account.Delete(user);
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }


        }
    
}
