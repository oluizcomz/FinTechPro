using Domain.Interfaces.IAccount;
using Domain.Interfaces.ICategory;
using Domain.Interfaces.IUser;
using Domain.Interfaces.IUserService;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUser iUser;
        public UserService(IUser iUser)
        {
            this.iUser = iUser;
        }

        public async Task InsertUser(Users user)
        {
                await iUser.Insert(user);
        }
    }
}
