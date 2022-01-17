using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace RecordExamples.CustomerRecordWithCollection
{
    public static class CustomerRecordWithCollectionTests
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine("#################### Customer Record Class with Collection#######################");
            Console.WriteLine();

            var address1 = new Address { Street = "Street1" };
            var address2 = new Address { Street = "Street2" };
            var address3 = new Address { Street = "Street1" };

            var address1List = new ValueList<Address> { address1 };
            var address2List = new ValueList<Address> { address2 };
            var address3List = new ValueList<Address> { address3 };

            var customer1 = new Customer
            {
                FirstName = "Fati",
                LastName = "Iseni",
                Age = 38,
                Addresses = address1List
            };

            var customer2 = customer1 with
            {
                Addresses = address2List
            };

            var customer3 = customer1 with
            {
                Addresses = address3List
            };

            var customer4 = customer1 with
            {
                Addresses = address1List
            };

            Console.WriteLine("Customer1 ToString() output");
            Console.WriteLine(customer1.ToString());
            Console.WriteLine();

            Console.WriteLine("Customers: same values, Collection: different instance, different values");
            Console.WriteLine($"Using ReferenceEquals: {ReferenceEquals(customer1, customer2)}");
            Console.WriteLine($"Using Equals: {customer1.Equals(customer2)}");
            Console.WriteLine($"Using '==': {customer1 == customer2}");
            Console.WriteLine();

            Console.WriteLine("Customers: same values, Collection: different instance, same values");
            Console.WriteLine($"Using ReferenceEquals: {ReferenceEquals(customer1, customer3)}");
            Console.WriteLine($"Using Equals: {customer1.Equals(customer3)}");
            Console.WriteLine($"Using '==': {customer1 == customer3}");
            Console.WriteLine();

            Console.WriteLine("Customers: same values, Collection: same instance");
            Console.WriteLine($"Using ReferenceEquals: {ReferenceEquals(customer1, customer4)}");
            Console.WriteLine($"Using Equals: {customer1.Equals(customer4)}");
            Console.WriteLine($"Using '==': {customer1 == customer4}");
            Console.WriteLine();
        }
    }

    public record Customer
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int Age { get; init; }

        public ValueList<Address> Addresses { get; init; }
    }

    public record Address
    {
        public string Street { get; init; }
    }
}
