using Domain.Interfaces.ICategory;
using Domain.Interfaces.ICategoryService;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategory iCategory;
        public CategoryService(ICategory iCategory) {
            this.iCategory = iCategory;
        }
        public async Task InsertCategory(Categories category)
        {
            var isValid = category.ValidatePropertyString(category.Name, "Name");
            if (isValid)
            {
                await iCategory.Insert(category);
            }
        }

        public async Task UpdateCategory(Categories category)
        {
            var isValid = category.ValidatePropertyString(category.Name, "Name");
            if (isValid)
            {
                await iCategory.Update(category);
            }
        }
    }
}
