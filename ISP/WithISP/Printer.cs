using System;

namespace SOLIDPrinciples.ISP.WithISP
{
    // This example follows the Interface Segregation Principle
    // It breaks down the fat interface into smaller, more focused interfaces
    
    // Segregated interfaces for different printer functionalities
    public interface IPrinter
    {
        void Print(string document);
    }
    
    public interface IScanner
    {
        void Scan(string document);
    }
    
    public interface IFax
    {
        void Fax(string document);
    }
    
    public interface ICopier
    {
        void Copy(string document);
    }
    
    public interface IDuplexPrinter
    {
        void PrintDuplex(string document);
    }

    // Modern printer implements all the interfaces it supports
    public class ModernPrinter : IPrinter, IScanner, IFax, ICopier, IDuplexPrinter
    {
        public void Print(string document)
        {
            Console.WriteLine($"Printing: {document}");
        }
        
        public void Scan(string document)
        {
            Console.WriteLine($"Scanning: {document}");
        }
        
        public void Fax(string document)
        {
            Console.WriteLine($"Faxing: {document}");
        }
        
        public void Copy(string document)
        {
            Console.WriteLine($"Copying: {document}");
        }
        
        public void PrintDuplex(string document)
        {
            Console.WriteLine($"Printing duplex: {document}");
        }
    }

    // Old printer only implements the interfaces it actually supports
    public class OldPrinter : IPrinter
    {
        public void Print(string document)
        {
            Console.WriteLine($"Printing: {document}");
        }
        
        // No need to implement unsupported methods
    }

    // Convenience interface for multifunction devices
    public interface IMultiFunctionDevice : IPrinter, IScanner, IFax, ICopier
    {
        // Empty interface, just combines the others
    }

    // Implementation of a multi-function device through composition
    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter _printer;
        private IScanner _scanner;
        private IFax _fax;
        private ICopier _copier;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner, IFax fax, ICopier copier)
        {
            _printer = printer;
            _scanner = scanner;
            _fax = fax;
            _copier = copier;
        }

        public void Print(string document)
        {
            _printer.Print(document);
        }

        public void Scan(string document)
        {
            _scanner.Scan(document);
        }

        public void Fax(string document)
        {
            _fax.Fax(document);
        }

        public void Copy(string document)
        {
            _copier.Copy(document);
        }
    }

    public class ISPDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("\n=== With ISP Example ===\n");
            
            Console.WriteLine("Using modern printer:");
            var modernPrinter = new ModernPrinter();
            PrintDocument(modernPrinter, "Modern document");
            ScanDocument(modernPrinter, "Modern document");
            
            Console.WriteLine("\nUsing old printer:");
            var oldPrinter = new OldPrinter();
            PrintDocument(oldPrinter, "Old document");
            
            // Cannot call scanner methods on old printer
            // ScanDocument(oldPrinter, "Old document"); // Would not compile
            
            Console.WriteLine("\nUsing multi-function device:");
            var multiFunction = new MultiFunctionMachine(modernPrinter, modernPrinter, modernPrinter, modernPrinter);
            multiFunction.Print("Multi-function document");
            multiFunction.Scan("Multi-function document");
        }
        
        // Methods that work with specific interfaces
        private static void PrintDocument(IPrinter printer, string document)
        {
            printer.Print(document);
        }
        
        private static void ScanDocument(IScanner scanner, string document)
        {
            scanner.Scan(document);
        }
    }
}
