using EticaretAPI.Application.Repositories;
using EticaretAPI.Domain.Entities;
using EticaretAPI.Persistance.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EticaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    
    public class ProductsController : ControllerBase
    {
        readonly private ICategoryReadRepository _categoryReadrepository;
        readonly private ICategoryWriteRepository _categoryWriterepository;

        public ProductsController(ICategoryWriteRepository categoryWriterepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadrepository= categoryReadRepository;
            _categoryWriterepository= categoryWriterepository;
        }

        [HttpGet]
        public async Task Get()
        {
            await _categoryWriterepository.AddRangeAsync(new()
            {
                new() { CategoryName = "table"},
                new() { CategoryName = "laptop"},
                new() { CategoryName = "television"},
                new() { CategoryName = "modem"}
            });
            var count = await _categoryWriterepository.SaveAsync();

        }
    }
}
