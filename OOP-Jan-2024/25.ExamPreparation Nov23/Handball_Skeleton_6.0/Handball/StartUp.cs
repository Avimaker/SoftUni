using Handball.Core;
using Handball.Core.Contracts;

namespace Handball
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();            
        }
    }
}

/*
NewTeam FireBall
NewTeam DribbleDown
NewTeam NetNavigators
NewTeam InGoodHands
NewTeam InGoodHands
NewPlayer Goalkeeper John Smith
NewPlayer CenterBack Al Johnson
NewPlayer CenterBack Bob Thompson
NewPlayer ForwardWing Charlie Davis
NewPlayer ForwardWing David Wilson
NewPlayer Goalkeeper Emil Brown
NewPlayer CenterBack Fred Clark
NewPlayer CenterBack Rodrigo Grade
NewPlayer ForwardWing Henry Lee
NewPlayer ForwardWing Isaac Mitchell
NewPlayer Goalkeeper Jack Davis
NewPlayer CenterBack Kyle Anderson
NewPlayer CenterBack Liam Taylor
NewPlayer ForwardWing Matthew Reed
NewPlayer ForwardWing Nathan Cooper
NewPlayer Midfielder Oliver Johnson
NewPlayer CenterBack John Smith
NewPlayer Goalkeeper Samuel Thompson
NewContract John Smith FireBall
NewContract Al Johnson FireBall
NewContract Bob Thompson FireBall
NewContract Charlie Davis FireBall
NewContract David Wilson FireBall
NewContract Emil Brown DribbleDown
NewContract Fred Clark DribbleDown
NewContract Rodrigo Grade DribbleDown
NewContract Henry Lee DribbleDown
NewContract Isaac Mitchell DribbleDown
NewContract Jack Davis NetNavigators
NewContract Kyle Anderson NetNavigators
NewContract Liam Taylor NetNavigators
NewContract Matthew Reed NetNavigators
NewContract Nathan Cooper NetNavigators
NewContract Dilan Zee InGoodHands
NewContract Samuel Thopmson PassFast
NewContract Matthew Reed NetNavigators
NewContract Matthew Reed DribbleDown
NewGame FireBall DribbleDown
NewGame FireBall NetNavigators
NewGame NetNavigators DribbleDown
PlayerStatistics FireBall
LeagueStandings

NewContract Matthew Reed DribbleDown

Exit
    */