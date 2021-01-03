using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Es.CustomerManagement.Domain.Customers.Entities;

namespace Es.CustomerManagement.Domain.Customers.Repositories
{
   public interface ICustomerRepository
    {
        Task<Guid> SaveAsync(Customer customer);
        Task<Customer> GetCustomer(Guid id);

    }
}
