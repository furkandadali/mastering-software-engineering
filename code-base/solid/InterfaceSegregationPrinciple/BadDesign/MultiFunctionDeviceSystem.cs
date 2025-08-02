// File: BadDesign/MultiFunctionDeviceSystem.cs
namespace code_base.solid.InterfaceSegregationPrinciple.BadDesign
{
    /// <summary>
    /// VIOLATION: A single, large interface forces clients to implement methods they don't use.
    ///
    /// Problems with this design:
    /// 1. Unnecessary Implementation: The `SimplePrinter` class must provide implementations
    ///    for `Scan()` and `Fax()`, which are irrelevant to it. This often leads to throwing
    ///    `NotImplementedException`, which is a sign of a poor interface design.
    /// 2. Rigidity: If we add a new method to `IMultiFunctionDevice` (e.g., `Staple()`),
    ///    we must update all implementing classes, even those that don't support stapling.
    /// 3. Client Confusion: A client using a `SimplePrinter` object might mistakenly try to call `Scan()`,
    ///    leading to runtime errors.
    /// </summary>

    // "Fat" interface with multiple responsibilities
    public interface IMultiFunctionDevice
    {
        void Print(string document);
        void Scan(string document);
        void Fax(string document);
    }

    // This class can implement all methods without issue.
    public class MultiFunctionPrinter : IMultiFunctionDevice
    {
        public void Print(string document) => Console.WriteLine($"Printing: {document}");
        public void Scan(string document) => Console.WriteLine($"Scanning: {document}");
        public void Fax(string document) => Console.WriteLine($"Faxing: {document}");
    }

    // VIOLATION: This class is forced to implement methods it doesn't need.
    public class SimplePrinter : IMultiFunctionDevice
    {
        public void Print(string document)
        {
            Console.WriteLine($"Printing: {document}");
        }

        // This method is irrelevant for a simple printer.
        public void Scan(string document)
        {
            throw new NotImplementedException("Scan functionality is not supported.");
        }

        // This method is also irrelevant.
        public void Fax(string document)
        {
            throw new NotImplementedException("Fax functionality is not supported.");
        }
    }

    public class BadDesignExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Running Bad Design (Violating ISP) ---");
            var simplePrinter = new SimplePrinter();
            simplePrinter.Print("Invoice.pdf");
            try
            {
                // This call will throw an exception, highlighting the design flaw.
                simplePrinter.Scan("Photo.jpg");
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            Console.WriteLine("----------------------------------------\n");
        }
    }
}