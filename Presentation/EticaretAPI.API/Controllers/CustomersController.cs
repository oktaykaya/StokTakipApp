using EticaretAPI.Application.Abstractions.Storage;
using EticaretAPI.Application.Repositories;
using EticaretAPI.Application.RequestParameters;
using EticaretAPI.Application.ViewModels.Customers;
using EticaretAPI.Domain.Entities;
using EticaretAPI.Persistance.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EticaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController: ControllerBase
    {
        readonly private ICustomerReadRepository _customerReadRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        readonly private ICustomerWriteRepository _customerWriteRepository;

        public CustomersController(ICustomerReadRepository customerReadRepository, IWebHostEnvironment webHostEnvironment, ICustomerWriteRepository customerWriteRepository)
        {
            _customerReadRepository = customerReadRepository;
            _webHostEnvironment = webHostEnvironment;
            _customerWriteRepository = customerWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Pagination pagination)
        {
            var totalCount = _customerReadRepository.GetAll(false).Count();
            var customers = _customerReadRepository.GetAll(false).Select(p => new
            {
                p.Id,
                p.FirstName,
                p.LastName,
                p.Gender,
                p.Phone,
                p.Address,
                p.Tc,
                p.CreatedDate,
                p.UpdatedDate,
                p.BirthDate,
                p.Email
            }).ToList();

            return Ok(new
            {
                totalCount,
                customers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Customers model)
        {
            await _customerWriteRepository.AddAsync(new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                Phone = model.Phone,
                Address = model.Address,
                Tc = model.Tc,
                Email = model.Email,
                BirthDate = model.BirthDate,
            });
            await _customerWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Customers model)
        {
            Customer customer = await _customerReadRepository.GetByIdAsync(1);
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
           // customer.Gender = model.Gender;
            customer.Phone = model.Phone;
            customer.Address = model.Address;
            customer.Tc = model.Tc;
           // customer.Email = mode,
           // customer.BirthDate = model.BirthDate,
            await _customerWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerWriteRepository.RemoveAsync(id);
            await _customerWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
