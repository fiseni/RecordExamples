using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace RecordExamples.CustomerRecordIssues
{
    public static class CustomerRecordIssuesTests
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine("#################### Customer Record Issues #######################");
            Console.WriteLine();

            var customer1 = new Customer("Fati", "Iseni", 38);

            // This will bypass the validations in the constructor.
            // The "with" keyword won't use our defined constructors, instead it will use the automatically generated protected constructor "Customer(Customer original)"
            var customer2 = customer1 with
            {
                LastName = string.Empty
            };

            var customer3 = customer1 with { };

            var customer4 = customer1;

            Console.WriteLine("Customer1 ToString() output");
            Console.WriteLine(customer1.ToString());
            Console.WriteLine();

            Console.WriteLine("Customer2 ToString() output (LastName is empty, it bypassed the ctor validation)");
            Console.WriteLine(customer2.ToString());
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
        // In order to fix the issue with bypassing the validations in our ctor, we can implement full props, and apply validations here.
        // But, this works only for simple validation rules, where the only input for validation is the "value" itself.
        private string firstName;
        public string FirstName 
        { 
            get => firstName; 
            init
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));
                firstName = value;
            } 
        }

        public string LastName { get; init; }
        public int Age { get; init; }

        public Customer(string firstName, string lastName, int age)
        {
            // For more complex validations rules, where the rule requires several values and validates them as a group,
            // then, we can't really implement them with full properties.
            // We usually place them in the constructor, thus, they're be bypassed if "with" is used.
            if (!(firstName.Equals("Fati") && lastName.Equals("Iseni"))) throw new ArgumentException();

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}
