using Domain.Interfaces.IGenerics;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ICategory
{
    public interface ICategory : IGeneric<Categories>
    {
        Task<IList<Categories>> ListCategoriesByUser(string emailUser);
    }
}
