using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RPSService
{
    public class RPSGame
    {
        private static readonly string ROCK = "R";
        private static readonly string PAPER = "P";
        private static readonly string SCISSOR = "S";
        private static readonly ISet<string> VALID_STRATEGIES = new HashSet<string>{ ROCK, PAPER, SCISSOR };

        public IList<string> TournamentWinner(IList<object> tournament) {
            if (tournament.Count == 0) {
                return new List<string>();
            }

            Stack<object> stackTounaments = new Stack<object>();
            stackTounaments.Push(tournament);

            List<IList<string>> listPlayers = new List<IList<string>>();

            while(stackTounaments.Count > 0) {
                var games = stackTounaments.Pop();

                var gamesList = games as IList;
                foreach (var game in gamesList)
                {
                    var list = (IList) game;
                    var first = list[0];
                    if (first is string) {
                        listPlayers.Add(game as IList<string>);
                    } else {
                        stackTounaments.Push(game);
                    }
                }
            }

            List<IList<string>> listTemp = new List<IList<string>>();
            while (listPlayers.Count > 1)
            {
                for (int i = 0; i < listPlayers.Count; i += 2)
                {
                    var player1 = listPlayers[i];
                    var player2 = listPlayers[i + 1];

                    var winner = GameWinner(new List<IList<string>>() { player1, player2 });

                    listTemp.Add(winner);
                }
                listPlayers = listTemp;
                listTemp = new List<IList<string>>();
            }


            return (IList<string>) listPlayers[0];
        }

        public IList<string> GameWinner(IList<IList<string>> game) 
        {
            ValidateNumberOfPlayers(game);
            UpperCaseStrategies(game);
            ValidateStrategies(game);

            var player1 = game[0][1];
            var player2 = game[1][1];

            if (Draw(player1, player2) || Beats(player1, player2)) {
                return game[0];
            }
            return game[1];
        }

        private bool Draw(string player1, string player2) {
            return player1.Equals(player2);
        }

        private bool Beats(string player1, string player2) {
            return (player1.Equals(ROCK) && player2.Equals(SCISSOR))
                || (player1.Equals(SCISSOR) && player2.Equals(PAPER))
                || (player1.Equals(PAPER) && player2.Equals(ROCK));
        }

        private void ValidateNumberOfPlayers(IList<IList<string>> game) 
        {
            if (game.Count != 2)
            {
                throw new WrongNumberOfPlayersException("the game have to be 2 players");
            }
        }

        private void UpperCaseStrategies(IList<IList<string>> game) {
            game[0][1] = game[0][1].ToUpper();
            game[1][1] = game[1][1].ToUpper();
        }

        private void ValidateStrategies(IList<IList<string>> game)
        {
            var noSuchStrategy = game.Count(p => !VALID_STRATEGIES.Contains(p[1])) > 0;
            if (noSuchStrategy)
            {
                throw new NoSuchStrategyException("some player has a invalid stratety;");
            }
        }
    }

    public class WrongNumberOfPlayersException : Exception
    {
        public WrongNumberOfPlayersException() {}
        public WrongNumberOfPlayersException(string message) : base(message) {}
        public WrongNumberOfPlayersException(string message, Exception inner) : base(message, inner) {}
    }

    public class NoSuchStrategyException : Exception
    {
        public NoSuchStrategyException() { }
        public NoSuchStrategyException(string message) : base(message) { }
        public NoSuchStrategyException(string message, Exception inner) : base(message, inner) { }
    }
}
