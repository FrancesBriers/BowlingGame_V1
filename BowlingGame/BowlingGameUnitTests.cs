using System.Reflection.Metadata;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BowlingGame
{

    [TestFixture]
    public class BowlingGameUnitTests
    {
        private Program.BowlingGame _bg;

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                _bg.Roll(pins);
            }
        }

        private void RollSpare()
        {
            _bg.Roll(5);
            _bg.Roll(5);
        }

        private void RollStrike()
        {
            _bg.Roll(10);
        }

        [SetUp]
        public void NewGame()
        {
            _bg = new Program.BowlingGame();
            //_bg = null;
        }

        [Test]
        public void GivenARollThenScore()
        {
            _bg.Roll(0);
            Assert.AreEqual(expected:0,actual: 0);
        }

        [Test]
        public void GivenAGutterBallThenStartScoring()
        {
            for (int i = 0; i < 20; i++)
            {
                _bg.Roll(0);
            }
            
            Assert.AreEqual(0, _bg.Score());
        }

        [Test]
        public void GivenAllGutterBallsThen0()
        {
            RollMany(20,0);
            Assert.AreEqual(0,_bg.Score());
        }

        [Test]
        public void GivenAll1SThen20()
        {
            RollMany(20,1);
            Assert.AreEqual(20,_bg.Score());
        }

        [Test]
        public void Given1SpareAnd19GutterBallsThenScoreEquals16()
        {
            RollSpare();
            _bg.Roll(pins:3);
            RollMany(17,0);
            Assert.AreEqual(16, _bg.Score());
        }

        [Test]
        public void GivenOneStrikeThenScoreEquals24()
        {
            RollStrike();
            _bg.Roll(3);
            _bg.Roll(4);

            RollMany(16, 0);
            Assert.AreEqual(24, _bg.Score());

        }

        [Test]
        public void Given12StrikeThenScoreEquals300()
        {
            RollMany(12,10);
            Assert.AreEqual(300, _bg.Score());
        }


    }
}