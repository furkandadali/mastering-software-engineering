namespace code_base.oop.polymorphism
{
    // Base class
    public abstract class Shape
    {
        // Abstract method, has no body and must be implemented by derived classes
        public abstract void Draw();
    }

    // Derived class
    public class Circle : Shape
    {
        // Provide implementation for the abstract method
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle");
        }
    }

    // Derived class
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle");
        }
    }

    // Derived class
    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a triangle");
        }
    }

    public class PolymorphismExample
    {
        public void RunExample()
        {
            // Create a list of Shape objects.
            // Notice we can add Circle, Rectangle, and Triangle objects
            // because they all inherit from Shape.
            var shapes = new List<Shape>
            {
                new Circle(),
                new Rectangle(),
                new Triangle()
            };

            // Loop through the shapes and call the Draw method on each.
            // This is polymorphism in action. The same method call (shape.Draw())
            // behaves differently depending on the actual object type.
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
            
            // Expected output:
            // Drawing a circle
            // Drawing a rectangle
            // Drawing a triangle
        }
    }
}