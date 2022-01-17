using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace RecordExamples.CustomerRecord
{
    public static class CustomerRecordTests
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine("#################### Customer Record Class #######################");
            Console.WriteLine();

            var customer1 = new Customer
            {
                FirstName = "Fati",
                LastName = "Iseni",
                Age = 38
            };

            var customer2_StandardApproach = new Customer
            {
                FirstName = customer1.FirstName,
                LastName = customer1.LastName,
                Age = 40
            };
            // Same behavior, it will create new a Customer object using values from customer1, and then additionally will change the value for Age during initialization.
            var customer2 = customer1 with
            {
                Age = 40
            };

            var customer3_StandardApproach = new Customer
            {
                FirstName = customer1.FirstName,
                LastName = customer1.LastName,
                Age = customer1.Age
            };
            var customer3 = customer1 with { };

            var customer4 = customer1;

            // The deconstructor is available for records by default only if the short notation is used
            //(var firstName, var lastName, var age) = customer1;

            Console.WriteLine("Customer1 ToString() output");
            Console.WriteLine(customer1.ToString());
            Console.WriteLine();

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

    public record Customer
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int Age { get; init; }
    }

    // Records also provide short notation
    public record CustomerShortNotation(string Firstname, string Lastname, int Age);

    // It is same as writing this
    public record CustomerShortNotation_Expanded
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int Age { get; init; }

        public CustomerShortNotation_Expanded(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}
