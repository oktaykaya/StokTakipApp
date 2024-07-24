using EticaretAPI.Application.Repositories;
using EticaretAPI.Application.ViewModels.Categories;
using EticaretAPI.Application.ViewModels.Products;
using EticaretAPI.Domain.Entities;
using EticaretAPI.Persistance.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EticaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    
    public class ProductsController : ControllerBase
    {
        readonly private IProductReadRepository _productsReadrepository;
        readonly private IProductWriteRepository _productsWriterepository;

        public ProductsController(IProductWriteRepository productWriterepository, IProductReadRepository productReadRepository)
        {
            _productsReadrepository = productReadRepository;
            _productsWriterepository = productWriterepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
          return Ok( _productsReadrepository.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productsReadrepository.GetByIdAsync(id,false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Products model)
        {
            _productsWriterepository.AddAsync(new()
            {
                ProductName = model.ProductName,
                Feature1 = model.Feature1,
                Feature2 = model.Feature2,
                ProductCode = model.ProductCode,
                Price = model.Price,
                ManufactureDate = model.ManufactureDate,
                Quantity = model.Quantity
            });
            await _productsWriterepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Products model)
        {
            Product product = await _productsReadrepository.GetByIdAsync(model.Id);
            product.ProductName = model.ProductName;
            product.Feature1 = model.Feature1;
            product.Feature2 = model.Feature2;
            product.ProductCode = model.ProductCode;
            product.Price = model.Price;
            product.ManufactureDate = model.ManufactureDate;
            product.Quantity = model.Quantity;
            await _productsWriterepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(String id)
        {
            await _productsWriterepository.RemoveAsync(id);
            await _productsWriterepository.SaveAsync();
            return Ok();
        }

    }
}
