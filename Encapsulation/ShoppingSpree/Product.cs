using System;

internal class Product
{
    private string name;
    private double cost;

    public Product (string name, double cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    public string Name { get; set; }
    public double Cost { get; set; }
}

