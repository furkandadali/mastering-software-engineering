// File: GoodDesign/NotificationSystem.cs
namespace code_base.solid.DependencyInversionPrinciple.GoodDesign
{
    /// <summary>
    /// ADHERENCE: Both high-level and low-level modules depend on an abstraction (IMessageSender).
    ///
    /// Benefits of this design:
    /// 1. Flexibility: We can easily add new notification methods (like PushNotificationSender)
    ///    by creating a new class that implements IMessageSender, without changing NotificationService.
    /// 2. Testability: We can easily test NotificationService by providing a mock implementation
    ///    of IMessageSender.
    /// 3. Decoupling: NotificationService is no longer coupled to any specific sender implementation.
    /// </summary>

    // Abstraction
    public interface IMessageSender
    {
        void SendMessage(string message);
    }

    // Low-level module depending on the abstraction
    public class EmailSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Sending email: {message}");
        }
    }

    // Another low-level module depending on the abstraction
    public class SmsSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }

    // High-level module depending on the abstraction
    public class NotificationService
    {
        private readonly IMessageSender _messageSender;

        // The dependency is injected via the constructor (Dependency Injection).
        // The high-level module does not know or care about the concrete implementation.
        public NotificationService(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public void SendNotification(string message)
        {
            _messageSender.SendMessage(message);
        }
    }

    public class GoodDesignExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Running Good Design (Adhering to DIP) ---");

            // Send an email notification
            IMessageSender emailSender = new EmailSender();
            var emailService = new NotificationService(emailSender);
            emailService.SendNotification("This is a decoupled email notification.");

            // Send an SMS notification - no changes needed in NotificationService!
            IMessageSender smsSender = new SmsSender();
            var smsService = new NotificationService(smsSender);
            smsService.SendNotification("This is a decoupled SMS notification.");

            Console.WriteLine("-----------------------------------------\n");
        }
    }
}