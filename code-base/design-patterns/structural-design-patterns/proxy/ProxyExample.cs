namespace code_base.design_patterns.structural_design_patterns.proxy
{
    /// <summary>
    /// The Proxy Pattern
    ///
    /// Intent: Provide a surrogate or placeholder for another object to control access to it.
    /// This can be used for various reasons, such as controlling access (protection proxy),
    /// lazy initialization (virtual proxy), logging requests (logging proxy), or facilitating
    /// remote communication (remote proxy).
    ///
    /// Analogy: A company's customer service phone number. You call one number (the proxy),
    /// and an automated system or a receptionist routes your call to the correct department
    /// or person (the real subject). The proxy handles the initial interaction and decides
    /// where to forward the request.
    ///
    /// Key Components:
    /// 1. Subject: An interface that both the RealSubject and the Proxy implement, so the client can treat them interchangeably.
    /// 2. RealSubject: The actual object that does the real work. The proxy represents this object.
    /// 3. Proxy: The object that holds a reference to the RealSubject. It implements the Subject interface and can add its own logic before or after delegating the call to the RealSubject.
    /// 4. Client: The object that interacts with the Subject through its interface.
    /// </summary>
    public class ProxyExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Proxy Pattern Demonstration (Protection Proxy) ---\n");

            // Create two users with different roles
            var manager = new User("Jane Doe", "Manager");
            var developer = new User("John Smith", "Developer");

            // The client interacts with the proxy, not the real folder directly.
            Console.WriteLine($"Client: Executing request for user: {manager.Username} ({manager.Role})");
            ISharedFolder folderProxyForManager = new SharedFolderProxy(manager);
            folderProxyForManager.PerformReadWriteOperations();

            Console.WriteLine("\n--------------------------------------------------\n");

            Console.WriteLine($"Client: Executing request for user: {developer.Username} ({developer.Role})");
            ISharedFolder folderProxyForDeveloper = new SharedFolderProxy(developer);
            folderProxyForDeveloper.PerformReadWriteOperations();

            Console.WriteLine("\n--- End of Demonstration ---");
        }
    }

    // A simple class to represent a user with a role
    public class User
    {
        public string Username { get; }
        public string Role { get; }

        public User(string username, string role)
        {
            Username = username;
            Role = role;
        }
    }


    // 1. The Subject Interface
    // Defines the common operations for both RealSubject and Proxy.
    public interface ISharedFolder
    {
        void PerformReadWriteOperations();
    }

    // 2. The RealSubject
    // This is the actual object that contains the core business logic.
    public class SharedFolder : ISharedFolder
    {
        public void PerformReadWriteOperations()
        {
            Console.WriteLine("SharedFolder: Performing read/write operations on the folder.");
        }
    }

    // 3. The Proxy
    // This class has the same interface as the RealSubject.
    // It controls access to the RealSubject.
    public class SharedFolderProxy : ISharedFolder
    {
        private ISharedFolder _folder;
        private readonly User _user;

        public SharedFolderProxy(User user)
        {
            _user = user;
        }

        public void PerformReadWriteOperations()
        {
            // The proxy adds its own logic here (in this case, a security check).
            if (_user.Role.Equals("Manager", StringComparison.OrdinalIgnoreCase))
            {
                // Lazy initialization: create the RealSubject only when needed.
                _folder ??= new SharedFolder();

                Console.WriteLine("SharedFolderProxy: Access granted. Forwarding request to the real folder.");
                _folder.PerformReadWriteOperations();
            }
            else
            {
                Console.WriteLine("SharedFolderProxy: Access denied. You do not have permission to access this folder.");
            }
        }
    }
}