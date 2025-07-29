namespace code_base.oop.abstraction;

/// <summary>
/// Abstraction Example: Vehicle Management System
/// 
/// Abstraction is one of the four fundamental OOP principles that involves:
/// 1. Hiding Implementation Details: Focus on what an object does, not how it does it
/// 2. Providing Simple Interfaces: Expose only essential features to the user
/// 3. Managing Complexity: Break down complex systems into manageable parts
/// 4. Defining Contracts: Use abstract classes and interfaces to define structure
/// </summary>
public class AbstractionExample
{
    public static void DemonstrateAbstraction()
    {
        Console.WriteLine("=== Abstraction Demonstration ===\n");
        
        // Create different vehicles using abstraction
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Car("Toyota Camry", "ABC123", 4),
            new Motorcycle("Harley Davidson", "XYZ789", true),
            new Truck("Ford F-150", "TRK456", 2000)
        };
        
        // Demonstrate abstraction - we interact with vehicles through their abstract interface
        // We don't need to know the specific implementation details of each vehicle type
        Console.WriteLine("--- Vehicle Operations (Using Abstraction) ---");
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"\n{vehicle.GetVehicleInfo()}");
            
            // Abstract methods - implementation hidden from user
            vehicle.Start();
            vehicle.Accelerate();
            vehicle.Stop();
            
            // Interface methods - contract-based operations
            if (vehicle is IFuelable fuelableVehicle)
            {
                fuelableVehicle.Refuel();
            }
            
            if (vehicle is IMaintainable maintainableVehicle)
            {
                maintainableVehicle.PerformMaintenance();
            }
            
            Console.WriteLine($"Fuel Level: {vehicle.FuelLevel}%");
            Console.WriteLine("---");
        }
        
        // Demonstrate polymorphism with abstraction
        Console.WriteLine("\n--- Fleet Management (Polymorphism with Abstraction) ---");
        var fleetManager = new FleetManager();
        fleetManager.ManageFleet(vehicles);
    }
}

// Interface - Pure Abstraction (Contract Definition)
public interface IFuelable
{
    void Refuel();
    double FuelCapacity { get; }
}

public interface IMaintainable
{
    void PerformMaintenance();
    DateTime LastMaintenanceDate { get; }
}

// Abstract Class - Partial Abstraction (Common Structure + Some Implementation)
public abstract class Vehicle : IFuelable, IMaintainable
{
    // Common properties for all vehicles
    protected string _model;
    protected string _licensePlate;
    protected double _fuelLevel;
    protected bool _isRunning;
    protected DateTime _lastMaintenanceDate;
    
    // Constructor
    protected Vehicle(string model, string licensePlate)
    {
        _model = model;
        _licensePlate = licensePlate;
        _fuelLevel = 100.0; // Start with full tank
        _isRunning = false;
        _lastMaintenanceDate = DateTime.Now.AddDays(-30); // Last maintained a month ago
    }
    
    // Abstract methods - must be implemented by derived classes
    public abstract void Start();
    public abstract void Accelerate();
    public abstract void Stop();
    public abstract string GetVehicleType();
    
    // Concrete methods - common implementation for all vehicles
    public virtual string GetVehicleInfo()
    {
        return $"{GetVehicleType()}: {_model} ({_licensePlate})";
    }
    
    // Interface implementation - can be overridden if needed
    public virtual void Refuel()
    {
        Console.WriteLine($"Refueling {_model}...");
        _fuelLevel = 100.0;
        Console.WriteLine("Fuel tank is now full.");
    }
    
    public virtual void PerformMaintenance()
    {
        Console.WriteLine($"Performing maintenance on {_model}...");
        _lastMaintenanceDate = DateTime.Now;
        Console.WriteLine("Maintenance completed.");
    }
    
    // Properties
    public double FuelLevel => _fuelLevel;
    public abstract double FuelCapacity { get; }
    public DateTime LastMaintenanceDate => _lastMaintenanceDate;
    
    // Protected method - available to derived classes only
    protected void ConsumeFuel(double amount)
    {
        _fuelLevel = Math.Max(0, _fuelLevel - amount);
    }
}

// Concrete Implementation - Car
public class Car : Vehicle
{
    private int _numberOfDoors;
    
    public Car(string model, string licensePlate, int numberOfDoors) 
        : base(model, licensePlate)
    {
        _numberOfDoors = numberOfDoors;
    }
    
    // Abstract method implementations - specific to Car
    public override void Start()
    {
        Console.WriteLine($"Starting car engine for {_model}");
        _isRunning = true;
    }
    
    public override void Accelerate()
    {
        if (_isRunning)
        {
            Console.WriteLine($"Car {_model} is accelerating smoothly");
            ConsumeFuel(2.0);
        }
        else
        {
            Console.WriteLine("Cannot accelerate - car is not running");
        }
    }
    
    public override void Stop()
    {
        Console.WriteLine($"Car {_model} is stopping");
        _isRunning = false;
    }
    
    public override string GetVehicleType()
    {
        return "Car";
    }
    
    public override double FuelCapacity => 60.0; // 60 liters
    
    public override string GetVehicleInfo()
    {
        return base.GetVehicleInfo() + $" - {_numberOfDoors} doors";
    }
}

// Concrete Implementation - Motorcycle
public class Motorcycle : Vehicle
{
    private bool _hasSidecar;
    
    public Motorcycle(string model, string licensePlate, bool hasSidecar) 
        : base(model, licensePlate)
    {
        _hasSidecar = hasSidecar;
    }
    
    public override void Start()
    {
        Console.WriteLine($"Kicking start motorcycle {_model}");
        _isRunning = true;
    }
    
    public override void Accelerate()
    {
        if (_isRunning)
        {
            Console.WriteLine($"Motorcycle {_model} is accelerating with a roar!");
            ConsumeFuel(3.0);
        }
        else
        {
            Console.WriteLine("Cannot accelerate - motorcycle is not running");
        }
    }
    
    public override void Stop()
    {
        Console.WriteLine($"Motorcycle {_model} is braking");
        _isRunning = false;
    }
    
    public override string GetVehicleType()
    {
        return "Motorcycle";
    }
    
    public override double FuelCapacity => 20.0; // 20 liters
    
    public override string GetVehicleInfo()
    {
        return base.GetVehicleInfo() + (_hasSidecar ? " with sidecar" : "");
    }
}

// Concrete Implementation - Truck
public class Truck : Vehicle
{
    private double _cargoCapacity;
    
    public Truck(string model, string licensePlate, double cargoCapacity) 
        : base(model, licensePlate)
    {
        _cargoCapacity = cargoCapacity;
    }
    
    public override void Start()
    {
        Console.WriteLine($"Starting diesel engine for truck {_model}");
        _isRunning = true;
    }
    
    public override void Accelerate()
    {
        if (_isRunning)
        {
            Console.WriteLine($"Truck {_model} is accelerating slowly but powerfully");
            ConsumeFuel(5.0);
        }
        else
        {
            Console.WriteLine("Cannot accelerate - truck is not running");
        }
    }
    
    public override void Stop()
    {
        Console.WriteLine($"Truck {_model} is using air brakes to stop");
        _isRunning = false;
    }
    
    public override string GetVehicleType()
    {
        return "Truck";
    }
    
    public override double FuelCapacity => 200.0; // 200 liters
    
    public override string GetVehicleInfo()
    {
        return base.GetVehicleInfo() + $" - Cargo capacity: {_cargoCapacity}kg";
    }
    
    // Truck-specific method
    public void LoadCargo()
    {
        Console.WriteLine($"Loading cargo into {_model}");
    }
}

// Class that uses abstraction to manage different vehicle types
public class FleetManager
{
    public void ManageFleet(List<Vehicle> vehicles)
    {
        Console.WriteLine("Fleet Manager: Managing vehicle operations...\n");
        
        foreach (var vehicle in vehicles)
        {
            // Using abstraction - we don't need to know specific vehicle types
            Console.WriteLine($"Managing {vehicle.GetVehicleInfo()}");
            
            // Check if vehicle needs fuel
            if (vehicle.FuelLevel < 20)
            {
                Console.WriteLine("Low fuel detected - scheduling refuel");
                vehicle.Refuel();
            }
            
            // Check if vehicle needs maintenance
            if (DateTime.Now.Subtract(vehicle.LastMaintenanceDate).TotalDays > 90)
            {
                Console.WriteLine("Maintenance due - scheduling service");
                vehicle.PerformMaintenance();
            }
            
            Console.WriteLine();
        }
    }
}