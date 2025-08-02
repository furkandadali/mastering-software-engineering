// File: GoodDesign/ReportGeneratorSystem.cs
namespace code_base.solid.OpenClosedPrinciple.GoodDesign
{
    /// <summary>
    /// ADHERENCE: The system is open for extension but closed for modification.
    ///
    /// Benefits of this design:
    /// 1. Extensibility: To add a new report format (e.g., `JsonReportGenerator`), we create a
    ///    new class that implements the `IReportGenerator` interface. No existing code is touched.
    /// 2. Maintainability: Each report generation logic is isolated in its own class,
    ///    making it easier to manage, test, and debug.
    /// 3. Flexibility: The client code works with the `IReportGenerator` abstraction and is
    ///    decoupled from the concrete implementations.
    /// </summary>

    // Abstraction (the "closed for modification" part)
    public interface IReportGenerator
    {
        void Generate();
    }

    // Extension 1
    public class PdfReportGenerator : IReportGenerator
    {
        public void Generate()
        {
            Console.WriteLine("Generating PDF report...");
        }
    }

    // Extension 2
    public class CsvReportGenerator : IReportGenerator
    {
        public void Generate()
        {
            Console.WriteLine("Generating CSV report...");
        }
    }

    // NEW EXTENSION: Added without modifying any existing code.
    public class JsonReportGenerator : IReportGenerator
    {
        public void Generate()
        {
            Console.WriteLine("Generating JSON report...");
        }
    }

    public class GoodDesignExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Running Good Design (Adhering to OCP) ---");

            // The client can work with any implementation of IReportGenerator.
            var generators = new List<IReportGenerator>
            {
                new PdfReportGenerator(),
                new CsvReportGenerator(),
                new JsonReportGenerator() // Easily added the new functionality.
            };

            foreach (var generator in generators)
            {
                generator.Generate();
            }

            Console.WriteLine("-----------------------------------------\n");
        }
    }
}