using Domain.Interfaces.IGenerics;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUser
{
    public interface IUser : IGeneric<Users>
    {
        Task<IList<Users>> ListUsersByAccount(int id);
        Task RmoveUsers(List<Users> users);
        Task<Users> GetUserByEmail(string email);
    }
}
