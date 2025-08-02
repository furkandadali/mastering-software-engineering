// File: BadDesign/ReportGeneratorSystem.cs
namespace code_base.solid.OpenClosedPrinciple.BadDesign
{
    /// <summary>
    /// VIOLATION: The `ReportGenerator` class is not closed for modification.
    ///
    /// Problems with this design:
    /// 1. Modification Risk: To add a new report type (e.g., JSON), we must modify the
    ///    `ReportGenerator` class's `GenerateReport` method. This risks introducing bugs
    ///    into existing, working functionality.
    /// 2. Rigidity: The design is rigid because a simple extension requires changing core logic.
    /// 3. Scalability Issues: As more report types are added, the `if-else if` chain
    ///    becomes long, complex, and hard to maintain.
    /// </summary>

    public enum ReportType
    {
        Pdf,
        Csv
    }

    // This class must be modified for each new report type.
    public class ReportGenerator
    {
        public void GenerateReport(ReportType type)
        {
            if (type == ReportType.Pdf)
            {
                Console.WriteLine("Generating PDF report...");
                // Logic for PDF generation
            }
            else if (type == ReportType.Csv)
            {
                Console.WriteLine("Generating CSV report...");
                // Logic for CSV generation
            }
            // To add a JSON report, you must add a new 'else if' block here.
        }
    }

    public class BadDesignExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Running Bad Design (Violating OCP) ---");
            var reportGenerator = new ReportGenerator();
            reportGenerator.GenerateReport(ReportType.Pdf);
            reportGenerator.GenerateReport(ReportType.Csv);
            Console.WriteLine("----------------------------------------\n");
        }
    }
}