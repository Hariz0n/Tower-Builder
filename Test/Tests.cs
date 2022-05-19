using System;
using NUnit.Framework;
using TowerBuilder;
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
            var field = new Field(5);
            field.IsEmpty(0, 0).Should().BeTrue();
        }

        [Test]
        public void IsContainsBlock()
        {
            var field = new Field(5);
            field.PlaceBox(0, 0);
            field.IsEmpty(0, 4).Should().BeFalse();
        }
        
        [Test]
        public void IsContainsTwoBlocks()
        {
            var field = new Field(5);
            field.PlaceBox(0, 0);
            field.PlaceBox(0, 0);
            field.IsEmpty(0, 3).Should().BeFalse();
            field.IsEmpty(0, 4).Should().BeFalse();
        }
        
        [Test]
        public void MoveHorizontalFourTimesGridFive()
        {
            var field = new Field(5);
            for (int i = 0; i < 4; i++)
            {
                field.MovePseudoBlockHorizontal();
            }

            Assert.AreEqual(2, field.PseudoX);
        }
        
        [Test]
        public void MoveHorizontalSixTimesGridFive()
        {
            var field = new Field(5);
            for (int i = 0; i < 6; i++)
            {
                field.MovePseudoBlockHorizontal();
            }

            Assert.AreEqual(0, field.PseudoX);
        }

        [Test]
        public void LevelChanged()
        {
            var field = new Field(5);
            field.PlaceBox(field.PseudoX, field.Level);
            Assert.AreEqual(3, field.Level);
        }
        
        [Test]
        public void LevelChangedOn3InRowAndOneOnTop()
        {
            var field = new Field(5);
            field.PlaceBox(field.PseudoX-1, field.Level);
            field.PlaceBox(field.PseudoX, field.Level);
            field.PlaceBox(field.PseudoX+1, field.Level);
            field.PlaceBox(field.PseudoX+1, field.Level);
            Assert.AreEqual(2, field.Level);
        }
        
        [Test]
        public void IsGameEnded()
        {
            var field = new Field(5);
            for (int i = 0; i < 5; i++)
            {
                field.PlaceBox(field.PseudoX, field.Level);
            }
            Assert.AreEqual(true, field.IsGameEnded);
        }
    }
}