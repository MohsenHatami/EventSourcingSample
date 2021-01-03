
using Es.CustomerManagement.Domain.Customers.DomainEvents;
using Es.CustomerManagement.Domain.Customers.ValueObjects;
using Es.Framework;
using System;
using System.Collections.Generic;

namespace Es.CustomerManagement.Domain.Customers.Entities
{
    public class Customer : AggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address CustomerAddress { get; set; }

        public Customer(IEnumerable<IDomainEvent> events) : base(events)
        {
        }

        private Customer()
        {
        }

        public static Customer CreateCustomer(string firstName, string lastName)
        {
            var customer = new Customer();
            customer.Apply(new CustomerCreated(Guid.NewGuid().ToString(), firstName, lastName));
            return customer;
        }

        public void ChangeName(string firsName, string lastName)
        {
            Apply(new CustomerNameChanged(Id.ToString(),firsName,lastName));
        }

        public void ChangeAddress(string street, string country, string zipCode, string city)
        {
            Apply(new AddressChanged(Id.ToString(),city,country,zipCode,street));
        }


        public void On(CustomerCreated @event)
        {
            Id = Guid.Parse(@event.CustomerId);
            FirstName = @event.Firstname;
            LastName = @event.LastName;
        }

        public void On(CustomerNameChanged @event)
        {
            Id = Guid.Parse(@event.CustomerId);
            FirstName = @event.FirstName;
            LastName = @event.LastName; 
        }

        public void On(AddressChanged @event)
        {
            CustomerAddress = new Address()
            {
                Country = @event.Country,
                ZipCode = @event.ZipCode,
                City =@event.City,
                Street = @event.Street
            };
        }

    }
}
