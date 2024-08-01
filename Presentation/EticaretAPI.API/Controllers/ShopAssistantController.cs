using EticaretAPI.Application.Repositories;
using EticaretAPI.Application.ViewModels.ShopAssistant;
using EticaretAPI.Domain.Entities;
using EticaretAPI.Persistance.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EticaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopAssistantController: ControllerBase
    {
        readonly private IShopAssistantReadRepository _shopAssistantreadRepository;
        readonly private IShopAssistantWriteRepository _shopAssistantwriteRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ShopAssistantController(IShopAssistantReadRepository shopAssistantreadRepository, IShopAssistantWriteRepository shopAssistantwriteRepository, IWebHostEnvironment webHostEnvironment)
        {
            _shopAssistantreadRepository = shopAssistantreadRepository;
            _shopAssistantwriteRepository = shopAssistantwriteRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var totalCount = _shopAssistantreadRepository.GetAll(false).Count();
            var customers = _shopAssistantreadRepository.GetAll(false).Select(p => new
            {
                p.UserMail,
                p.Password
                
            }).ToList();

            return Ok(new
            {
                totalCount,
                customers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_ShopAssistant model)
        {
            await _shopAssistantwriteRepository.AddAsync(new()
            {
                UserMail = model.UserMail,
                Password = model.Password,
            });
            await _shopAssistantwriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _shopAssistantwriteRepository.RemoveAsync(id);
            await _shopAssistantwriteRepository.SaveAsync();
            return Ok();
        }
    }
}
