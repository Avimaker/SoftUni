/*
2
Solmyr 85 120
Kyrre 99 50
Heal - Solmyr - 10
Recharge - Solmyr - 50
TakeDamage - Kyrre - 66 - Orc
CastSpell - Kyrre - 15 - ViewEarth
End

4
Adela 90 150
SirMullich 70 40
Ivor 1 111
Tyris 94 61
Heal - SirMullich - 50
Recharge - Adela - 100
CastSpell - Tyris - 1000 - Fireball
TakeDamage - Tyris - 99 - Fireball
TakeDamage - Ivor - 3 - Mosquito
End

*/

namespace _05.HeroesOfCodeAndLogicVII;

class Hero
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int MP { get; set; }

    public Hero(string name, int hP, int mP)
    {
        Name = name;
        HP = hP;
        MP = mP;
    }
}


class Program
{
    static List<Hero> heroes = new List<Hero>();

    static void Main()
    {
        int heroesCount = int.Parse(Console.ReadLine());


        for (int i = 0; i < heroesCount; i++)
        {
            string[] heroInfo = Console.ReadLine().Split();
            string name = heroInfo[0];
            int hp = Math.Min(int.Parse(heroInfo[1]), 100);
            int mp = Math.Min(int.Parse(heroInfo[2]), 200);

            Hero hero = new Hero(name, hp, mp);
            heroes.Add(hero);
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] arguments = command.Split(" - ");
            string action = arguments[0];
            string heroName = arguments[1];

            if (action == "CastSpell")
            {
                int mpNeeded = int.Parse(arguments[2]);
                string spellName = arguments[3];
                CastSpell(heroName, mpNeeded, spellName);
            }
            else if (action == "TakeDamage")
            {
                int damage = int.Parse(arguments[2]);
                string attacker = arguments[3];
                TakeDamage(heroName, damage, attacker);
            }
            else if (action == "Recharge")
            {
                int amount = int.Parse(arguments[2]);
                Recharge(heroName, amount);
            }
            else if (action == "Heal")
            {
                int amount = int.Parse(arguments[2]);
                Heal(heroName, amount);
            }
        }

        PrintAliveHeroes(heroes);
    }

    static void CastSpell(string heroName, int mpNeeded, string spellName)
    {
        Hero foundHero = heroes.FirstOrDefault(h => h.Name == heroName);

        if (foundHero.MP >= mpNeeded)
        {
            foundHero.MP -= mpNeeded;
            Console.WriteLine($"{foundHero.Name} has successfully cast {spellName} and now has {foundHero.MP} MP!");
        }
        else
        {
            Console.WriteLine($"{foundHero.Name} does not have enough MP to cast {spellName}!");
        }
    }

    static void TakeDamage(string heroName, int damage, string attacker)
    {
        Hero foundHero = heroes.FirstOrDefault(h => h.Name == heroName);

        foundHero.HP -= damage;
        if (foundHero.HP > 0)
        {
            Console.WriteLine($"{foundHero.Name} was hit for {damage} HP by {attacker} and now has {foundHero.HP} HP left!");
        }
        else
        {
            Console.WriteLine($"{foundHero.Name} has been killed by {attacker}!");
        }
    }

    static void Recharge(string heroName, int amount)
    {
        Hero foundHero = heroes.FirstOrDefault(h => h.Name == heroName);

        int recovered = Math.Min(200 - foundHero.MP, amount);
        foundHero.MP += recovered;
        Console.WriteLine($"{foundHero.Name} recharged for {recovered} MP!");
    }

    static void Heal(string heroName, int amount)
    {
        Hero foundHero = heroes.FirstOrDefault(h => h.Name == heroName);

        int recovered = Math.Min(100 - foundHero.HP, amount);
        foundHero.HP += recovered;
        Console.WriteLine($"{foundHero.Name} healed for {recovered} HP!");
    }

    static void PrintAliveHeroes(List<Hero> heroes)
    {
        foreach (var hero in heroes)
        {
            if (hero.HP > 0)
            {
                Console.WriteLine($"{hero.Name}\n  HP: {hero.HP}\n  MP: {hero.MP}");
            }
        }
    }
}

