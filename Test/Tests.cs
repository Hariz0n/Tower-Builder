using System;
using NUnit.Framework;
using FluentAssertions;
using TowerBuilder.Domain;

namespace Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void IsEmpty()
        {
            var field = new Field(5, Difficulty.Easy);
            field.IsEmpty(0, 0).Should().BeTrue();
        }

        [Test]
        public void IsContainsBlock()
        {
            var field = new Field(5, Difficulty.Easy);
            field.PlaceBox();
            field.IsEmpty(0, 2).Should().BeTrue();
        }
        
        [Test]
        public void IsContainsTwoBlocks()
        {
            var field = new Field(5, Difficulty.Easy);
            field.PlaceBox();
            field.IsEmpty(2, 4).Should().BeFalse();
            field.IsEmpty(2, 3).Should().BeTrue();
            field.PlaceBox();
            field.IsEmpty(2, 4).Should().BeFalse();
            field.IsEmpty(2, 3).Should().BeFalse();
        }

        [Test]
        public void IsGameEnding()
        {
            var field = new Field(5, Difficulty.Easy);
            for (int i = 0; i < 5; i++)
            {
                field.PlaceBox();
            }
            Assert.IsTrue(field.IsGameEnded);
        }
        
        [Test]
        public void MoveHorizontalFourTimesGridFive()
        {
            var field = new Field(5, Difficulty.Easy);
            for (int i = 0; i < 4; i++)
            {
                field.MovePseudoBlockHorizontal();
            }

            Assert.AreEqual(2, field.PseudoX);
        }
        
        [Test]
        public void MoveHorizontalSixTimesGridFive()
        {
            var field = new Field(5, Difficulty.Easy);
            for (int i = 0; i < 6; i++)
            {
                field.MovePseudoBlockHorizontal();
            }

            Assert.AreEqual(0, field.PseudoX);
        }

        [Test]
        public void LevelChanged()
        {
            var field = new Field(5, Difficulty.Easy);
            field.PlaceBox();
            Assert.AreEqual(3, field.Level);
        }
        
        [Test]
        public void LevelChangedOnColumnOf4()
        {
            var field = new Field(5, Difficulty.Easy);
            field.PlaceBox();
            field.PlaceBox();
            field.PlaceBox();
            field.PlaceBox();
            Assert.AreEqual(0, field.Level);
        }
        
        [Test]
        public void IsGameEnded()
        {
            var field = new Field(5, Difficulty.Easy);
            for (int i = 0; i < 5; i++)
            {
                field.PlaceBox();
            }
            Assert.AreEqual(true, field.IsGameEnded);
        }
        

        [Test]
        public void IsGameNotStarted()
        {
            var game = new Game(Difficulty.Easy);
            Assert.AreEqual(Stages.NotStarted, game.Stage);
        }

        [Test]
        public void IsGameStarting()
        {
            var game = new Game(Difficulty.Easy);
            game.Start("PlayerA");
            Assert.AreEqual(Stages.Started, game.Stage);
            Assert.AreEqual("PlayerA", game.Player1.Name);
        }

        [Test]
        public void IsGameFinishing()
        {
            var game = new Game(Difficulty.Easy);
            game.Start("PlayerA");
            game.EndGame();
            Assert.AreEqual(Stages.Finished, game.Stage);
        }

        [Test]
        public void IsGameChangingStageToFinishedToFromNotStarted()
        {
            var game = new Game(Difficulty.Easy);
            Assert.AreEqual(Stages.NotStarted, game.Stage);
        }
    }
}