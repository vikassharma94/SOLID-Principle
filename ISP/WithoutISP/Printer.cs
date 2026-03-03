using System;

namespace SOLIDPrinciples.ISP.WithoutISP
{
    // This example violates the Interface Segregation Principle
    // It uses a "fat" interface that forces classes to implement methods they don't need
    
    // A "fat" interface with too many methods
    public interface IMultiFunctionPrinter
    {
        void Print(string document);
        void Scan(string document);
        void Fax(string document);
        void Copy(string document);
        void PrintDuplex(string document);
    }

    // Modern printer that can implement all methods
    public class ModernPrinter : IMultiFunctionPrinter
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

    // Old printer that can only print, but is forced to implement all methods
    public class OldPrinter : IMultiFunctionPrinter
    {
        public void Print(string document)
        {
            Console.WriteLine($"Printing: {document}");
        }
        
        // Forced to implement methods it doesn't support
        public void Scan(string document)
        {
            throw new NotImplementedException("This printer cannot scan");
        }
        
        public void Fax(string document)
        {
            throw new NotImplementedException("This printer cannot fax");
        }
        
        public void Copy(string document)
        {
            throw new NotImplementedException("This printer cannot copy");
        }
        
        public void PrintDuplex(string document)
        {
            throw new NotImplementedException("This printer cannot print duplex");
        }
    }

    public class ISPDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("\n=== Without ISP Example ===\n");
            
            Console.WriteLine("Using modern printer:");
            IMultiFunctionPrinter modernPrinter = new ModernPrinter();
            modernPrinter.Print("Modern document");
            modernPrinter.Scan("Modern document");
            modernPrinter.Fax("Modern document");
            
            Console.WriteLine("\nUsing old printer:");
            IMultiFunctionPrinter oldPrinter = new OldPrinter();
            oldPrinter.Print("Old document");
            
            Console.WriteLine("\nTrying to use unsupported features on old printer:");
            Console.WriteLine("(This would throw NotImplementedException at runtime)");
            
            // Would throw an exception at runtime
            // oldPrinter.Scan("Old document");
        }
    }
}
