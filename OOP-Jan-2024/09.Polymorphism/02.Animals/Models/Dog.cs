
using System.Text;

namespace Animals.Models;

public class Dog : Animal
{
    public Dog(string name, string favouriteFood) : base(name, favouriteFood)
    {
    }

    public override string ExplainSelf()
    {
        //Var 1
        return base.ExplainSelf() + Environment.NewLine + "DJAAF";

        ////Var2
        //StringBuilder sb = new();

        //sb.AppendLine(base.ExplainSelf());
        //sb.AppendLine("DJAAF");
        //return sb.ToString().Trim();
    }

}

