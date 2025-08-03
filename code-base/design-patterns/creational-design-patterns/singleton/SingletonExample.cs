namespace code_base.design_patterns.creational_design_patterns.singleton;

/// <summary>
/// The Singleton Pattern
///
/// Intent: Ensure a class only has one instance, and provide a global point of access to it.
///
/// Key Features:
/// 1. Private Constructor: Prevents direct instantiation of the class from outside.
/// 2. Static Instance: The class holds a single, static instance of itself.
/// 3. Global Access Point: A static property or method provides access to this single instance.
/// 4. Thread Safety: The implementation must ensure that only one instance is created even in a multithreaded environment.
///    Using `Lazy<T>` is a simple and efficient way to achieve this.
/// </summary>
public sealed class ApplicationLogger
{
    // The Lazy<T> object provides thread-safe, lazy initialization.
    // The instance is not created until it is first accessed.
    private static readonly Lazy<ApplicationLogger> lazyInstance =
        new Lazy<ApplicationLogger>(() => new ApplicationLogger());

    // The public static property that provides the global access point.
    // This is the only way to get the instance of the class.
    public static ApplicationLogger Instance => lazyInstance.Value;

    // The private constructor prevents creating new instances of the class.
    private ApplicationLogger()
    {
        // Initialization code, such as opening a log file, can go here.
        Console.WriteLine("Logger instance created. (This should only happen once)");
    }

    // A sample method for the logger.
    public void Log(string message)
    {
        Console.WriteLine($"[LOG - {DateTime.Now:HH:mm:ss}] {message}");
    }
}

/// <summary>
/// Demonstrates how to use the Singleton pattern.
/// </summary>
public class SingletonExample
{
    public static void Run()
    {
        Console.WriteLine("--- Singleton Pattern Demonstration ---");

        // Access the singleton instance from two different variables.
        var logger1 = ApplicationLogger.Instance;
        var logger2 = ApplicationLogger.Instance;

        // Check if both variables point to the exact same object instance.
        if (ReferenceEquals(logger1, logger2))
        {
            Console.WriteLine("logger1 and logger2 are the same instance. Singleton works!");
        }
        else
        {
            Console.WriteLine("Singleton failed: different instances were created.");
        }

        // Use the logger from different parts of the application.
        // No matter where it's called from, it's always the same logger instance.
        logger1.Log("User logged in.");
        logger2.Log("Data saved to database.");

        Console.WriteLine("-------------------------------------\n");
    }
}