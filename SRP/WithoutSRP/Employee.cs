using System;
using System.IO;

namespace SOLIDPrinciples.SRP.WithoutSRP
{
    // This class violates SRP because it has multiple responsibilities:
    // 1. Managing employee data
    // 2. Formatting and printing reports
    // 3. Saving data to a file
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public Employee(int id, string name, string position, decimal salary)
        {
            Id = id;
            Name = name;
            Position = position;
            Salary = salary;
        }

        public void SaveToFile()
        {
            string content = $"{Id},{Name},{Position},{Salary}";
            File.WriteAllText($"employee_{Id}.txt", content);
            Console.WriteLine($"Employee saved to file: employee_{Id}.txt");
        }

        public void PrintReport()
        {
            Console.WriteLine("Employee Report");
            Console.WriteLine("==============");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Position: {Position}");
            Console.WriteLine($"Salary: ${Salary}");
        }

        public decimal CalculateAnnualSalary()
        {
            return Salary * 12;
        }

        public decimal CalculateTax()
        {
            decimal annualSalary = CalculateAnnualSalary();
            
            // Simple tax calculation logic
            if (annualSalary < 30000)
                return annualSalary * 0.1m;
            else if (annualSalary < 70000)
                return annualSalary * 0.2m;
            else
                return annualSalary * 0.3m;
        }
    }

    public class EmployeeDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("\n=== Without SRP Example ===\n");
            
            Employee employee = new Employee(1, "John Doe", "Software Developer", 5000);
            
            // One class handling multiple responsibilities
            employee.PrintReport();
            Console.WriteLine($"Annual Salary: ${employee.CalculateAnnualSalary()}");
            Console.WriteLine($"Tax: ${employee.CalculateTax()}");
            employee.SaveToFile();
        }
    }
}
