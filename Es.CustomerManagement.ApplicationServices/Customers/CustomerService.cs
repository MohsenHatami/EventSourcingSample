using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Es.CustomerManagement.ApplicationServices.Customers.Dtoes;
using Es.CustomerManagement.Domain.Customers.Entities;
using Es.CustomerManagement.Domain.Customers.Repositories;

namespace Es.CustomerManagement.ApplicationServices.Customers
{
   public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<Guid> CreateCustomer(string firstName, string lastName)
        {
            var customer = Customer.CreateCustomer(firstName, lastName);
            var customerId = await _customerRepository.SaveAsync(customer);
            return customerId;
        }

        public async Task<Guid> UpdateCustomer(string customerId, string firstName, string lastName)
        {
            var customer = await _customerRepository.GetCustomer(Guid.Parse(customerId)); 
            customer.ChangeName(firstName,lastName);
            await _customerRepository.SaveAsync(customer);
            return customer.Id;
        }

        public async Task<CustomerDto> GetCustomer(string CustomerId)
        {
            var customer = await _customerRepository.GetCustomer(Guid.Parse(CustomerId));
            if (customer == null) return  new CustomerDto();

            return new CustomerDto()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                CustomerId = customer.Id.ToString(),
                Address = customer.CustomerAddress != null ? new AddressDto()
                {
                    Country = customer.CustomerAddress?.Country,
                    ZipCode = customer.CustomerAddress?.ZipCode,
                    City = customer.CustomerAddress?.City,
                    Street = customer.CustomerAddress?.Street,
                } : null
            };
        }

        public async Task UpdateAddress(string customerId, string city, string country, string street, string zipCode)
        {
            var customer = await _customerRepository.GetCustomer(Guid.Parse(customerId));
            if (customer == null) return;
            customer.ChangeAddress(street,country,zipCode,city);
            await _customerRepository.SaveAsync(customer); 
        }


    }
}
