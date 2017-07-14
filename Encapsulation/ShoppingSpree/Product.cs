using System;

internal class Product
{
    private string name;
    private double money;

    public Product (string name, double money)
    {
        this.Name = name;
        this.Money = money;
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
}

