/*
Peter Charizard Fire 100
George Squirtle Water 38
Peter Pikachu Electricity 10
Tournament
Fire
Electricity
End

*/

namespace PokemonTrainer;
class StartUp
{
    static void Main()
    {

        HashSet<Trainer> trainers = new();

        string command = default;
        while ((command = Console.ReadLine()) != "Tournament")
        {
            string[] arguments = command.Split();
            string trainerName = arguments[0];
            string pokemonName = arguments[1];
            string pokemonElement = arguments[2];
            int pokemonHealth = int.Parse(arguments[3]);

            Trainer trainer = trainers.SingleOrDefault(n => n.Name == trainerName);//проверява дали името го има в списъка, ако не връща null
            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);//създавам си покемона

            if (trainer == null)
            {
                trainer = new(trainerName);//извикваме конструктора на класа трейнър, там създаваме име и инстанция на списък
                trainer.Pokemons.Add(pokemon);//добавяме инфото за покемона в този списък
                trainers.Add(trainer);//добавяме временния обект в крайния списък
            }
            else
            {
                trainer.Pokemons.Add(pokemon);//вече имаме име и само добавяме към списъка му покемони
            }
        }
        while ((command = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)//за всеки от списъка правим проверка за покемоните
            {
                trainer.CheckPokemon(command);
            }
        }

        foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
        }

    }


}

