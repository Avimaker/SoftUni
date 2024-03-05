using System;
namespace Raiding.Models;

public class Druid : BaseHero
{
    private const int DefaultPower = 80;

    public Druid(string name) : base(name, DefaultPower)
    {
    }

    public override string CastAbility()
    {
        return $"{this.GetType().Name} - {Name} healed for {Power}";
    }
}

