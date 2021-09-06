using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        [TestMethod]
        public void ParseCardsShouldReturnCorrect12Cards()
        {
            var sample = File.ReadAllText("SampleHTMLPuzzlePage1.html");
            var target = new WebSiteTranslatorTester();
            var cardIds = target.ParseCardsAccessor(sample).ToArray();
            CollectionAssert.Contains(cardIds, 76);
            CollectionAssert.Contains(cardIds, 44);
            CollectionAssert.Contains(cardIds, 3);
            CollectionAssert.Contains(cardIds, 62);
            CollectionAssert.Contains(cardIds, 35);
            CollectionAssert.Contains(cardIds, 45);
            CollectionAssert.Contains(cardIds, 31);
            CollectionAssert.Contains(cardIds, 12);
            CollectionAssert.Contains(cardIds, 67);
            CollectionAssert.Contains(cardIds, 13);
            CollectionAssert.Contains(cardIds, 54);
            CollectionAssert.Contains(cardIds, 17);
        }
    }

    internal class WebSiteTranslatorTester : WebSiteTranslator
    {
        public IEnumerable<int> ParseCardsAccessor(string html)
        {
            return ParseCards(html);
        }
    }
}
