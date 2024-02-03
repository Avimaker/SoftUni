using System;
namespace PokemonTrainer
{
	public class Trainer
	{
		private string name;
		private int numberOfBadges;
		private List<Pokemon> pokemons;//когато имаме лист задължително правим инстнция в конструктора

        public Trainer(string name)
        {
            Name = name; //добавяме име на листа
            Pokemons = new(); //правим инстанция на списъка с дефолтна стойност
        }

        public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		public int NumberOfBadges
        {
			get { return this.numberOfBadges; }
			set { this.numberOfBadges = value; }
		}

		public List<Pokemon> Pokemons
        {
			get { return pokemons; }
			set { this.pokemons = value; }
		}

		public void CheckPokemon(string command)
		{
			if (Pokemons.Any(p => p.Element == command))//проверяваме дали елемента съшествува в списъка с покемони
			{
				numberOfBadges++; //ако да добавяме една значка
			}
			else //ако не ..
			{
				for (int i = 0; i < Pokemons.Count; i++) //въртим по списъка с покемони и намаляваме здравето на всеки с 10
				{
					Pokemon currentPokemon = Pokemons[i];
					currentPokemon.Health -= 10;

					if (currentPokemon.Health <= 0) //ако здравето на временния покемон падне под нула или е раяно на 0 го махаме от обшия списък
					{
						Pokemons.Remove(currentPokemon);
					}
				}
			}

		}
	}
}

