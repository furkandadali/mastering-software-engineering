// File: BadDesign/UserService.cs
namespace code_base.solid.SingleResponsiblityPrinciple.BadDesign
{
    /// <summary>
    /// VIOLATION: This class has multiple responsibilities.
    ///
    /// Problems with this design:
    /// 1. Multiple Reasons to Change: The class must be modified if:
    ///    - The validation logic changes.
    ///    - The database saving mechanism changes.
    ///    - The email notification logic changes.
    /// 2. Low Cohesion: The methods are not closely related. Validation, persistence, and
    ///    notification are distinct concerns.
    /// 3. Difficult to Test: Testing this class requires setting up scenarios for validation,
    ///    database interaction, and email sending all at once.
    /// </summary>
    public class UserService
    {
        public void RegisterUser(string email, string password)
        {
            // Responsibility 1: Validate Input
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                Console.WriteLine("Validation failed: Invalid email address.");
                return;
            }

            // Responsibility 2: Data Persistence
            Console.WriteLine($"Database: Saving user '{email}' to the database.");
            // ... complex database logic would go here ...

            // Responsibility 3: Notification
            Console.WriteLine($"Notification: Sending a welcome email to '{email}'.");
            // ... email sending logic would go here ...

            Console.WriteLine("User registration completed successfully.");
        }
    }

    public class BadDesignExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Running Bad Design (Violating SRP) ---");
            var userService = new UserService();
            userService.RegisterUser("test@example.com", "password123");
            Console.WriteLine("----------------------------------------\n");
        }
    }
}