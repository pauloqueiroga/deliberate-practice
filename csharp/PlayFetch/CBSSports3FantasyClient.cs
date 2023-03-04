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
        /// Get players from CBS Sports Fantasy service.
        /// </summary>
        /// <returns>Collection of Players</returns>
        async Task<IEnumerable<Player>> IFantasyClient.GetPlayersAsync<T>(string sport)
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
            return ConvertPlayers<T>(response.body.players, importBatch, importUrl);
        }

        private IEnumerable<Player> ConvertPlayers<T>(IEnumerable<cbssports3.Player> source,
                                                      string batchId,
                                                      string url) where T : Player
        {
            foreach (var sourcePlayer in source)
            {
                var player = Activator.CreateInstance<T>();
                player.ImportID = sourcePlayer.id;
                player.FirstName = sourcePlayer.firstname ?? string.Empty;
                player.LastName = sourcePlayer.lastname ?? string.Empty;
                player.Age = sourcePlayer.age ?? 0;
                player.Position = sourcePlayer.position ?? string.Empty;
                player.ImportBatch = batchId;
                player.ImportUrl = url;
                yield return player;
            }
        }
    }
}
