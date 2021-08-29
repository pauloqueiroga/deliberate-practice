using System;
using System.Collections.Generic;

namespace pauloq.SetsSolutionEngine
{
    public class WebSiteTranslator
    {
        private readonly IDictionary<int, Card> CardMap = new Dictionary<int, Card>();

        public WebSiteTranslator()
        {
            var id = 1;

            foreach (Fills fill in Enum.GetValues(typeof(Fills)))
            {
                foreach (Shapes shape in Enum.GetValues(typeof(Shapes)))
                {
                    foreach (Colors color in Enum.GetValues(typeof(Colors)))
                    {
                        foreach (Numbers number in Enum.GetValues(typeof(Numbers)))
                        {
                            CardMap[id++] = new Card(color, shape, fill, number);
                        }
                    }
                }
            }
        }

        public Card CardById(int id)
        {
            return CardMap[id];
        }
    }
}
