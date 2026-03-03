using System;
using System.IO;

namespace SOLIDPrinciples.SRP.WithSRP
{
    // Following SRP by having each class handle a single responsibility
    
    // Only responsible for employee data
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
    }

    // Only responsible for persistence operations
    public class EmployeeRepository
    {
        public void SaveEmployee(Employee employee)
        {
            string content = $"{employee.Id},{employee.Name},{employee.Position},{employee.Salary}";
            File.WriteAllText($"employee_{employee.Id}.txt", content);
            Console.WriteLine($"Employee saved to file: employee_{employee.Id}.txt");
        }

        public Employee LoadEmployee(int id)
        {
            // Implementation would go here
            return null;
        }
    }

    // Only responsible for reporting
    public class EmployeeReportGenerator
    {
        public void PrintReport(Employee employee)
        {
            Console.WriteLine("Employee Report");
            Console.WriteLine("==============");
            Console.WriteLine($"ID: {employee.Id}");
            Console.WriteLine($"Name: {employee.Name}");
            Console.WriteLine($"Position: {employee.Position}");
            Console.WriteLine($"Salary: ${employee.Salary}");
        }
    }

    // Only responsible for salary calculations
    public class SalaryCalculator
    {
        public decimal CalculateAnnualSalary(Employee employee)
        {
            return employee.Salary * 12;
        }
    }

    // Only responsible for tax calculations
    public class TaxCalculator
    {
        public decimal CalculateTax(Employee employee)
        {
            SalaryCalculator salaryCalculator = new SalaryCalculator();
            decimal annualSalary = salaryCalculator.CalculateAnnualSalary(employee);
            
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
            Console.WriteLine("\n=== With SRP Example ===\n");
            
            // Create employee (only responsible for data)
            Employee employee = new Employee(1, "John Doe", "Software Developer", 5000);
            
            // Generate report (only responsible for reporting)
            EmployeeReportGenerator reportGenerator = new EmployeeReportGenerator();
            reportGenerator.PrintReport(employee);
            
            // Calculate salary (only responsible for salary calculations)
            SalaryCalculator salaryCalculator = new SalaryCalculator();
            Console.WriteLine($"Annual Salary: ${salaryCalculator.CalculateAnnualSalary(employee)}");
            
            // Calculate tax (only responsible for tax calculations)
            TaxCalculator taxCalculator = new TaxCalculator();
            Console.WriteLine($"Tax: ${taxCalculator.CalculateTax(employee)}");
            
            // Save employee (only responsible for persistence)
            EmployeeRepository repository = new EmployeeRepository();
            repository.SaveEmployee(employee);
        }
    }
}
