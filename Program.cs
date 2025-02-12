using System;

// Define a delegate for the accident event
public delegate void AccidentHandler(string vehicleName);

// Base class for all vehicles
public class Vehicle
{
    public string Name { get; set; }

    // Make the event nullable by adding '?'
    public static event AccidentHandler? OnAccident;

    public Vehicle(string name)
    {
        Name = name;
        // Subscribe this vehicle's response method to the accident event
        OnAccident += RespondToAccident;
    }

    // Method to trigger an accident
    public void AccidentOccurred()
    {
        Console.WriteLine($"\n*** {Name} has been in an accident! ***");
        // Invoke the accident event if there are any subscribers
        OnAccident?.Invoke(Name);
    }

    // Virtual method to respond to an accident
    public virtual void RespondToAccident(string vehicleName)
    {
        if (vehicleName != this.Name)
        {
            Console.WriteLine($"{Name} received notification that {vehicleName} had an accident.");
        }
    }
}

// Derived class: Bicycle
public class Bicycle : Vehicle
{
    public Bicycle(string name) : base(name) { }

    public override void RespondToAccident(string vehicleName)
    {
        base.RespondToAccident(vehicleName);
        if (vehicleName != this.Name)
        {
            Console.WriteLine($"{Name} is slowing down due to {vehicleName}'s accident.");
        }
    }
}

// Derived class: Motorcycle
public class Motorcycle : Vehicle
{
    public Motorcycle(string name) : base(name) { }

    public override void RespondToAccident(string vehicleName)
    {
        base.RespondToAccident(vehicleName);
        if (vehicleName != this.Name)
        {
            Console.WriteLine($"{Name} is checking its surroundings after hearing about {vehicleName}'s accident.");
        }
    }
}

// Main application
public class Program
{
    public static void Main(string[] args)
    {
        // Create instances of vehicles
        Vehicle bike1 = new Bicycle("Bike1");
        Vehicle bike2 = new Bicycle("Bike2");
        Vehicle moto1 = new Motorcycle("Moto1");

        // Simulate an accident with Moto1
        moto1.AccidentOccurred();

        // Optionally, simulate another accident with Bike2
        bike2.AccidentOccurred();

        Console.ReadKey();
    }
}