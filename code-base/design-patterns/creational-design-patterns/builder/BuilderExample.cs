namespace code_base.design_patterns.creational_design_patterns.builder;

/// <summary>
/// The Builder Pattern
///
/// Intent: Separate the construction of a complex object from its representation so that
/// the same construction process can create different representations.
///
/// Key Components:
/// 1. Product: The complex object being built (e.g., `Computer`).
/// 2. Builder: An interface that specifies methods for creating the different parts of the Product (e.g., `IComputerBuilder`).
/// 3. Concrete Builder: Implements the Builder interface to construct and assemble parts of the product (e.g., `GamingComputerBuilder`).
/// 4. Director: A class that orchestrates the construction using a builder object. The Director is not always necessary; the client can control the builder directly.
/// </summary>

// 1. The Product - The complex object we want to create.
public class Computer
{
    public string CPUType { get; set; }
    public string RAM { get; set; }
    public string Storage { get; set; }
    public string GraphicsCard { get; set; }

    public void DisplayConfiguration()
    {
        Console.WriteLine("--- Computer Configuration ---");
        Console.WriteLine($"CPU: {CPUType}");
        Console.WriteLine($"RAM: {RAM}");
        Console.WriteLine($"Storage: {Storage}");
        Console.WriteLine($"Graphics Card: {GraphicsCard ?? "Integrated"}");
        Console.WriteLine("----------------------------");
    }
}

// 2. The Builder Interface
public interface IComputerBuilder
{
    void BuildCPU();
    void BuildRAM();
    void BuildStorage();
    void BuildGraphicsCard();
    Computer GetComputer();
}

// 3. Concrete Builders
// Builds a high-end gaming computer.
public class GamingComputerBuilder : IComputerBuilder
{
    private readonly Computer _computer = new Computer();

    public void BuildCPU() => _computer.CPUType = "Intel Core i9";
    public void BuildRAM() => _computer.RAM = "32GB DDR5";
    public void BuildStorage() => _computer.Storage = "2TB NVMe SSD";
    public void BuildGraphicsCard() => _computer.GraphicsCard = "NVIDIA RTX 4090";
    public Computer GetComputer() => _computer;
}

// Builds a standard office computer.
public class OfficeComputerBuilder : IComputerBuilder
{
    private readonly Computer _computer = new Computer();

    public void BuildCPU() => _computer.CPUType = "Intel Core i5";
    public void BuildRAM() => _computer.RAM = "16GB DDR4";
    public void BuildStorage() => _computer.Storage = "512GB SATA SSD";

    public void BuildGraphicsCard()
    {
        /* No dedicated graphics card for office PC */
    }

    public Computer GetComputer() => _computer;
}

// 4. The Director
// Orchestrates the build process. It works with any builder instance.
public class ComputerManufacturer
{
    public void Construct(IComputerBuilder computerBuilder)
    {
        computerBuilder.BuildCPU();
        computerBuilder.BuildRAM();
        computerBuilder.BuildStorage();
        computerBuilder.BuildGraphicsCard();
    }
}

// Example of how the client uses the builder.
public class BuilderExample
{
    public static void Run()
    {
        Console.WriteLine("--- Builder Pattern Demonstration ---");

        var manufacturer = new ComputerManufacturer();

        // Build a Gaming PC
        Console.WriteLine("Building a Gaming PC...");
        var gamingBuilder = new GamingComputerBuilder();
        manufacturer.Construct(gamingBuilder);
        Computer gamingPC = gamingBuilder.GetComputer();
        gamingPC.DisplayConfiguration();

        Console.WriteLine("\n-------------------------------------\n");

        // Build an Office PC
        Console.WriteLine("Building an Office PC...");
        var officeBuilder = new OfficeComputerBuilder();
        manufacturer.Construct(officeBuilder);
        Computer officePC = officeBuilder.GetComputer();
        officePC.DisplayConfiguration();

        Console.WriteLine("-------------------------------------\n");
    }
}