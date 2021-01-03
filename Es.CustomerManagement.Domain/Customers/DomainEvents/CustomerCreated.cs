using System;
using System.Collections.Generic;
using System.Text;
using Es.Framework;

namespace Es.CustomerManagement.Domain.Customers.DomainEvents
{
   public class CustomerCreated : IDomainEvent
    {
        public string Firstname { get; }
        public string LastName { get;  }
        public string CustomerId { get;  }

        public CustomerCreated(string customerId, string firstname, string lastName)
        {
            CustomerId = customerId;
            Firstname = firstname;
            LastName = lastName; 
        }
    }
}
