# SOLID Principles Documentation

## Single Responsibility Principle (SRP)

**Definition**: A class should have only one reason to change, meaning it should have only one responsibility.

**Example Explanation**:
- **Without SRP**: The `Employee` class handles multiple responsibilities:
  - Managing employee data
  - Formatting and printing reports
  - Saving data to a file
  - Calculating salaries and taxes
  
  This violates SRP because any change to any of these responsibilities requires modifying the same class.

- **With SRP**: Responsibilities are separated into distinct classes:
  - `Employee`: Only manages employee data
  - `EmployeeRepository`: Handles data persistence
  - `EmployeeReportGenerator`: Handles report generation
  - `SalaryCalculator`: Handles salary calculations
  - `TaxCalculator`: Handles tax calculations
  
  Each class has a single reason to change, adhering to SRP.

## Open/Closed Principle (OCP)

**Definition**: Software entities (classes, modules, functions) should be open for extension but closed for modification.

**Example Explanation**:
- **Without OCP**: The `AreaCalculator` class needs to be modified each time a new shape is added, as it contains conditional logic for each shape type.

- **With OCP**: We create an `IShape` interface with a `CalculateArea` method. Each shape implements this interface, and the `AreaCalculator` class operates on the abstraction. New shapes can be added without modifying existing code.

## Liskov Substitution Principle (LSP)

**Definition**: Objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program.

**Example Explanation**:
- **Without LSP**: The `Square` class inherits from `Rectangle` but changes its behavior by forcing width and height to be equal. This breaks the expected behavior of a rectangle and causes issues when a `Square` is used in place of a `Rectangle`.

- **With LSP**: Instead of forcing inheritance, both `Rectangle` and `Square` implement a common `IShape` interface. Each class has its own implementation appropriate to its geometric properties without violating the expectations of the interface.

## Interface Segregation Principle (ISP)

**Definition**: No client should be forced to depend on methods it does not use.

**Example Explanation**:
- **Without ISP**: The `IMultiFunctionPrinter` interface forces implementing classes to provide methods for all printer functions, even if they don't support them. The `OldPrinter` class must implement methods like `Scan` and `Fax` even though it can't perform these operations.

- **With ISP**: We break down the fat interface into smaller, focused interfaces (`IPrinter`, `IScanner`, `IFax`, etc.). Classes only implement the interfaces relevant to their capabilities. This allows for more flexible compositions and prevents forcing classes to implement unsupported methods.

## Dependency Inversion Principle (DIP)

**Definition**: High-level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions.

**Example Explanation**:
- **Without DIP**: The `CustomerService` class (high-level module) directly depends on the `Database` class (low-level module). This creates tight coupling, making it difficult to change the database implementation without modifying the service.

- **With DIP**: We introduce an `ICustomerRepository` interface. The `CustomerService` depends on this abstraction, not on concrete implementations. We can now easily swap between different database implementations (SQL, MongoDB, etc.) without changing the service.

## Benefits of SOLID Principles

1. **Maintainability**: Code is easier to maintain and modify
2. **Scalability**: Systems can grow without becoming overly complex
3. **Testability**: Code is easier to test in isolation
4. **Reusability**: Components can be reused across the system
5. **Flexibility**: Code can adapt to changing requirements with minimal friction
