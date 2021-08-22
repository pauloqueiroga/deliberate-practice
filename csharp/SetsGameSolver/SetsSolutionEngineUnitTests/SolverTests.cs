using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace pauloq.SetsSolutionEngine.UnitTests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void IsSetShouldReturTrueForCardsThatAreAllDifferent()
        {
            var target = new[]
            {
                new Card(Colors.Purple, Shapes.Oval, Fills.Solid, Numbers.Single),
                new Card(Colors.Green, Shapes.Squiggle, Fills.Empty, Numbers.Double),
                new Card(Colors.Red, Shapes.Diamond, Fills.Lines, Numbers.Triple),
            };

            Assert.IsTrue(Solver.IsSet(target));
        }

        [TestMethod]
        public void IsSetShouldReturTrueForCardsThatAreAllEqual()
        {
            var target = new[]
            {
                new Card(Colors.Purple, Shapes.Oval, Fills.Solid, Numbers.Single),
                new Card(Colors.Purple, Shapes.Oval, Fills.Solid, Numbers.Single),
                new Card(Colors.Purple, Shapes.Oval, Fills.Solid, Numbers.Single),
            };

            Assert.IsTrue(Solver.IsSet(target));
        }

        [TestMethod]
        public void IsSetShouldReturTrueForCardsThatAreDifferentOnlyInColors()
        {
            var target = new[]
            {
                new Card(Colors.Purple, Shapes.Oval, Fills.Solid, Numbers.Single),
                new Card(Colors.Green, Shapes.Oval, Fills.Solid, Numbers.Single),
                new Card(Colors.Red, Shapes.Oval, Fills.Solid, Numbers.Single),
            };

            Assert.IsTrue(Solver.IsSet(target));
        }

        [TestMethod]
        public void IsSetShouldReturFalseForCardsThatAreTwoDifferentColors()
        {
            var target = new[]
            {
                new Card(Colors.Purple, Shapes.Oval, Fills.Solid, Numbers.Single),
                new Card(Colors.Green, Shapes.Oval, Fills.Solid, Numbers.Double),
                new Card(Colors.Green, Shapes.Oval, Fills.Solid, Numbers.Triple),
            };

            Assert.IsFalse(Solver.IsSet(target));
        }
    }
}
