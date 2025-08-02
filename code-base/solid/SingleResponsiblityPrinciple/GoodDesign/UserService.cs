// File: GoodDesign/UserRegistrationSystem.cs
namespace code_base.solid.SingleResponsiblityPrinciple.GoodDesign
{
    /// <summary>
    /// ADHERENCE: Each class has a single responsibility.
    ///
    /// Benefits of this design:
    /// 1. Single Reason to Change:
    ///    - `UserValidator` changes only for validation rule updates.
    ///    - `UserRepository` changes only for data persistence updates (e.g., switching DB).
    ///    - `NotificationService` changes only for notification updates (e.g., switching email provider).
    /// 2. High Cohesion & Loose Coupling: Classes are focused and independent.
    /// 3. Easy to Test and Maintain: Each class can be tested in isolation. The code is
    ///    easier to understand and modify without unintended side effects.
    /// </summary>

    // Responsibility: Validate user data.
    public class UserValidator
    {
        public bool Validate(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                Console.WriteLine("Validation failed: Invalid email address.");
                return false;
            }
            return true;
        }
    }

    // Responsibility: Handle data persistence.
    public class UserRepository
    {
        public void Save(string email, string password)
        {
            Console.WriteLine($"Database: Saving user '{email}' to the database.");
            // ... database logic ...
        }
    }

    // Responsibility: Send notifications.
    public class NotificationService
    {
        public void SendWelcomeEmail(string email)
        {
            Console.WriteLine($"Notification: Sending a welcome email to '{email}'.");
            // ... email sending logic ...
        }
    }

    // Responsibility: Orchestrate the user registration process.
    public class UserRegistrationService
    {
        private readonly UserValidator _validator = new UserValidator();
        private readonly UserRepository _repository = new UserRepository();
        private readonly NotificationService _notifier = new NotificationService();

        public void Register(string email, string password)
        {
            if (_validator.Validate(email))
            {
                _repository.Save(email, password);
                _notifier.SendWelcomeEmail(email);
                Console.WriteLine("User registration completed successfully.");
            }
        }
    }

    public class GoodDesignExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Running Good Design (Adhering to SRP) ---");
            var registrationService = new UserRegistrationService();
            registrationService.Register("test@example.com", "password123");
            Console.WriteLine("-----------------------------------------\n");
        }
    }
}