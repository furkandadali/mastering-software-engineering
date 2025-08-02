// File: GoodDesign/MultiFunctionDeviceSystem.cs
namespace code_base.solid.InterfaceSegregationPrinciple.GoodDesign
{
    /// <summary>
    /// ADHERENCE: The large interface is broken down into smaller, client-specific interfaces.
    ///
    /// Benefits of this design:
    /// 1. Cohesion: Each interface has a single, well-defined responsibility.
    /// 2. Flexibility: Classes implement only the interfaces they need. `SimplePrinter` only
    ///    needs `IPrinter`. A `MultiFunctionPrinter` can implement several interfaces.
    /// 3. Type Safety: It's impossible to call `Scan()` on a `SimplePrinter` object because
    ///    its type (`IPrinter`) does not have that method. This prevents runtime errors.
    /// </summary>

    // Small, cohesive interfaces
    public interface IPrinter
    {
        void Print(string document);
    }

    public interface IScanner
    {
        void Scan(string document);
    }

    public interface IFaxer
    {
        void Fax(string document);
    }

    // The SimplePrinter only needs to implement the IPrinter interface.
    public class SimplePrinter : IPrinter
    {
        public void Print(string document)
        {
            Console.WriteLine($"Printing: {document}");
        }
    }

    // A scanner machine would only implement IScanner.
    public class StandaloneScanner : IScanner
    {
        public void Scan(string document)
        {
            Console.WriteLine($"Scanning: {document}");
        }
    }

    // A multi-function device can implement all relevant interfaces.
    public class MultiFunctionPrinter : IPrinter, IScanner
    {
        public void Print(string document) => Console.WriteLine($"Printing: {document}");
        public void Scan(string document) => Console.WriteLine($"Scanning: {document}");
    }

    public class GoodDesignExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Running Good Design (Adhering to ISP) ---");

            // Using the SimplePrinter
            IPrinter printer = new SimplePrinter();
            printer.Print("Invoice.pdf");
            // The line below would cause a compile-time error, which is good!
            // printer.Scan("Photo.jpg");

            // Using the MultiFunctionPrinter
            var multiDevice = new MultiFunctionPrinter();
            multiDevice.Print("Report.docx");
            multiDevice.Scan("Photo.jpg");

            Console.WriteLine("-----------------------------------------\n");
        }
    }
}