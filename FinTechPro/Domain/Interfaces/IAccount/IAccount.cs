using Domain.Interfaces.IGenerics;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IAccount
{
    public interface IAccount : IGeneric<Accounts>
    {
        Task<IList<Accounts>> ListAccountsByUser(string emailUser);
    }
}
