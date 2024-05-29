using Domain.Interfaces.IUser;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUserService
{
    public interface IUserService
    {
        Task InsertUser(Users user);

    }
}
