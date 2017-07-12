using System;
using System.Text;

namespace BookShop
{
    class Book
    {
        private string author;
        private string title;
        private double price;

        public Book(string author, string title, double price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                string[] authorNames = value.Split();
                bool hasAuthorSecondName = authorNames.Length == 2;
                if (hasAuthorSecondName)
                {
                    char firstLetterOfSecondName = authorNames[1][0];

                    if (char.IsDigit(firstLetterOfSecondName))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }


                this.author = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public virtual double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("Type: ")
              .Append(this.GetType().Name)
              .Append(Environment.NewLine)

              .Append($"Title: ")
              .Append(this.title)
              .Append(Environment.NewLine)

              .Append($"Author: ")
              .Append(this.author)
              .Append(Environment.NewLine)

              .Append($"Price: ")
              .Append($"{this.Price:f1}")
              .Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
