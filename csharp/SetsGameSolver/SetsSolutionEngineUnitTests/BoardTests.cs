using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace pauloq.SetsSolutionEngine.UnitTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void BoardDefaultConstructorShouldGetRandomCards()
        {
            var target = new Board();
            Assert.AreEqual(Board.CardCount, target.Cards.Count);
            Assert.AreEqual(Board.CardCount, target.Cards.Distinct().Count());
        }

        [TestMethod]
        public void BoardCardSetShouldBeReadOnly()
        {
            var target = new Board();
            var list = (List<Card>)target.Cards;
            Assert.AreEqual(Board.CardCount, list.Count);
            list.Add(new Card());
            var secondList = (List<Card>)target.Cards;
            Assert.AreEqual(Board.CardCount, secondList.Count);
        }
    }
}
