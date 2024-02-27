namespace ShoppingSpree
{
	public class Person
	{
		private string name;
		private decimal money;
		private List<Product> bag;

		public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
		{
			get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

		public decimal Money
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

        public string Add(Product product)
        {
            if (Money < product.Cost)
            {
                return $"{Name} can't afford {product.Name}";
            }

            bag.Add(product);

            Money -= product.Cost;

            return $"{Name} bought {product.Name}";
        }

        public override string ToString()
        {
            string productsString = bag.Any()
                 ? string.Join(", ", bag.Select(p => p.Name))
                 : "Nothing bought";

            return $"{Name} - {productsString}";
        }

    }
}

