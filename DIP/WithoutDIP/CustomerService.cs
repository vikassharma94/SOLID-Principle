using System;
using System.Collections.Generic;

namespace SOLIDPrinciples.DIP.WithoutDIP
{
    // This example violates the Dependency Inversion Principle
    // High-level modules depend on low-level modules directly
    
    // Low-level module (database implementation)
    public class MySQLDatabase
    {
        public void SaveCustomer(Customer customer)
        {
            Console.WriteLine($"Saving customer {customer.Name} to SQL database");
        }
        
        public List<Customer> GetAllCustomers()
        {
            Console.WriteLine("Getting all customers from SQL database");
            return new List<Customer> 
            { 
                new Customer { Id = 1, Name = "John Doe" },
                new Customer { Id = 2, Name = "Jane Smith" }
            };
        }
    }

    // Customer model
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // High-level module (depends directly on the Database class)
    public class CustomerService
    {
        private MySQLDatabase _mySQLDatabase; // Direct dependency on concrete implementation

        public CustomerService()
        {
            // Direct instantiation of the dependency
            _mySQLDatabase = new MySQLDatabase();
        }

        public void AddCustomer(Customer customer)
        {
            // Directly using the Database implementation
            _mySQLDatabase.SaveCustomer(customer);
        }

        public List<Customer> GetCustomers()
        {
            // Directly using the Database implementation
            return _mySQLDatabase.GetAllCustomers();
        }
    }

    public class DIPDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("\n=== Without DIP Example ===\n");
            
            var customerService = new CustomerService();
            
            // Add a new customer
            var newCustomer = new Customer { Id = 3, Name = "Bob Johnson" };
            customerService.AddCustomer(newCustomer);
            
            // Get all customers
            var customers = customerService.GetCustomers();
            Console.WriteLine("\nCustomers:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"- {customer.Name}");
            }
            
            Console.WriteLine("\nThe problem is that CustomerService is tightly coupled to the Database class.");
            Console.WriteLine("If we want to change to a different database, we need to modify CustomerService.");
        }
    }
}
