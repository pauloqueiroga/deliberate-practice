using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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

        public Board FetchTodaysBoard(string url = "https://www.setgame.com/set/puzzle")
        {
            var source = HttpGet(url).Result;
            var cardIds = ParseCards(source);
            var cards = cardIds.Select(CardById);
            return new Board(cards);
        }

        protected static IEnumerable<int> ParseCards(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var cards = doc.DocumentNode.Descendants("img")
                .Where(x => x.GetAttributeValue("name", string.Empty).StartsWith("card"));

            foreach (var card in cards)
            {
                var imagePath = card.GetAttributeValue("src", string.Empty);
                var file = Path.GetFileNameWithoutExtension(imagePath);
                yield return int.Parse(file);
            }
        }

        protected static async Task<string> HttpGet(string url)
        {
            var client = new HttpClient();
            var response = client.GetStringAsync(url);
            return await response;
        }
    }
}
