using Core.Entities;
using Core.Services.Imp;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _customerService.CreateCustomer(customer);

            return StatusCode(201);
        }


        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Customer customer) 
        {
            _customerService.UpdateCustomer(id, customer);

            return StatusCode(200);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id) 
        {
            _customerService.DeleteCustomer(id);

            return StatusCode(200);
        }
    }
}
