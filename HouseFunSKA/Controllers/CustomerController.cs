using HouseFunSKA.Models;
using HouseFunSKA.Services;
using HouseFunSKA.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HouseFunSKA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomer()
        {
            return Ok(await _customerService.GetCustomerAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<Customer>> GetCustomerById(string id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            var createdCustomer = await _customerService.CreateCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.CustomerID }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(Customer customer, string id)
        {
            var updatedCustomer = await _customerService.UpdateCustomerAsync(customer, id);
            if (updatedCustomer == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(string id)
        {
            var deletedCustomer = await _customerService.DeleteCustomerAsync(id);
            if (!deletedCustomer)
            {
                return NotFound();
            }

            return NoContent();
        }
        
    }
}