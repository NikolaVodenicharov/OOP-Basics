using System;
using System.Collections.Generic;

internal class Person
{
    private string name;
    private double money;
    private List<Product> bagOfProducts;

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public double Money
    {
        get { return this.money; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.money = value;
        }
    }

    public List<Product> BagOfProducts
    {
        get { return this.bagOfProducts; }
    }

    public Person (string name, double money)
    {
        this.Name = name;
        this.Money = money;
        this.bagOfProducts = new List<Product>();
    }

    public void AddProductToBagOfProducts(Product inputProduct)
    {
        if (inputProduct.Cost > this.money)
        {
            throw new ArgumentException($"{this.name} can't afford {inputProduct.Name}");
        }

        this.bagOfProducts.Add(inputProduct);
        this.money -= inputProduct.Cost;
    }
}

