# SOLID Principles Demo

This project demonstrates the SOLID principles in C# with practical examples. Each principle has its own folder with two subfolders - one demonstrating code that violates the principle and one that follows it.

## SOLID Principles Explained

### Single Responsibility Principle (SRP)
> A class should have only one reason to change.

- `SRP/WithoutSRP`: Example violating SRP - A class handling multiple responsibilities
- `SRP/WithSRP`: Example following SRP - Responsibilities divided into separate classes

### Open/Closed Principle (OCP)
> Software entities should be open for extension but closed for modification.

- `OCP/WithoutOCP`: Example violating OCP - Code that requires modification to add new functionality
- `OCP/WithOCP`: Example following OCP - Code that can be extended without modification

### Liskov Substitution Principle (LSP)
> Objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program.

- `LSP/WithoutLSP`: Example violating LSP - Inheritance hierarchy that breaks substitutability
- `LSP/WithLSP`: Example following LSP - Properly designed inheritance that preserves substitutability

### Interface Segregation Principle (ISP)
> No client should be forced to depend on methods it does not use.

- `ISP/WithoutISP`: Example violating ISP - Large interfaces forcing classes to implement methods they don't need
- `ISP/WithISP`: Example following ISP - Small, focused interfaces that clients can implement as needed

### Dependency Inversion Principle (DIP)
> High-level modules should not depend on low-level modules. Both should depend on abstractions.

- `DIP/WithoutDIP`: Example violating DIP - High-level modules directly depending on low-level modules
- `DIP/WithDIP`: Example following DIP - Both high and low-level modules depending on abstractions

## Getting Started

### Prerequisites
- .NET 9.0 SDK or later

### Running the Project
1. Clone this repository
2. Navigate to the project directory
3. Run the project:
   ```
   dotnet run
   ```

## Project Structure

Each principle's folder contains two subfolders:
- `Without[Principle]`: Contains code that violates the principle
- `With[Principle]`: Contains code that follows the principle

## Additional Documentation

For more detailed explanations of each principle, see the `SOLID_Documentation.md` file.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
