using System;
using System.Collections.Generic;

namespace SOLIDPrinciples.DIP.WithDIP
{
    // This example follows the Dependency Inversion Principle
    // High-level modules depend on abstractions, not concrete implementations
    
    // Customer model
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Abstraction for repository operations
    public interface ICustomerRepository
    {
        void SaveCustomer(Customer customer);
        List<Customer> GetAllCustomers();
    }

    // Low-level module implementing the abstraction (SQL Database)
    public class MySqlCustomerRepository : ICustomerRepository
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

    // Another implementation for the same abstraction (MongoDB)
    public class MongoCustomerRepository : ICustomerRepository
    {
        public void SaveCustomer(Customer customer)
        {
            Console.WriteLine($"Saving customer {customer.Name} to MongoDB database");
        }
        
        public List<Customer> GetAllCustomers()
        {
            Console.WriteLine("Getting all customers from MongoDB database");
            return new List<Customer> 
            { 
                new Customer { Id = 1, Name = "John Doe" },
                new Customer { Id = 2, Name = "Jane Smith" }
            };
        }
    }

    // High-level module depending on abstraction
    public class CustomerService
    {
        private readonly ICustomerRepository _repository; // Depends on abstraction

        // Dependency is injected through constructor
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public void AddCustomer(Customer customer)
        {
            _repository.SaveCustomer(customer);
        }

        public List<Customer> GetCustomers()
        {
            return _repository.GetAllCustomers();
        }
    }

    public class DIPDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("\n=== With DIP Example ===\n");
            
            Console.WriteLine("Using SQL Repository:");
            // Create service with SQL repository
            var sqlRepository = new MySqlCustomerRepository();
            var sqlCustomerService = new CustomerService(sqlRepository);
            
            // Add a new customer using SQL
            var newCustomer = new Customer { Id = 3, Name = "Bob Johnson" };
            sqlCustomerService.AddCustomer(newCustomer);
            
            // Get all customers using SQL
            var sqlCustomers = sqlCustomerService.GetCustomers();
            Console.WriteLine("\nCustomers from SQL:");
            foreach (var customer in sqlCustomers)
            {
                Console.WriteLine($"- {customer.Name}");
            }
            
            Console.WriteLine("\nUsing MongoDB Repository:");
            // Create service with MongoDB repository
            var mongoRepository = new MongoCustomerRepository();
            var mongoCustomerService = new CustomerService(mongoRepository);
            
            // Add a new customer using MongoDB
            mongoCustomerService.AddCustomer(newCustomer);
            
            // Get all customers using MongoDB
            var mongoCustomers = mongoCustomerService.GetCustomers();
            Console.WriteLine("\nCustomers from MongoDB:");
            foreach (var customer in mongoCustomers)
            {
                Console.WriteLine($"- {customer.Name}");
            }
            
            Console.WriteLine("\nThe CustomerService is loosely coupled from the repository implementation.");
            Console.WriteLine("We can easily switch between different database implementations.");
        }
    }
}
