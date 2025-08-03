namespace code_base.design_patterns.creational_design_patterns.prototype;

/// <summary>
/// The Prototype Pattern
///
/// Intent: Specify the kinds of objects to create using a prototypical instance,
/// and create new objects by copying this prototype.
///
/// Key Components:
/// 1. Prototype: An interface or abstract class that declares a cloning method.
/// 2. Concrete Prototype: A class that implements the cloning method. The cloning itself can be shallow or deep.
/// 3. Client: Creates a new object by asking a prototype to clone itself.
/// </summary>

// 1. The Prototype Abstract Class
public abstract class DocumentPrototype
{
    public string Title { get; set; }
    public DateTime CreatedAt { get; protected set; }

    public DocumentPrototype(string title)
    {
        Title = title;
        CreatedAt = DateTime.Now;
    }

    // The cloning method
    public abstract DocumentPrototype Clone();

    public virtual void Display()
    {
        Console.WriteLine($"--- Document: {Title} ---");
        Console.WriteLine($"Created At: {CreatedAt:yyyy-MM-dd HH:mm:ss}");
    }
}

// 2. A Concrete Prototype
public class SalesReport : DocumentPrototype
{
    public string ReportData { get; set; }

    public SalesReport(string title, string data) : base(title)
    {
        // Simulating an expensive operation, like fetching data from a database.
        Console.WriteLine("Generating initial sales report (expensive operation)...");
        ReportData = data;
    }

    // Implementation of the cloning method.
    // MemberwiseClone() creates a shallow copy. This is fine for value types like strings and DateTime.
    // If ReportData were a complex object, a deep copy would be needed to clone that object as well.
    public override DocumentPrototype Clone()
    {
        Console.WriteLine($"Cloning report: '{Title}'...");
        return (DocumentPrototype)this.MemberwiseClone();
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Report Data: {ReportData}");
        Console.WriteLine("--------------------------");
    }
}

// Example of how the client uses the prototype.
public class PrototypeExample
{
    public static void Run()
    {
        Console.WriteLine("--- Prototype Pattern Demonstration ---");

        // Create an initial object, which is an "expensive" operation.
        var originalReport = new SalesReport("Q1 Sales Report", "Data for Q1...");
        originalReport.Display();

        Console.WriteLine("\n-------------------------------------\n");

        // Now, create a new object by cloning the original. This is "cheap".
        var clonedReport = (SalesReport)originalReport.Clone();

        // We can now modify the cloned object without affecting the original.
        clonedReport.Title = "Q2 Sales Report (from Q1 template)";
        clonedReport.ReportData = "Data for Q2...";

        Console.WriteLine("Displaying original and cloned reports to show they are separate instances:\n");

        // Original remains unchanged.
        Console.WriteLine("Original:");
        originalReport.Display();

        // Cloned object has its own state.
        Console.WriteLine("Cloned and Modified:");
        clonedReport.Display();

        Console.WriteLine("-------------------------------------\n");
    }
}