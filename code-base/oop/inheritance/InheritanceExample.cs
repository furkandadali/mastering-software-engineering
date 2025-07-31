namespace code_base.oop.inheritance
{
    /// <summary>
    /// Inheritance Example: Animal Hierarchy
    /// Inheritance is one of the four fundamental OOP principles that allows a class (derived/child)
    /// to inherit properties and methods from another class (base/parent).
    /// 1. Code Reusability: Avoids duplicating code by placing common logic in a base class.
    /// 2. "Is-A" Relationship: Establishes a logical hierarchy (e.g., a Dog "is an" Animal).
    /// 3. Extensibility: Allows new classes to be created based on existing ones.
    /// 4. Method Overriding: Enables a derived class to provide a specific implementation for a method defined in its base class.
    /// </summary>
    public class InheritanceExample
    {
        public static void DemonstrateInheritance()
        {
            Console.WriteLine("=== Inheritance Demonstration ===\n");

            // Create an instance of the Dog class
            var myDog = new Dog("Buddy", "Golden Retriever");
            Console.WriteLine($"Created a {myDog.Breed} named {myDog.Name}.");

            // Call methods on the Dog object
            myDog.Eat();    // Inherited from Animal class
            myDog.Sleep();  // Inherited from Animal class
            myDog.Speak();  // Overridden in Dog class
            myDog.Fetch();  // Specific to Dog class
            
            Console.WriteLine("\n-----------------------------------\n");

            // Create an instance of the Cat class
            var myCat = new Cat("Whiskers", "Siamese");
            Console.WriteLine($"Created a {myCat.Breed} named {myCat.Name}.");
            
            // Call methods on the Cat object
            myCat.Eat();    // Inherited from Animal class
            myCat.Sleep();  // Inherited from Animal class
            myCat.Speak();  // Overridden in Cat class
            myCat.Purr();   // Specific to Cat class
        }
    }

    /// <summary>
    /// Base Class (Parent)
    /// Defines common properties and methods for all animals.
    /// </summary>
    public class Animal
    {
        // Common property for all animals
        public string Name { get; set; }

        // Constructor for the base class
        public Animal(string name)
        {
            Name = name;
            Console.WriteLine("Animal constructor called.");
        }

        // Common method for all animals
        public void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }

        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping.");
        }

        // A virtual method can be overridden by derived classes.
        public virtual void Speak()
        {
            Console.WriteLine($"{Name} makes a sound.");
        }
    }

    /// <summary>
    /// Derived Class (Child)
    /// Inherits from the Animal class.
    /// </summary>
    public class Dog : Animal
    {
        // Property specific to the Dog class
        public string Breed { get; set; }

        // The constructor for Dog calls the base class (Animal) constructor
        // using the 'base' keyword to initialize the 'Name' property.
        public Dog(string name, string breed) : base(name)
        {
            Breed = breed;
            Console.WriteLine("Dog constructor called.");
        }

        // 'override' provides a new implementation for the virtual 'Speak' method from the base class.
        public override void Speak()
        {
            Console.WriteLine($"{Name} barks!");
        }

        // Method specific to the Dog class
        public void Fetch()
        {
            Console.WriteLine($"{Name} is fetching the ball.");
        }
    }
    
    /// <summary>
    /// Another Derived Class (Child)
    /// Also inherits from the Animal class.
    /// </summary>
    public class Cat : Animal
    {
        // Property specific to the Cat class
        public string Breed { get; set; }

        // Constructor calls the base constructor
        public Cat(string name, string breed) : base(name)
        {
            Breed = breed;
            Console.WriteLine("Cat constructor called.");
        }

        // Overriding the Speak method for a Cat
        public override void Speak()
        {
            Console.WriteLine($"{Name} meows.");
        }

        // Method specific to the Cat class
        public void Purr()
        {
            Console.WriteLine($"{Name} is purring.");
        }
    }
}