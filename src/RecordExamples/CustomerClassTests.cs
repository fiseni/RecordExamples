using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordExamples.CustomerClass
{
    public static class CustomerClassTests
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine("#################### Customer Class #######################");
            Console.WriteLine();

            var customer1 = new Customer
            {
                FirstName = "Fati",
                LastName = "Iseni",
                Age = 38
            };

            var customer2 = new Customer
            {
                FirstName = customer1.FirstName,
                LastName = customer1.LastName,
                Age = 40
            };

            var customer3 = new Customer
            {
                FirstName = customer1.FirstName,
                LastName = customer1.LastName,
                Age = customer1.Age
            };

            var customer4 = customer1;

            Console.WriteLine("Customers: different instances, different values");
            Console.WriteLine($"Using ReferenceEquals: {ReferenceEquals(customer1, customer2)}");
            Console.WriteLine($"Using Equals: {customer1.Equals(customer2)}");
            Console.WriteLine($"Using '==': {customer1 == customer2}");
            Console.WriteLine();

            Console.WriteLine("Customers: different instances, same values");
            Console.WriteLine($"Using ReferenceEquals: {ReferenceEquals(customer1, customer3)}");
            Console.WriteLine($"Using Equals: {customer1.Equals(customer3)}");
            Console.WriteLine($"Using '==': {customer1 == customer3}");
            Console.WriteLine();

            Console.WriteLine("Customers: same instance");
            Console.WriteLine($"Using ReferenceEquals: {ReferenceEquals(customer1, customer4)}");
            Console.WriteLine($"Using Equals: {customer1.Equals(customer4)}");
            Console.WriteLine($"Using '==': {customer1 == customer4}");
            Console.WriteLine();
        }
    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        // Just to demonstrate that hashcode doesn't affect the equality.
        // It represent the whole number identification for objects, and it's used by various constracts (e.g. Dictionary) to easily identify the objects.
        // For instance, the Dictionary<object, object> will internally store the hashcode of the object as a key, not the object itself.
        // Generally (almost always), if Equals method returns true, the hashcode should be same as well. Otherwise, we'll get unexpected behavior from the constructs that make use of the hashcode.
        public override int GetHashCode()
        {
            return 1;
        }
    }
}
