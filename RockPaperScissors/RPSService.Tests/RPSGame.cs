using NUnit.Framework;
using RPSService;

namespace Tests
{
    public class RPSGame_GameWinner
    {
        private readonly RPSGame _rpsGame;

        public RPSGame_GameWinner()
        {
            _rpsGame = new RPSGame();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var result = _rpsGame.IsPrime(1);

            Assert.IsFalse(result, "1 should not be prime");
        }
    }
}