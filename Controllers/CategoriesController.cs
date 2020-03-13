using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Models;
using System.Threading.Tasks;
using AutoMapper;
using Supermarket.API.Resources;


namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            // map enumeration of categories to an enumeration of resources using the Map method
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }


        // FromBody attribute tells ASP.NET Core to parse the request body data into our new resource class.
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if(ModelState.IsValid){
                return BadRequest(ModelState.GetErrorMessages());
            }
        }


    }
}