using System;
using System.Collections.Generic;

internal class Person
{
    private string name;
    private double money;
    private List<Product> bagOfProducts;

    public Person(string name, double money)
    {
        this.Name = name;
        this.Money = money;
        this.bagOfProducts = new List<Product>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{nameof(Name)} cannot be empty");
            }

            this.name = value;
        }
    }

    public double Money
    {
        get
        {
            return this.money;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(Money)} cannot be negative");
            }

            this.money = value;
        }
    }

    public List<Product> BagOfProducts
    {
        get { return this.bagOfProducts; }
    }



    public void AddProductToBagOfProducts(Product inputProduct)
    {
        if (inputProduct.Money > this.money)
        {
            throw new ArgumentException($"{this.name} can't afford {inputProduct.Name}");
        }

        this.bagOfProducts.Add(inputProduct);
        this.money -= inputProduct.Money;
    }
}

