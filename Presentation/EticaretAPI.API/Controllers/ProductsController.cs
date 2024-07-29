using EticaretAPI.Application.Repositories;
using EticaretAPI.Application.RequestParameters;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        readonly private IProductWriteRepository _productsWriterepository;

        public ProductsController(IProductWriteRepository productWriterepository, IProductReadRepository productReadRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productsReadrepository = productReadRepository;
            this._webHostEnvironment = webHostEnvironment;
            _productsWriterepository = productWriterepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Pagination pagination)
        {
            var totalCount = _productsReadrepository.GetAll(false).Count();
            var products = _productsReadrepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
            {
                p.Id,
                p.CategoryId,
                p.ProductCode,
                p.ProductName,
                p.Price,
                p.ManufactureDate,
                p.Quantity,
                p.Feature1,
                p.Feature2,
                p.CreatedDate,
                p.UpdatedDate
            }).ToList();

          return Ok(new
          {
              totalCount,
              products
          });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _productsReadrepository.GetByIdAsync(id,false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Products model)
        {
            await _productsWriterepository.AddAsync(new()
            {
                ProductName = model.ProductName,
                Feature1 = model.Feature1,
                Feature2 = model.Feature2,
                ProductCode = model.ProductCode,
                Price = model.Price,
                ManufactureDate = model.ManufactureDate,
                Quantity = model.Quantity,
                CategoryId = model.CategoryId
              
            });
            await _productsWriterepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Products model)
        {
            Product product = await _productsReadrepository.GetByIdAsync(39);
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
        public async Task<IActionResult> Delete(int id)
        {
            await _productsWriterepository.RemoveAsync(id);
            await _productsWriterepository.SaveAsync();
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/prooduct-images");

            if(!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            Random r = new Random();
            foreach(IFormFile file in Request.Form.Files)
            {
                string fullPath = Path.Combine(uploadPath, $"{r.Next()}{Path.GetExtension(file.FileName)}");

                using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
            return Ok();
        }

    }
}
