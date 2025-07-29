namespace code_base.oop.encapsulation;

/// <summary>
/// Encapsulation Example: BankAccount Class
/// 
/// Encapsulation is one of the four fundamental OOP principles that involves:
/// 1. Data Hiding: Keep internal state private
/// 2. Controlled Access: Provide public methods/properties for interaction
/// 3. Data Protection: Validate and protect data integrity
/// </summary>
public class EncapsulationExample
{
    public static void DemonstrateEncapsulation()
    {
        Console.WriteLine("=== Encapsulation Demonstration ===\n");
        
        // Create a bank account
        var account = new BankAccount("John Doe", 1000.00m);
        
        // Access data through public interface (encapsulated access)
        Console.WriteLine($"Account Holder: {account.AccountHolderName}");
        Console.WriteLine($"Current Balance: ${account.Balance:F2}");
        Console.WriteLine($"Account Number: {account.AccountNumber}\n");
        
        // Perform operations through controlled methods
        account.Deposit(500.00m);
        account.Withdraw(200.00m);
        
        // Try invalid operations (encapsulation protects data)
        Console.WriteLine("\n--- Testing Data Protection ---");
        account.Withdraw(2000.00m); // Should fail - insufficient funds
        account.Deposit(-100.00m);  // Should fail - negative amount
    }
}

/// <summary>
/// BankAccount class demonstrating encapsulation principles
/// </summary>
public class BankAccount
{
    // Private fields (Data Hiding) - cannot be accessed directly from outside
    private decimal _balance;
    private string _accountNumber;
    private string _accountHolderName;
    private DateTime _createdDate;
    private List<string> _transactionHistory;
    
    // Constructor
    public BankAccount(string accountHolderName, decimal initialBalance)
    {
        if (string.IsNullOrWhiteSpace(accountHolderName))
            throw new ArgumentException("Account holder name cannot be empty");
        
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative");
        
        _accountHolderName = accountHolderName;
        _balance = initialBalance;
        _accountNumber = GenerateAccountNumber();
        _createdDate = DateTime.Now;
        _transactionHistory = new List<string>();
        
        AddTransaction($"Account created with initial balance: ${initialBalance:F2}");
    }
    
    // Public Properties (Controlled Access) - provide safe access to private data
    public string AccountHolderName 
    { 
        get => _accountHolderName; 
        // Note: No setter - account holder name cannot be changed after creation
    }
    
    public decimal Balance 
    { 
        get => _balance; 
        // Note: No public setter - balance can only be changed through Deposit/Withdraw methods
    }
    
    public string AccountNumber 
    { 
        get => _accountNumber; 
        // Note: No setter - account number is immutable
    }
    
    public DateTime CreatedDate 
    { 
        get => _createdDate; 
        // Note: No setter - creation date is immutable
    }
    
    // Public Methods (Controlled Operations) - provide safe ways to modify data
    public bool Deposit(decimal amount)
    {
        // Data validation and protection
        if (amount <= 0)
        {
            Console.WriteLine("Error: Deposit amount must be positive");
            return false;
        }
        
        if (amount > 10000) // Business rule example
        {
            Console.WriteLine("Error: Single deposit cannot exceed $10,000");
            return false;
        }
        
        // Safe modification of private data
        _balance += amount;
        AddTransaction($"Deposited: ${amount:F2}");
        
        Console.WriteLine($"Successfully deposited ${amount:F2}. New balance: ${_balance:F2}");
        return true;
    }
    
    public bool Withdraw(decimal amount)
    {
        // Data validation and protection
        if (amount <= 0)
        {
            Console.WriteLine("Error: Withdrawal amount must be positive");
            return false;
        }
        
        if (amount > _balance)
        {
            Console.WriteLine("Error: Insufficient funds");
            return false;
        }
        
        if (amount > 5000) // Business rule example
        {
            Console.WriteLine("Error: Single withdrawal cannot exceed $5,000");
            return false;
        }
        
        // Safe modification of private data
        _balance -= amount;
        AddTransaction($"Withdrew: ${amount:F2}");
        
        Console.WriteLine($"Successfully withdrew ${amount:F2}. New balance: ${_balance:F2}");
        return true;
    }
    
    public void DisplayTransactionHistory()
    {
        Console.WriteLine("\n--- Transaction History ---");
        foreach (var transaction in _transactionHistory)
        {
            Console.WriteLine(transaction);
        }
    }
    
    // Private helper methods (Implementation hiding)
    private string GenerateAccountNumber()
    {
        // Simple account number generation (in real world, this would be more sophisticated)
        var random = new Random();
        return $"ACC{random.Next(100000, 999999)}";
    }
    
    private void AddTransaction(string description)
    {
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _transactionHistory.Add($"{timestamp}: {description}");
    }
}