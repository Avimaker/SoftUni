using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> _players;
        private IRepository<ITeam> _teams;
        private string[] validPlayerTypes = { "Goalkeeper", "CenterBack", "ForwardWing" };

        public Controller()
        {
            _players = new PlayerRepository();
            _teams = new TeamRepository();
        }

        public string NewTeam(string name)
        {
            Team team = new Team(name);
            if (_teams.ExistsModel(name))
            {
                //return String.Format(OutputMessages.TeamAlreadyExists, name, "TeamRepository");
                return $"{name} is already added to the TeamRepository.";
            }
            _teams.AddModel(team);
            return $"{name} is successfully added to the TeamRepository.";
        }

        public string NewPlayer(string typeName, string name)
        {

            //това е единия вариянт - за другия е с прайвит поле масив
            if (typeName != "Goalkeeper" && typeName != "CenterBack" && typeName != "ForwardWing")
            {
                return $"{typeName} is invalid position for the application.";
            }

            ////  това е с масив от верни типове проверка
            //if (!validPlayerTypes.Contains(typeName))
            //{
            //    return $"{typeName} is invalid position for the application.";
            //}

            if (_players.ExistsModel(name))
            {
                IPlayer existingPlayer = _players.GetModel(name);
                return $"{name} is already added to the {_players.GetType().Name} as {existingPlayer.GetType().Name}.";
            }

            IPlayer newPlayer = null;
            ////това да си го имам просто
            //Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsAssignableFrom(typeof(IPlayer)));

            if (typeName == "Goalkeeper")
            {
                newPlayer = new Goalkeeper(name);
            }
            if (typeName == "CenterBack")
            {
                newPlayer = new CenterBack(name);
            }
            if (typeName == "ForwardWing")
            {
                newPlayer = new ForwardWing(name);
            }

            _players.AddModel(newPlayer);

            //return $"{name} is filed for the handball league.";
            return String.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!_players.ExistsModel(playerName))
            {
                return $"Player with the name {playerName} does not exist in the {nameof(PlayerRepository)}.";
                ////да пробвам и ако гърми да сложа това:
                //return $"Player with the name {playerName} does not exist in the {typeof(PlayerRepository).Name}.";
            }

            if (!_teams.ExistsModel(teamName))
            {
                return $"Team with the name {teamName} does not exist in the {_teams.GetType().Name}.";
                //return $"Team with the name {teamName} does not exist in the {typeof(TeamRepository).Name}.";

            }

            //тук идеята е като се подаде име с грешен отбор да върне името с правилен отбор - правим го през метод
            if (_players.GetModel(playerName).Team != null)
            {
                return $"Player {playerName} has already signed with {_players.GetModel(playerName).Team}.";
            }

            IPlayer contractPlayer = _players.GetModel(playerName);
            ITeam contractTeam = _teams.GetModel(teamName);

            ////нама сеттер и затова гърми - трябва да го сетнем през метода
            //contractPlayer.Team = contractTeam.Name;

            contractPlayer.JoinTeam(contractTeam.Name);//така се добавя отбор с договор към инфото на играча
            contractTeam.SignContract(contractPlayer);//така се добавят плеъри към тима

            return $"Player {playerName} signed a contract with {teamName}.";

        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = _teams.GetModel(firstTeamName);
            ITeam secondTeam = _teams.GetModel(secondTeamName);

            double ratingsTeam1 = firstTeam.OverallRating;
            double ratingsTeam2 = secondTeam.OverallRating;

            if (ratingsTeam1 > ratingsTeam2)
            {
                firstTeam.Win();
                secondTeam.Lose();
                return $"Team {firstTeam.Name} wins the game over {secondTeam.Name}!";
            }
            else if (ratingsTeam1 < ratingsTeam2)
            {
                secondTeam.Win();
                firstTeam.Lose();
                return $"Team {secondTeam.Name} wins the game over {firstTeam.Name}!";
            }
            else
            {
                firstTeam.Draw();
                secondTeam.Draw();
                return $"The game between {firstTeam.Name} and {secondTeam.Name} ends in a draw!";
            }
        }

        public string PlayerStatistics(string teamName)
        {
            ITeam team = _teams.GetModel(teamName);
            List<IPlayer> playerList = team.Players.OrderByDescending(p => p.Rating).ThenBy(p => p.Name).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***{teamName}***");
            foreach (var item in playerList)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }

        public string LeagueStandings()
        {
            List<ITeam> teamsList = _teams.Models
                .OrderByDescending(p => p.PointsEarned)
                .ThenByDescending(p => p.OverallRating)
                .ThenBy(p => p.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***League Standings***");
            foreach (var item in teamsList)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}

