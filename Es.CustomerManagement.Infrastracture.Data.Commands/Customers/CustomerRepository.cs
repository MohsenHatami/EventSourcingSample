using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Es.CustomerManagement.Domain.Customers.Entities;
using Es.CustomerManagement.Domain.Customers.Repositories;
using Es.Framework;

namespace Es.CustomerManagement.Infrastracture.Data.Commands.Customers
{
   public class CustomerRepository : ICustomerRepository
    {
        private readonly IEventStore _eventStore;

        public CustomerRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }
        public async Task<Guid> SaveAsync(Customer customer)
        {
             await _eventStore.SaveAsync(customer.Id, customer.GetType().Name, customer.Version,
                customer.DomainEvents);
            return customer.Id; 
        }

        public async Task<Customer> GetCustomer(Guid id)
        {
            var customerEvents = await _eventStore.LoadAsync(id, typeof(Customer).Name); 
            return  new Customer(customerEvents);
        }
    }
}
