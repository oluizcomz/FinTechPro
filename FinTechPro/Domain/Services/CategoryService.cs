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
        private readonly ICategoryService iCategoryService;
        public CategoryService(ICategoryService iCategoryService) {
            this.iCategoryService = iCategoryService;
        }
        public async Task InsertCategory(Categories category)
        {
            var isValid = category.ValidatePropertyString(category.Name, "Name");
            if (isValid)
            {
                await iCategoryService.InsertCategory(category);
            }
        }

        public async Task UpdateCategory(Categories category)
        {
            var isValid = category.ValidatePropertyString(category.Name, "Name");
            if (isValid)
            {
                await iCategoryService.UpdateCategory(category);
            }
        }
    }
}
