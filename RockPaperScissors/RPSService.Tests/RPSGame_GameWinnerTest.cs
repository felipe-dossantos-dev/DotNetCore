using System.Collections.Generic;
using NUnit.Framework;
using RPSService;

namespace Tests
{
    public class RPSGame_GameWinnerTest
    {
        private readonly RPSGame _rpsGame;

        public RPSGame_GameWinnerTest()
        {
            _rpsGame = new RPSGame();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateNumberOfPlayers_LessThan2()
        {
            //Arrange
            IList<IList<string>> game = new List<IList<string>>() 
            {
                new List<string>() 
                {
                    "Armado", "P"
                }
            };

            //Act
            //Assert
            Assert.Throws(typeof(WrongNumberOfPlayersException), () => _rpsGame.GameWinner(game));
        }


        [Test]
        public void ValidateNumberOfPlayers_GreaterThan2()
        {
            //Arrange
            IList<IList<string>> game = new List<IList<string>>()
            {
                new List<string>()
                {
                    "Player1", "P"
                },
                new List<string>()
                {
                    "Player2", "R"
                },
                new List<string>()
                {
                    "Player1", "S"
                }
            };

            //Act
            //Assert
            Assert.Throws(typeof(WrongNumberOfPlayersException), () => _rpsGame.GameWinner(game));
        }

        [Test]
        public void ValidateStrategies_InvalidStrategy()
        {
            //Arrange
            IList<IList<string>> game = new List<IList<string>>()
            {
                new List<string>()
                {
                    "Player1", "P"
                },
                new List<string>()
                {
                    "Player2", "V"
                }
            };

            //Act
            //Assert
            Assert.Throws(typeof(NoSuchStrategyException), () => _rpsGame.GameWinner(game));
        }

        [Test]
        public void Draw()
        {
            //Arrange
            var expected = new List<string>()
            {
                "Player1", "P"
            };

            IList<IList<string>> game = new List<IList<string>>()
            {
                expected,
                new List<string>()
                {
                    "Player2", "P"
                }
            };

            //Act
            var actual = _rpsGame.GameWinner(game);
            
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Player1_RockBeatsScissors()
        {
            //Arrange
            var expected = new List<string>()
            {
                "Player1", "R"
            };

            IList<IList<string>> game = new List<IList<string>>()
            {
                expected,
                new List<string>()
                {
                    "Player2", "s"
                }
            };

            //Act
            var actual = _rpsGame.GameWinner(game);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Player1_ScissorsBeatsPaper()
        {
            //Arrange
            var expected = new List<string>()
            {
                "Player1", "S"
            };

            IList<IList<string>> game = new List<IList<string>>()
            {
                expected,
                new List<string>()
                {
                    "Player2", "p"
                }
            };

            //Act
            var actual = _rpsGame.GameWinner(game);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Player1_PaperBeatsRock()
        {
            //Arrange
            var expected = new List<string>()
            {
                "Player1", "P"
            };

            IList<IList<string>> game = new List<IList<string>>()
            {
                expected,
                new List<string>()
                {
                    "Player2", "R"
                }
            };

            //Act
            var actual = _rpsGame.GameWinner(game);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        public void Player2_RockBeatsScissors()
        {
            //Arrange
            var expected = new List<string>()
            {
                "Player2", "R"
            };

            IList<IList<string>> game = new List<IList<string>>()
            {
                new List<string>()
                {
                    "Player1", "s"
                },
                expected
            };

            //Act
            var actual = _rpsGame.GameWinner(game);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Player2_ScissorsBeatsPaper()
        {
            //Arrange
            var expected = new List<string>()
            {
                "Player2", "S"
            };

            IList<IList<string>> game = new List<IList<string>>()
            {
                new List<string>()
                {
                    "Player1", "P"
                },
                expected
            };

            //Act
            var actual = _rpsGame.GameWinner(game);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Player2_PaperBeatsRock()
        {
            //Arrange
            var expected = new List<string>()
            {
                "Player2", "P"
            };

            IList<IList<string>> game = new List<IList<string>>()
            {
                new List<string>()
                {
                    "Player1", "R"
                },
                expected
            };

            //Act
            var actual = _rpsGame.GameWinner(game);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}