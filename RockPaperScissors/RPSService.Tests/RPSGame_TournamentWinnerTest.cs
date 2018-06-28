using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using RPSService;

namespace Tests
{
    public class RPSGame_TournamentWinnerTest
    {
        private readonly RPSGame _rpsGame;

        public RPSGame_TournamentWinnerTest()
        {
            _rpsGame = new RPSGame();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ZeroTournament()
        {
            //Arrange
            //Act
            var actual = _rpsGame.TournamentWinner(new List<object>());
            //Assert
            Assert.AreEqual(new List<string>(), actual);
        }

        [Test]
        public void OneGameOneTournament()
        {
            //Arrange
            var expected = new List<string>()
            {
                "Richard", "R"
            };

            IList<IList<string>> game = new List<IList<string>>()
            {
                expected,
                new List<string>()
                {
                    "Player1", "R"
                }
            };

            //Act
            var actual = _rpsGame.TournamentWinner(new List<object>() { game });

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TwoGameOneTournament()
        {
            //Arrange
            var expected = new List<string>()
            {
                "Richard", "R"
            };

            IList<IList<object>> games = new List<IList<object>>()
            {
                new List<object>() 
                {
                    new List<string>() { "Armando", "P" },
                    new List<string>() { "Dave", "S" }
                },
                new List<object>() 
                {
                    expected,
                    new List<string>() { "Michael", "S" }
                },
            };

            //Act
            var actual = _rpsGame.TournamentWinner(new List<object>() { games });

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FourGameOneTournament()
        {
            //Arrange
            var expected = new List<string>()
            {
                "Richard", "R"
            };

            IList<IList<object>> games = new List<IList<object>>()
            {
                new List<object>()
                {
                    new List<string>() { "Armando", "P" },
                    new List<string>() { "Dave", "S" }
                },
                new List<object>()
                {
                    expected,
                    new List<string>() { "Michael", "S" }
                },
                new List<object>()
                {
                    new List<string>() { "Allen", "S" },
                    new List<string>() { "Omer", "P" }
                },
                new List<object>()
                {
                    new List<string>() { "David E.", "R" },
                    new List<string>() { "Richard X.", "P" }
                },
            };

            //Act
            var actual = _rpsGame.TournamentWinner(new List<object>() { games });

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FourGameTwoTournament()
        {
            //Arrange
            var expected = new List<string>()
            {
                "Richard", "R"
            };

            IList<IList<object>> games = new List<IList<object>>()
            {
                new List<object>() 
                {
                    new List<IList<string>>()
                    {
                        new List<string>() { "Armando", "P" },
                        new List<string>() { "Dave", "S" }
                    },
                    new List<object>()
                    {
                        expected,
                        new List<string>() { "Michael", "S" }
                    },
                },
                new List<object>()
                {
                    new List<object>()
                    {
                        new List<string>() { "Allen", "S" },
                        new List<string>() { "Omer", "P" }
                    },
                    new List<object>()
                    {
                        new List<string>() { "David E.", "R" },
                        new List<string>() { "Richard X.", "P" }
                    },
                }
            };

            //Act
            var actual = _rpsGame.TournamentWinner(new List<object>() { games });

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FourGameThreeTournament()
        {
            //Arrange
            var expected = new List<string>()
            {
                "Richard", "R"
            };

            IList<IList> games = new List<IList>()
            {
                new List<IList>()
                {
                    new List<object>()
                    {
                        new List<string>() { "Armando", "P" },
                        new List<string>() { "Dave", "S" }
                    },
                    new List<object>()
                    {
                        expected,
                        new List<string>() { "Michael", "S" }
                    },
                },
                new List<IList>()
                {
                    new List<object>()
                    {
                        new List<string>() { "Allen", "S" },
                        new List<string>() { "Omer", "P" }
                    }
                },
                new List<IList>()
                {
                    new List<object>()
                    {
                        new List<string>() { "David E.", "R" },
                        new List<string>() { "Richard X.", "P" }
                    }
                }
            };

            //Act
            var actual = _rpsGame.TournamentWinner(new List<object>() { games });

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}