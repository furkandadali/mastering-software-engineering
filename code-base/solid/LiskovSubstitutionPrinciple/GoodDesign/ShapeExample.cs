// File: GoodDesign/ShapeExample.cs
namespace code_base.solid.LiskovSubstitutionPrinciple.GoodDesign
{
    /// <summary>
    /// ADHERENCE: The inheritance hierarchy is corrected to ensure substitutability.
    ///
    /// Benefits of this design:
    /// 1. Correct Abstraction: `Shape` provides a suitable abstraction (`GetArea`) that all
    ///    concrete shapes can implement without breaking any assumptions.
    /// 2. Behavioral Consistency: Each class (`Rectangle`, `Square`) manages its own state
    ///    (Width/Height vs. Side) and correctly implements the `GetArea` method.
    /// 3. Robustness: Any function that works with a `Shape` can safely accept any subclass
    ///    of `Shape` (like `Rectangle` or `Square`) without fear of incorrect behavior.
    /// </summary>

    // A common abstraction for all shapes.
    public abstract class Shape
    {
        public abstract int GetArea();
    }

    // Rectangle implements the Shape abstraction.
    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override int GetArea() => Width * Height;
    }

    // Square also implements the Shape abstraction, managing its own properties.
    public class Square : Shape
    {
        public int Side { get; set; }

        public override int GetArea() => Side * Side;
    }

    public class GoodDesignExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Running Good Design (Adhering to LSP) ---");

            // We can treat both Rectangle and Square as a Shape.
            Shape rect = new Rectangle { Width = 5, Height = 10 };
            Shape square = new Square { Side = 5 };

            // The client code works with the abstraction and doesn't care about the concrete type.
            // The behavior is correct and predictable for all subtypes.
            Console.WriteLine($"Area of Rectangle: {rect.GetArea()}"); // Outputs 50
            Console.WriteLine($"Area of Square: {square.GetArea()}");   // Outputs 25

            Console.WriteLine("-----------------------------------------\n");
        }
    }
}