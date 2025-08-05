namespace code_base.design_patterns.structural_design_patterns.adapter
{
    /// <summary>
    /// The Adapter Pattern
    ///
    /// Intent: Convert the interface of a class into another interface clients expect.
    /// Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.
    /// It's often used to make existing classes work with other classes without modifying their source code.
    ///
    /// Key Components:
    /// 1. Target: The interface that the client code works with.
    /// 2. Adaptee: The existing class with an incompatible interface that needs to be adapted.
    /// 3. Adapter: A class that wraps the Adaptee and implements the Target interface. It translates requests from the client into calls on the Adaptee.
    /// 4. Client: The class that interacts with the Target interface.
    /// </summary>
    public class AdapterExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Adapter Pattern Demonstration ---\n");

            // The client code needs an ILogger.
            // It doesn't know or care about the ThirdPartyLogger.
            ILogger logger;

            // We can use our application's standard logger.
            logger = new AppLogger();
            logger.Log("This is a standard log message.");
            logger.LogError("This is a standard error message.");

            Console.WriteLine("\n-------------------------------------\n");

            // Now, let's integrate the third-party logger using the Adapter.
            var thirdPartyLogger = new ThirdPartyLogger();
            logger = new LoggerAdapter(thirdPartyLogger); // Wrap the adaptee in the adapter.

            // The client code still works with the ILogger interface,
            // but the calls are now being adapted to the ThirdPartyLogger's methods.
            Console.WriteLine("Using the LoggerAdapter to integrate the ThirdPartyLogger:");
            logger.Log("This log will be handled by the third-party logger.");
            logger.LogError("This error will also be handled by the third-party logger.");

            Console.WriteLine("\n--- End of Demonstration ---");
        }
    }

    // 1. The Target Interface
    // This is the interface that the client application expects to use.
    public interface ILogger
    {
        void Log(string message);
        void LogError(string error);
    }

    // A standard implementation of the Target interface within our application.
    public class AppLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[AppLog] Info: {message}");
        }

        public void LogError(string error)
        {
            Console.WriteLine($"[AppLog] ERROR: {error}");
        }
    }


    // 2. The Adaptee
    // This is an existing class (e.g., from a third-party library) with an incompatible interface.
    // We cannot change this class's code.
    public class ThirdPartyLogger
    {
        // It has a different method name and combines log types.
        public void WriteLogEntry(string entry)
        {
            Console.WriteLine($"--ThirdPartyLog-- Entry recorded: {entry}");
        }
    }

    // 3. The Adapter
    // This class implements the Target interface (ILogger) and wraps an instance of the Adaptee (ThirdPartyLogger).
    public class LoggerAdapter : ILogger
    {
        private readonly ThirdPartyLogger _thirdPartyLogger;

        public LoggerAdapter(ThirdPartyLogger thirdPartyLogger)
        {
            _thirdPartyLogger = thirdPartyLogger;
        }

        // The adapter translates the Log method call into a call to the Adaptee's WriteLogEntry method.
        public void Log(string message)
        {
            _thirdPartyLogger.WriteLogEntry($"[INFO] {message}");
        }

        // It also translates the LogError method call.
        public void LogError(string error)
        {
            _thirdPartyLogger.WriteLogEntry($"[FATAL] {error}");
        }
    }
}