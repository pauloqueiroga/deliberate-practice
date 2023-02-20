using System.Text.Json;

namespace pauloq.sports.playfetch
{
    /// <summary>
    /// Client for CBS Sports Fantasy service version 3.0.
    /// </summary>
    internal class CBSSports3FantasyClient : IFantasyClient
    {
        /// <summary>
        /// String key used to identify and select this client among other implementations of the same interface.
        /// <summary>
        public const string SchemeName = "cbssports3.0";
        
        /// <summary>
        /// Default URL for this service.
        public const string DefaultUrl = "http://api.cbssports.com/fantasy/players/list?version=3.0&response_format=JSON&SPORT=";

        private string baseUrl;

        /// <summary>
        /// Constructor for the CBS Sports Fantasy service v 3.0 client.
        /// </summary>
        /// <param name="baseUrl">Base URL to the service.</param>
        public CBSSports3FantasyClient(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        /// <summary>
        /// Asynchronously converts players retrieved from the service to our abstraction of players.
        /// </summary>
        /// <param name="sport">String representing the sport to retrieve (e.g. "basketball").</param>
        /// <returns>Collection of Players</returns>
        async Task<IEnumerable<Player>> IFantasyClient.GetPlayersAsync(string sport)
        {
            var importUrl = baseUrl + sport;
            var uri = new Uri(importUrl);

            using HttpClient client = new();
            using Stream jsonStream = await client.GetStreamAsync(uri);
            
            var response = await JsonSerializer.DeserializeAsync<cbssports3.Root>(jsonStream);
            
            if (response == null || response.body == null || response.body.players == null) 
            {
                return Enumerable.Empty<Player>();
            }

            var importBatch = Guid.NewGuid().ToString("N");

            switch (sport)
            {
                case BaseballPlayer.SportName:
                    return ConvertBaseball(response.body.players, importBatch, importUrl);
                case BasketballPlayer.SportName:
                    return ConvertBasketball(response.body.players, importBatch, importUrl);
                case FootballPlayer.SportName:
                    return ConvertFootball(response.body.players, importBatch, importUrl);
                default:
                    return Enumerable.Empty<Player>();
            }
        }

        private IEnumerable<Player> ConvertBaseball(IEnumerable<cbssports3.Player> source, string? batchId, string? url) 
        {
            foreach (var player in source)
            {
                yield return new BaseballPlayer
                {
                    ID = player.id,
                    FirstName = player.firstname,
                    LastName = player.lastname,
                    Age = player.age,
                    Position = player.position,
                    ImportBatch = batchId,
                    ImportUrl = url,
                };
            }
        }

        private IEnumerable<Player> ConvertBasketball(IEnumerable<cbssports3.Player> source, string? batchId, string? url) 
        {
            foreach (var player in source)
            {
                yield return new BasketballPlayer
                {
                    ID = player.id,
                    FirstName = player.firstname,
                    LastName = player.lastname,
                    Age = player.age,
                    Position = player.position,
                    ImportBatch = batchId,
                    ImportUrl = url,
                };
            }
        }

        private IEnumerable<Player> ConvertFootball(IEnumerable<cbssports3.Player> source, string? batchId, string? url) 
        {
            foreach (var player in source)
            {
                yield return new FootballPlayer
                {
                    ID = player.id,
                    FirstName = player.firstname,
                    LastName = player.lastname,
                    Age = player.age,
                    Position = player.position,
                    ImportBatch = batchId,
                    ImportUrl = url,
                };
            }
        }    }
}

