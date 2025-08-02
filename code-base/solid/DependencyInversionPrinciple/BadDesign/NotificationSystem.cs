// File: BadDesign/NotificationSystem.cs
namespace code_base.solid.DependencyInversionPrinciple.BadDesign
{
    /// <summary>
    /// VIOLATION: High-level module (NotificationService) directly depends on a
    /// low-level module (EmailSender).
    ///
    /// Problems with this design:
    /// 1. Rigidity: If we want to add SMS notifications, we must modify the NotificationService class.
    ///    This violates the Open/Closed Principle.
    /// 2. Fragility: Changes in EmailSender (e.g., its constructor) can break NotificationService.
    /// 3. Non-Testable: It's impossible to test NotificationService without also testing the real EmailSender.
    ///    We cannot easily mock the dependency.
    /// </summary>

    // Low-level module
    public class EmailSender
    {
        public void SendEmail(string message)
        {
            Console.WriteLine($"Sending email: {message}");
        }
    }

    // High-level module
    public class NotificationService
    {
        private readonly EmailSender _emailSender;

        public NotificationService()
        {
            // The high-level module is creating its own dependency.
            // This is a strong violation of DIP.
            _emailSender = new EmailSender();
        }

        public void SendNotification(string message)
        {
            _emailSender.SendEmail(message);
        }
    }

    public class BadDesignExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Running Bad Design (Violating DIP) ---");
            var notificationService = new NotificationService();
            notificationService.SendNotification("This is a tightly coupled notification.");
            Console.WriteLine("----------------------------------------\n");
        }
    }
}