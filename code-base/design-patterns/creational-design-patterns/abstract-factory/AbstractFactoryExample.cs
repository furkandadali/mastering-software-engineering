namespace code_base.design_patterns.creational_design_patterns.abstract_factory;

/// <summary>
/// The Abstract Factory Pattern
///
/// Intent: Provide an interface for creating families of related or dependent objects
/// without specifying their concrete classes.
///
/// Key Components:
/// 1. Abstract Product: Declares an interface for a type of product object (e.g., `IButton`, `ICheckbox`).
/// 2. Concrete Product: Implements the Abstract Product interface (e.g., `WindowsButton`, `MacCheckbox`).
/// 3. Abstract Factory: Declares an interface with a set of methods for creating abstract products (e.g., `IGUIFactory`).
/// 4. Concrete Factory: Implements the creation methods of the Abstract Factory to create a specific family of products (e.g., `WindowsFactory`, `MacFactory`).
/// 5. Client: Uses only the interfaces declared by Abstract Factory and Abstract Product classes.
/// </summary>

// 1. Abstract Products
public interface IButton
{
    void Paint();
}

public interface ICheckbox
{
    void Paint();
}

// 2. Concrete Products for Windows
public class WindowsButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Rendering a button in Windows style.");
    }
}

public class WindowsCheckbox : ICheckbox
{
    public void Paint()
    {
        Console.WriteLine("Rendering a checkbox in Windows style.");
    }
}

// 2. Concrete Products for macOS
public class MacButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Rendering a button in macOS style.");
    }
}

public class MacCheckbox : ICheckbox
{
    public void Paint()
    {
        Console.WriteLine("Rendering a checkbox in macOS style.");
    }
}

// 3. Abstract Factory
public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// 4. Concrete Factories
public class WindowsFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new WindowsButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new WindowsCheckbox();
    }
}

public class MacFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new MacButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new MacCheckbox();
    }
}

// 5. The Client
// The client code works with factories and products only through abstract types:
// IGUIFactory, IButton, and ICheckbox. This lets you pass any factory or
// product subclass to the client code without breaking it.
public class Application
{
    private readonly IButton _button;
    private readonly ICheckbox _checkbox;

    public Application(IGUIFactory factory)
    {
        _button = factory.CreateButton();
        _checkbox = factory.CreateCheckbox();
    }

    public void PaintUI()
    {
        _button.Paint();
        _checkbox.Paint();
    }
}

// Example runner
public class AbstractFactoryExample
{
    public static void Run()
    {
        Console.WriteLine("--- Abstract Factory Pattern Demonstration ---");

        // The application can be configured with a specific factory
        // depending on the environment (e.g., current OS).
        // The client code below doesn't know which concrete factory it's using.

        Console.WriteLine("Client: Testing client code with the Windows factory type...");
        var windowsFactory = new WindowsFactory();
        var windowsApp = new Application(windowsFactory);
        windowsApp.PaintUI();

        Console.WriteLine("\n-------------------------------------\n");

        Console.WriteLine("Client: Testing the same client code with the macOS factory type...");
        var macFactory = new MacFactory();
        var macApp = new Application(macFactory);
        macApp.PaintUI();

        Console.WriteLine("-------------------------------------\n");
    }
}