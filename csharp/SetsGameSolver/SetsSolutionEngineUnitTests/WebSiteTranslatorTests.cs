using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace pauloq.SetsSolutionEngine.UnitTests
{
    [TestClass]
    public class WebSiteTranslatorTests
    {
        private readonly WebSiteTranslator translator = new WebSiteTranslator();
        [TestMethod]
        public void CardById7ReturnsGreenSquigglySolidSingle()
        {
            var target = translator.CardById(7);
            Assert.AreEqual(Colors.Green, target.Color);
            Assert.AreEqual(Shapes.Squiggle, target.Shape);
            Assert.AreEqual(Fills.Solid, target.Fill);
            Assert.AreEqual(Numbers.Single, target.Number);
        }

        [TestMethod]
        public void CardById6ReturnsPurpleSquigglySolidTriple()
        {
            var target = translator.CardById(6);
            Assert.AreEqual(Colors.Purple, target.Color);
            Assert.AreEqual(Shapes.Squiggle, target.Shape);
            Assert.AreEqual(Fills.Solid, target.Fill);
            Assert.AreEqual(Numbers.Triple, target.Number);
        }

        [TestMethod]
        public void CardById54ReturnsGreenOvalLinesTriple()
        {
            var target = translator.CardById(54);
            Assert.AreEqual(Colors.Green, target.Color);
            Assert.AreEqual(Shapes.Oval, target.Shape);
            Assert.AreEqual(Fills.Lines, target.Fill);
            Assert.AreEqual(Numbers.Triple, target.Number);
        }

        [TestMethod]
        public void CardById77ReturnsPurpleOvalEmptyDouble()
        {
            var target = translator.CardById(77);
            Assert.AreEqual(Colors.Purple, target.Color);
            Assert.AreEqual(Shapes.Oval, target.Shape);
            Assert.AreEqual(Fills.Empty, target.Fill);
            Assert.AreEqual(Numbers.Double, target.Number);
        }

        [TestMethod]
        public void CardById64ReturnsRedDiamondEmptySingle()
        {
            var target = translator.CardById(64);
            Assert.AreEqual(Colors.Red, target.Color);
            Assert.AreEqual(Shapes.Diamond, target.Shape);
            Assert.AreEqual(Fills.Empty, target.Fill);
            Assert.AreEqual(Numbers.Single, target.Number);
        }

        [TestMethod]
        public void CardById30ReturnsRedSquiggleLinesTriple()
        {
            var target = translator.CardById(30);
            Assert.AreEqual(Colors.Red, target.Color);
            Assert.AreEqual(Shapes.Squiggle, target.Shape);
            Assert.AreEqual(Fills.Lines, target.Fill);
            Assert.AreEqual(Numbers.Triple, target.Number);
        }

        [TestMethod]
        public void CardById49ReturnsPurpleOvalLinesSingle()
        {
            var target = translator.CardById(49);
            Assert.AreEqual(Colors.Purple, target.Color);
            Assert.AreEqual(Shapes.Oval, target.Shape);
            Assert.AreEqual(Fills.Lines, target.Fill);
            Assert.AreEqual(Numbers.Single, target.Number);
        }
    }
}
