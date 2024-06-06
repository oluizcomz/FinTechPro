using Domain.Interfaces.ICategory;
using Domain.Interfaces.ICategoryService;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Authorize]
        [Route("api/[controller]")]
        [ApiController]
        public class CategoryController : ControllerBase
        {

            private readonly ICategory iCategory;
            private readonly ICategoryService iCategoriaServico;

            public CategoryController(ICategory iCategory, ICategoryService iCategoriaServico)
            {
                this.iCategory = iCategory;
                this.iCategoriaServico = iCategoriaServico;
            }

            [HttpGet("/api/categories")]
            [Produces("application/json")]
            public async Task<object> ListCategories(string emailUsuario)
            {
                return await iCategory.ListCategoriesByUser(emailUsuario);
            }

            [HttpPost("/api/category")]
            [Produces("application/json")]
            public async Task<object> InsertCategory(Categories category)
            {
                await iCategoriaServico.InsertCategory(category);

                return category;
            }

            [HttpPut("/api/category")]
            [Produces("application/json")]
            public async Task<object> Updatecategory(Categories category)
            {
                await iCategoriaServico.UpdateCategory(category);

                return category;
            }

            [HttpGet("/api/category")]
            [Produces("application/json")]
            public async Task<object> GetCategory(int id)
            {
                return await iCategory.GetEntityById(id);
            }


            [HttpDelete("/api/category")]
            [Produces("application/json")]
            public async Task<object> DeleteCategory(int id)
            {
                try
                {
                    var categoria = await iCategory.GetEntityById(id);
                    await iCategory.Delete(categoria);

                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }



        }
    
}
