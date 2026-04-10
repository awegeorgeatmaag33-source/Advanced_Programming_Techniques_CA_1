using System;
using System.Collections.Generic;

class Elements
{
    public int AtomicNumber {get;set;}
    public string Name {get; set;}

    public string Symbol {get; set;}

    public double AtomicMass {get; set;}

public Elements(int atomicnumber, string name, string symbol, double atomicmass)
{
    AtomicNumber = atomicnumber;
    Name = name;
    Symbol = symbol;
    AtomicMass = atomicmass;
}
public void Display()
    {
        Console.WriteLine("Atomic Number: " + AtomicNumber);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Symbol: " + Symbol);
        Console.WriteLine("Atomic Mass: " + AtomicMass);
    }

    class Program
    {
        static void Main()
        {
            //Creating a list to store the first 30 elements
            List<Elements> PerisodicTable = new List<Elements>()
            {
                new Elements(1, "Hydrogen", "H", 1.008),
                new Elements(2, "Helium", "He", 4.0026),
                new Elements(3, "Lithium", "Li", 6.94),
                new Elements(4, "Berylium", "Be", 9.0122),
                new Elements(5, "Boron", "B", 10.81),
                new Elements(6, "Carbon", "C", 12.011),
                new Elements(7, "Nitrogen", "N", 14.007),
                new Elements(8, "Oxygen", "O", 15.999),
                new Elements(9, "Flourine", "F", 18.998),
                new Elements(10, "Neon", "Ne", 20.180),
                new Elements(11, "Sodium", "Na", 22.990),
                new Elements(12, "Magnesium", "Mg", 24.305),
                new Elements(13, "Aluminium", "Al", 26.982),
                new Elements(14, "Silicon", "Si", 28.085),
                new Elements(15, "Phosphorus", "P", 30.974),
                new Elements(16, "Sulfur", "S", 32.06),
                new Elements(17, "Chlorine", "Cl", 35.45),
                new Elements(18, "Argon", "Ar", 39.948),
                new Elements(19, "Potassium", "K", 39.098),
                new Elements(20, "Calcium", "Ca", 40.078),
                new Elements(21, "Scandium", "Sc", 44.956),
                new Elements(22, "Titanium", "Ti", 47.867),
                new Elements(23, "Vanadium", "V", 50.942),
                new Elements(24, "Chromium", "Cr", 51.996),
                new Elements(25, "Manganese", "Mn", 54.938),
                new Elements(26, "Iron", "Fe", 55.845),
                new Elements(27, "Cobalt", "Co", 58.933),
                new Elements(28, "Nickel", "Ni", 58.693),
                new Elements(29, "Copper", "Cu", 63.546),
                new Elements(30, "Zinc", "Zn", 65.38),
            };

            string choice = "y";
            while (choice.ToLowerInvariant() == "y")
            {
            Console.Write("Enter the atomic number: ");
            int atomicNumber;
            bool isValid = int.TryParse(Console.ReadLine(), out atomicNumber);
            if (!isValid || atomicNumber < 1 || atomicNumber > 30)
            {
                Console.WriteLine("Incorrect imput. Please enter a number betwwen 1 aandd 30.");
            }
            else
            {
                // Finding the element with the given atomic number
                Elements elements = PerisodicTable.FirstOrDefault(e => e.AtomicNumber == atomicNumber);
                elements.Display();
            }
            Console.Write("Do you want to search for another element? (Y/N): ");
            choice = Console.ReadLine();
            }
        Console.WriteLine("Thank you for using the Periodic Table Elements program. Goodbye!");
        }
    }
}
    
