using System.Collections.Generic;
using System.Linq;

namespace pauloq.SetsSolutionEngine
{
    public class Solver
    {
        public Board MyBoard { get; }

        public Solver() : this(new Board())
        {
        }

        public Solver(Board board)
        {
            MyBoard = board;
        }

        public static bool IsSet(IEnumerable<Card> cards)
        {
            var cardCount = cards.Count();
            var colorCount = cards.Select(x => x.Color).Distinct().Count();
            var shapeCount = cards.Select(x => x.Shape).Distinct().Count();
            var fillCount = cards.Select(x => x.Fill).Distinct().Count();
            var numberCount = cards.Select(x => x.Number).Distinct().Count();

            return ((colorCount == cardCount || colorCount == 1)
                && (shapeCount == cardCount || shapeCount == 1)
                && (fillCount == cardCount || fillCount == 1)
                && (numberCount == cardCount || numberCount == 1));
        }

        public IEnumerable<IEnumerable<Card>> BruteForceSolve()
        {
            var cards = MyBoard.Cards;
            int i = 0;

            foreach (var card1 in cards)
            {
                i++;
                var j = 0;

                foreach (var card2 in cards.Skip(i))
                {
                    j++;

                    if (card1.Equals(card2)) continue;

                    foreach (var card3 in cards.Skip(j))
                    {
                        if (card1.Equals(card3) || card2.Equals(card3)) continue;
                        var set = new[] { card1, card2, card3 };

                        if (IsSet(set))
                        {
                            yield return set;
                        }
                    }

                }
    
            }
        }
    }
}
