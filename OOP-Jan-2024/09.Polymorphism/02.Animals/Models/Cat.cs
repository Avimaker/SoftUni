
using System.Text;

namespace Animals.Models;

public class Cat : Animal
	{
    public Cat(string name, string favouriteFood) : base(name, favouriteFood)
    {
    }

    public override string ExplainSelf()
    {
        //Var1
        return base.ExplainSelf() + Environment.NewLine + "MEEOW";

        ////Var2
        //StringBuilder sb = new();

        //sb.AppendLine(base.ExplainSelf());
        //sb.AppendLine("MEOOW");
        //return sb.ToString().Trim();
    }
    
}

