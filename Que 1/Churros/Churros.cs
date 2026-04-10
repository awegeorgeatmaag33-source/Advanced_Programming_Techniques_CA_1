using System;

public class Churros
{
    // Private fields (Encapsulation)
    private string name;
    private double price;

    // Constructor
    public Churros(string name, double price)
    {
        this.name = name;
        this.price = price;
    }

    // Properties
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Price
    {
        get { return price; }
        set { price = value; }
    }
}