using System.Collections.Generic;
using System.Linq;

namespace pauloq.SetsSolutionEngine
{
    public class Board
    {
        public const int CardCount = 12;
        private readonly HashSet<Card> cards;

        public IReadOnlyCollection<Card> Cards 
        { 
            get 
            { 
                return cards.ToList(); 
            } 
        }

        public Board() : this(RandomizeCards())
        {
        }

        public Board(IEnumerable<Card> cards)
        {
            this.cards = new HashSet<Card>(cards);
        }

        public static IEnumerable<Card> RandomizeCards()
        {
            var localHash = new HashSet<Card>();
            
            while(localHash.Count < CardCount)
            {
                localHash.Add(new Card());
            }

            return localHash;
        }
    }
}
