namespace code_base.design_patterns.structural_design_patterns.decorator
{
    /// <summary>
    /// The Decorator Pattern
    ///
    /// Intent: Attach additional responsibilities to an object dynamically. Decorators provide a
    /// flexible alternative to subclassing for extending functionality. It allows behavior to be
    /// added to an individual object, either statically or dynamically, without affecting the
    /// behavior of other objects from the same class.
    ///
    /// Analogy: Ordering a coffee. You start with a simple coffee (the component) and then "decorate"
    /// it with milk, sugar, or whipped cream (the decorators). Each decorator adds to the cost and
    /// description of the final product.
    ///
    /// Key Components:
    /// 1. Component: The interface for objects that can have responsibilities added to them.
    /// 2. Concrete Component: The initisal object to which we can attach decorators.
    /// 3. Decorator: An abstract class that implements the Component interface and holds a reference to a Component object.
    /// 4. Concrete Decorator: Adds specific responsibilities to the Component it wraps.
    /// </summary>
    public class DecoratorExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Decorator Pattern Demonstration ---\n");

            // Start with a simple coffee
            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine($"1. Base Coffee -> Cost: ${coffee.GetCost()}, Description: {coffee.GetDescription()}");

            // Now, decorate it with Milk
            coffee = new MilkDecorator(coffee);
            Console.WriteLine($"2. Add Milk -> Cost: ${coffee.GetCost()}, Description: {coffee.GetDescription()}");

            // Now, decorate it with Sugar
            coffee = new SugarDecorator(coffee);
            Console.WriteLine($"3. Add Sugar -> Cost: ${coffee.GetCost()}, Description: {coffee.GetDescription()}");
            
            // You can also create a complex coffee in one go
            Console.WriteLine("\n--- Creating another complex coffee ---\n");
            ICoffee mySpecialCoffee = new SugarDecorator(new MilkDecorator(new SimpleCoffee()));
            Console.WriteLine($"My Special Coffee -> Cost: ${mySpecialCoffee.GetCost()}, Description: {mySpecialCoffee.GetDescription()}");


            Console.WriteLine("\n--- End of Demonstration ---");
        }
    }

    // 1. The Component Interface
    public interface ICoffee
    {
        double GetCost();
        string GetDescription();
    }

    // 2. The Concrete Component
    // This is the base object we will decorate.
    public class SimpleCoffee : ICoffee
    {
        public double GetCost()
        {
            return 5.0;
        }

        public string GetDescription()
        {
            return "Simple Coffee";
        }
    }

    // 3. The base Decorator
    // This abstract class implements the component interface and holds a reference
    // to a component object. It delegates calls to the wrapped component.
    public abstract class CoffeeDecorator : ICoffee
    {
        protected readonly ICoffee _coffee;

        protected CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public virtual double GetCost()
        {
            return _coffee.GetCost();
        }

        public virtual string GetDescription()
        {
            return _coffee.GetDescription();
        }
    }

    // 4. Concrete Decorator A
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override double GetCost()
        {
            // Add the cost of milk to the base coffee's cost
            return base.GetCost() + 1.5;
        }

        public override string GetDescription()
        {
            // Add the description of milk
            return base.GetDescription() + ", with Milk";
        }
    }

    // 4. Concrete Decorator B
    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override double GetCost()
        {
            // Add the cost of sugar
            return base.GetCost() + 0.5;
        }

        public override string GetDescription()
        {
            // Add the description of sugar
            return base.GetDescription() + ", with Sugar";
        }
    }
}