// File: BadDesign/ShapeExample.cs
namespace code_base.solid.LiskovSubstitutionPrinciple.BadDesign
{
    /// <summary>
    /// VIOLATION: The subclass `Square` changes the behavior of the base class `Rectangle`.
    ///
    /// Problems with this design:
    /// 1. Broken Contract: A `Rectangle` is expected to have its Width and Height set independently.
    ///    The `Square` class breaks this assumption by forcing Width and Height to be the same.
    /// 2. Unexpected Behavior: A method that works correctly with a `Rectangle` object will fail
    ///    or produce incorrect results when a `Square` object is passed to it. This violates LSP.
    /// 3. Fragility: The system becomes fragile because you cannot safely substitute a `Square` for a `Rectangle`.
    /// </summary>

    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public int GetArea() => Width * Height;
    }

    // A Square "is-a" Rectangle, so inheritance seems correct, but it leads to problems.
    public class Square : Rectangle
    {
        private int _side;

        public override int Width
        {
            get => _side;
            set
            {
                _side = value;
                base.Width = value;
                base.Height = value; // This breaks the independent nature of Width and Height
            }
        }

        public override int Height
        {
            get => _side;
            set
            {
                _side = value;
                base.Width = value;
                base.Height = value; // This breaks the independent nature of Width and Height
            }
        }
    }

    public class AreaCalculator
    {
        public static void CalculateAndPrintArea(Rectangle r)
        {
            // This method expects to set Width and Height independently.
            r.Width = 5;
            r.Height = 10;
            Console.WriteLine($"Expected Area: 50, Actual Area: {r.GetArea()}");
            if (r.GetArea() != 50)
            {
                Console.WriteLine("LSP Violation Detected! The behavior is incorrect.");
            }
        }
    }

    public class BadDesignExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Running Bad Design (Violating LSP) ---");

            Console.WriteLine("Testing with Rectangle:");
            Rectangle rect = new Rectangle();
            AreaCalculator.CalculateAndPrintArea(rect);

            Console.WriteLine("\nTesting with Square (the substitute):");
            Rectangle square = new Square();
            // Passing a Square object breaks the method's logic.
            AreaCalculator.CalculateAndPrintArea(square);

            Console.WriteLine("----------------------------------------\n");
        }
    }
}