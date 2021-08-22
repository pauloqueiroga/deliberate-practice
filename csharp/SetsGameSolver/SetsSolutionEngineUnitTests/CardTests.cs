using Microsoft.VisualStudio.TestTools.UnitTesting;
using pauloq.SetsSolutionEngine;
using System.Collections.Generic;
using System.Linq;

namespace pauloq.SetsSolutionEngine.UnitTests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CardsWithDifferentColorsCantBeEqual()
        {
            var target1 = new Card(Colors.Purple, Shapes.Diamond, Fills.Empty, Numbers.Double);
            var target2 = new Card(Colors.Green, Shapes.Diamond, Fills.Empty, Numbers.Double);
            Assert.AreNotEqual(target1, target2);
        }

        [TestMethod]
        public void CardsWithDifferentShapesCantBeEqual()
        {
            var target1 = new Card(Colors.Purple, Shapes.Diamond, Fills.Empty, Numbers.Double);
            var target2 = new Card(Colors.Purple, Shapes.Oval, Fills.Empty, Numbers.Double);
            Assert.IsFalse(target1.Equals(target2));
        }

        [TestMethod]
        public void CardsWithDifferentNumbersCantBeEqual()
        {
            var target1 = new Card(Colors.Purple, Shapes.Diamond, Fills.Empty, Numbers.Double);
            var target2 = new Card(Colors.Purple, Shapes.Diamond, Fills.Empty, Numbers.Single);
            Assert.IsFalse(target1.Equals(target2));
        }

        [TestMethod]
        public void CardsWithDifferentFillsCantBeEqual()
        {
            var target1 = new Card(Colors.Purple, Shapes.Oval, Fills.Lines, Numbers.Double);
            var target2 = new Card(Colors.Purple, Shapes.Oval, Fills.Empty, Numbers.Double);
            Assert.IsFalse(target1.Equals(target2));
        }

        [TestMethod]
        public void CardsWithSamePropertiesShouldBeEqual()
        {
            var target1 = new Card(Colors.Purple, Shapes.Diamond, Fills.Empty, Numbers.Double);
            var target2 = new Card(Colors.Purple, Shapes.Diamond, Fills.Empty, Numbers.Double);
            Assert.IsTrue(target1.Equals(target2));
        }

        [TestMethod]
        public void CardsWithDifferentColorsShouldHaveDifferentHashcodes()
        {
            var target1 = new Card(Colors.Red, Shapes.Diamond, Fills.Empty, Numbers.Double);
            var target2 = new Card(Colors.Purple, Shapes.Diamond, Fills.Empty, Numbers.Double);
            Assert.AreNotEqual(target1.GetHashCode(), target2.GetHashCode());
        }

        [TestMethod]
        public void CardsWithDifferentFillsShouldHaveDifferentHashcodes()
        {
            var target1 = new Card(Colors.Red, Shapes.Diamond, Fills.Empty, Numbers.Double);
            var target2 = new Card(Colors.Red, Shapes.Diamond, Fills.Solid, Numbers.Double);
            Assert.AreNotEqual(target1.GetHashCode(), target2.GetHashCode());
        }

        [TestMethod]
        public void CardsWithDifferentShapesShouldHaveDifferentHashcodes()
        {
            var target1 = new Card(Colors.Red, Shapes.Squiggle, Fills.Solid, Numbers.Double);
            var target2 = new Card(Colors.Red, Shapes.Diamond, Fills.Solid, Numbers.Double);
            Assert.AreNotEqual(target1.GetHashCode(), target2.GetHashCode());
        }

        [TestMethod]
        public void CardsWithDifferentNumbersShouldHaveDifferentHashcodes()
        {
            var target1 = new Card(Colors.Red, Shapes.Squiggle, Fills.Solid, Numbers.Double);
            var target2 = new Card(Colors.Red, Shapes.Squiggle, Fills.Solid, Numbers.Triple);
            Assert.AreNotEqual(target1.GetHashCode(), target2.GetHashCode());
        }

        [TestMethod]
        public void CardsWithSamePropertiesShouldHaveSameHashcode()
        {
            var target1 = new Card(Colors.Red, Shapes.Squiggle, Fills.Solid, Numbers.Triple);
            var target2 = new Card(Colors.Red, Shapes.Squiggle, Fills.Solid, Numbers.Triple);
            Assert.AreEqual(target1.GetHashCode(), target2.GetHashCode());
        }

        [TestMethod]
        public void HashSetsShouldNotTakeDuplicateCards()
        {
            var hash = new HashSet<Card>();
            var target1 = new Card(Colors.Green, Shapes.Squiggle, Fills.Solid, Numbers.Triple);
            var target2 = new Card(Colors.Green, Shapes.Squiggle, Fills.Solid, Numbers.Triple);
            Assert.IsTrue(hash.Add(target1));
            Assert.IsFalse(hash.Add(target2));
        }

        [TestMethod]
        public void CardDefaultConstructorShouldRandomizeProperties()
        {
            var targets = new[] {
                new Card(),
                new Card(),
                new Card(),
                new Card(),
                };
            Assert.IsTrue(targets.Distinct().Count() > 1);
        }
    }
}
