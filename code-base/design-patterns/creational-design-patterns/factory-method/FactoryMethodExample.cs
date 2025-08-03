namespace code_base.design_patterns.creational_design_patterns.factory_method;

/// <summary>
/// The Factory Method Pattern
///
/// Intent: Define an interface for creating an object, but let subclasses decide which class to instantiate.
/// Factory Method lets a class defer instantiation to subclasses.
///
/// Key Components:
/// 1. Product: Defines the interface for objects the factory method creates (e.g., `ITransport`).
/// 2. Concrete Product: Implements the Product interface (e.g., `Truck`, `Ship`).
/// 3. Creator: Declares the factory method that returns an object of type Product. It may also contain business logic that relies on the product.
/// 4. Concrete Creator: Overrides the factory method to return an instance of a Concrete Product.
/// </summary>

// 1. The Product Interface
public interface ITransport
{
    string Deliver();
}

// 2. Concrete Products
public class Truck : ITransport
{
    public string Deliver()
    {
        return "Delivering by land in a truck.";
    }
}

public class Ship : ITransport
{
    public string Deliver()
    {
        return "Delivering by sea in a ship.";
    }
}

// 3. The Creator (can be abstract or concrete)
public abstract class Logistics
{
    // The Factory Method - abstract, forcing subclasses to implement it.
    public abstract ITransport CreateTransport();

    // This is a core business logic method that uses the product created by the factory method.
    // The base class doesn't know which concrete product it will get, but it knows it will work with it.
    public void PlanDelivery()
    {
        // Call the factory method to create a Product object.
        ITransport transport = CreateTransport();

        // Now, use the product.
        Console.WriteLine("Logistics: Planning delivery...");
        Console.WriteLine(transport.Deliver());
    }
}

// 4. Concrete Creators
public class RoadLogistics : Logistics
{
    // This creator overrides the factory method to create a Truck.
    public override ITransport CreateTransport()
    {
        return new Truck();
    }
}

public class SeaLogistics : Logistics
{
    // This creator overrides the factory method to create a Ship.
    public override ITransport CreateTransport()
    {
        return new Ship();
    }
}

// Example of how the client uses the factory.
public class FactoryMethodExample
{
    public static void Run()
    {
        Console.WriteLine("--- Factory Method Pattern Demonstration ---");

        // The client code works with an instance of a concrete creator,
        // albeit through its base interface. As long as the client keeps
        // working with the creator via the base interface, you can pass it
        // any creator's subclass.

        Console.WriteLine("App: Launched with the RoadLogistics.");
        ClientCode(new RoadLogistics());

        Console.WriteLine("\n-------------------------------------\n");

        Console.WriteLine("App: Launched with the SeaLogistics.");
        ClientCode(new SeaLogistics());

        Console.WriteLine("-------------------------------------\n");
    }

    // The client code works with creators through the abstract Logistics class.
    // It doesn't know which concrete creator it's working with, and thus
    // it doesn't know which concrete product gets created.
    public static void ClientCode(Logistics creator)
    {
        creator.PlanDelivery();
    }
}