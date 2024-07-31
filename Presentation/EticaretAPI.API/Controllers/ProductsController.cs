using EticaretAPI.Application.Abstractions.Storage;
using EticaretAPI.Application.Repositories;
using EticaretAPI.Application.RequestParameters;

using EticaretAPI.Application.ViewModels.Categories;
using EticaretAPI.Application.ViewModels.Products;
using EticaretAPI.Domain.Entities;
using EticaretAPI.Infrastructure.services.Storage;
using EticaretAPI.Persistance.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        readonly IFileWriteRepository _fileWriterepository;
        readonly IFileReadRepository _fileReadrepository;
        readonly IInvoiceFileWriteRepository _invoiceFileWriterepository;
        readonly IInvoiceFileReadRepository _invoiceFileReadrepository;
        readonly IProductImageFileWriteRepository _productImageFileWriterepository;
        readonly IProductImageFileReadRepository _productImageFileReadrepository;
        readonly IStorageService _storageService;
        public ProductsController(IProductWriteRepository productWriterepository,IStorageService storageService, IProductReadRepository productReadRepository, IWebHostEnvironment webHostEnvironment, IFileWriteRepository fileWriterepository, IFileReadRepository fileReadrepository, IInvoiceFileWriteRepository invoiceFileWriterepository, IInvoiceFileReadRepository invoiceFileReadrepository, IProductImageFileWriteRepository productImageFileWriterepository, IProductImageFileReadRepository productImageFileReadrepository)
        {
            _productsReadrepository = productReadRepository;
            this._webHostEnvironment = webHostEnvironment;
            _productsWriterepository = productWriterepository;
            _fileWriterepository = fileWriterepository;
            _fileReadrepository = fileReadrepository;
            _invoiceFileWriterepository = invoiceFileWriterepository;
            _invoiceFileReadrepository = invoiceFileReadrepository;
            _productImageFileWriterepository = productImageFileWriterepository;
            _productImageFileReadrepository = productImageFileReadrepository;
            _storageService = storageService;
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
        /*
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(int id)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", Request.Form.Files);

            Product product = await _productsReadrepository.GetByIdAsync(id);

            /*await _productImageFileWriterepository.AddRangeAsync(result.Select(r => new ProductImageFile
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                Products = new List<Product>() {product}
            }).ToList());*/
        /*
            await _productImageFileWriterepository.SaveAsync();

            return Ok();

            //var datas = await _storageService.UploadAsync("resource/files", Request.Form.Files);
            ////var datas = await _fileService.UploadAsync("resource/product-images", Request.Form.Files);
            //await _productImageFileWriterepository.AddRangeAsync(datas.Select(d => new ProductImageFile()
            //{

            //    FileName = d.fileName,
            //    Path = d.pathOrContainerName,
            //    Storage = _storageService.StorageName
            //}).ToList());
            //await _productImageFileWriterepository.SaveAsync();

            ////await _invoiceFileWriterepository.AddRangeAsync(datas.Select(d => new InvoiceFile()
            ////{
            ////    FileName = d.fileName,
            ////    Path = d.path,
            ////    Price = new Random().Next()
            ////}).ToList());
            ////await _invoiceFileWriterepository.SaveAsync();

            ////await _fileWriterepository.AddRangeAsync(datas.Select(d => new EticaretAPI.Domain.Entities.File()
            ////{
            ////    FileName = d.fileName,
            ////    Path = d.path
            ////}).ToList());
            ////await _fileWriterepository.SaveAsync();
            //return Ok();
        }/*d
        
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductImages(int id)
        {
            Product? product = await _productsReadrepository.Table.Include(p => p.ProductImageFiles).FirstOrDefaultAsync(p => p.Id == id);

            return Ok(product.ProductImageFiles.Select(p => new
            {
                p.Path,
                p.FileName
            }));
        }*/
    }
}
