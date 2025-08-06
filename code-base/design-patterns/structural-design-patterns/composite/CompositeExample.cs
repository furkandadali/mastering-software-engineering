namespace code_base.design_patterns.structural_design_patterns.composite
{
    /// <summary>
    /// The Composite Pattern
    ///
    /// Intent: Compose objects into tree structures to represent part-whole hierarchies.
    /// Composite lets clients treat individual objects and compositions of objects uniformly.
    /// </summary>
    public class CompositeExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Composite Pattern Demonstration ---\n");

            // Create leaf nodes
            IFileSystemItem file1 = new File("Document.txt");
            IFileSystemItem file2 = new File("Photo.jpg");

            // Create a composite node (directory)
            Directory root = new Directory("Root");
            root.Add(file1);
            root.Add(file2);

            // Add a subdirectory with its own files
            Directory subDir = new Directory("SubFolder");
            subDir.Add(new File("Notes.txt"));
            root.Add(subDir);

            // Display the structure
            root.Display(0);

            Console.WriteLine("\n--- End of Demonstration ---");
        }
    }

    // 1. Component interface
    public interface IFileSystemItem
    {
        void Display(int indent);
    }

    // 2. Leaf
    public class File : IFileSystemItem
    {
        private readonly string _name;

        public File(string name)
        {
            _name = name;
        }

        public void Display(int indent)
        {
            Console.WriteLine(new string(' ', indent * 2) + "- " + _name);
        }
    }

    // 3. Composite
    public class Directory : IFileSystemItem
    {
        private readonly string _name;
        private readonly List<IFileSystemItem> _items = new();

        public Directory(string name)
        {
            _name = name;
        }

        public void Add(IFileSystemItem item)
        {
            _items.Add(item);
        }

        public void Display(int indent)
        {
            Console.WriteLine(new string(' ', indent * 2) + "+ " + _name);
            foreach (var item in _items)
            {
                item.Display(indent + 1);
            }
        }
    }
}