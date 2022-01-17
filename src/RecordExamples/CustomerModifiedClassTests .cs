using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace RecordExamples.CustomerModifiedClass
{
    public static class CustomerModifiedClassTests
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine("#################### Customer Modified Class #######################");
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
            var customer2Alternative = new Customer(customer1)
            {
                Age = 40
            };

            var customer3 = new Customer
            {
                FirstName = customer1.FirstName,
                LastName = customer1.LastName,
                Age = customer1.Age
            };
            var customer3Alternative = new Customer(customer1);

            var customer4 = customer1;

            (var firstName, var lastName, var age) = customer1;

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

    public class Customer
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int Age { get; init; }

        public Customer()
        {
        }

        // Constructor used to create copies.
        public Customer(Customer customer)
        {
            this.FirstName = customer.FirstName;
            this.LastName = customer.LastName;
            this.Age = customer.Age;
        }

        public override string ToString()
        {
            return "Customer { FirstName = " + FirstName + ", LastName = " + LastName + ", Age = " + Age +"}";
        }

        public static bool operator ==(Customer left, Customer right)
        {
            return (object)left == right || ((object)left != null && left.Equals(right));
        }

        public static bool operator !=(Customer left, Customer right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj is not Customer customer)
            {
                return false;
            }
            else 
            {
                return
                    this.FirstName.Equals(customer.FirstName) &&
                    this.LastName.Equals(customer.LastName) &&
                    this.Age.Equals(customer.Age);
            }
        }

        public override int GetHashCode()
        {
            var hashcode = new HashCode();
            hashcode.Add(FirstName);
            hashcode.Add(LastName);
            hashcode.Add(Age);

            return hashcode.ToHashCode();
        }

        public void Deconstruct(out string FirstName, out string LastName, out int Age)
        {
            FirstName = this.FirstName;
            LastName = this.LastName;
            Age = this.Age;
        }
    }
}
