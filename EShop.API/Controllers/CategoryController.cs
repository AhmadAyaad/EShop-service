using EShop.Core.IService;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace EShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                return Ok(await _categoryService.GetCategoriesAsync());
            }
            catch (System.Exception)
            {
                //TODO : Log exception
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while retreving all categories.");
            }
        }
    }
}
