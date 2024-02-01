using System;
namespace RawData
{
	public class Cargo
	{
		private int weight;
		private string type;

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }

        public int Weight
		{
			get { return this.weight; }
			set { this.weight = value; }
		}

		public string Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

	}
}

