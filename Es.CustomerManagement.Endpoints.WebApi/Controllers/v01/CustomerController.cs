using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Es.CustomerManagement.ApplicationServices.Customers;
using Es.CustomerManagement.ApplicationServices.Customers.Dtoes;

namespace Es.CustomerManagement.Endpoints.WebApi.Controllers.v01
{
    [ApiController]
    [Route("v01/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<object> CreateCustomer([FromBody] SaveCustomerDto customer)
        {
            var insertedCustomerId = await _customerService.CreateCustomer(customer.FirstName, customer.LastName);
            return new { PersonId = insertedCustomerId.ToString() };
        }

        [HttpPost]
        public async Task UpdateCustomer([FromQuery] string customerId, [FromBody] SaveCustomerDto customer)
        {
            await _customerService.UpdateCustomer(customerId, customer.FirstName, customer.LastName);
            Ok();
        }

        [HttpPost]

        public async Task ChangeAddress(
            [FromQuery] string customerId,
            [FromBody] AddressDto address)
        {
            await _customerService.UpdateAddress(customerId, address.City, address.Country, address.Street, address.ZipCode);
            Ok();
        }

        [HttpGet]
        public async Task<CustomerDto> GetCustomer([FromQuery] string customerId)
        {
            return await _customerService.GetCustomer(customerId);
        }

    }
}
