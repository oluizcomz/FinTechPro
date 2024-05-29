using Domain.Interfaces.IUser;
using Domain.Interfaces.IUserService;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        [Authorize]
        public class UserAccountController : ControllerBase
        {
            private readonly IUser iUser;
            private readonly IUserService iUserService;
            public UserAccountController(IUser iUser,
                IUserService iUserService)
            {
                this.iUser = iUser;
                this.iUserService = iUserService;
            }

            [HttpGet("/api/users")]
            [Produces("application/json")]
            public async Task<object> ListUsers(int id)
            {
                return await iUser.ListUsersByAccount(id);
            }


            [HttpPost("/api/user")]
            [Produces("application/json")]
            public async Task<object> InsertUser(int idAccount, string email)
            {
                try
                {
                    await iUserService.InsertUser(
                       new Users
                       {
                           Id = idAccount,
                           Email = email,
                           Admin = false,
                           IsCurrentAccount = true
                       });
                }
                catch (Exception)
                {
                    return Task.FromResult(false);
                }

                return Task.FromResult(true);

            }

            [HttpDelete("/api/user")]
            [Produces("application/json")]
            public async Task<object> DeleteUser(int id)
            {
                try
                {
                    var user = await iUser.GetEntityById(id);

                    await iUser.Delete(user);
                }
                catch (Exception)
                {
                    return Task.FromResult(false);
                }

                return Task.FromResult(true);

            }
        }
}
