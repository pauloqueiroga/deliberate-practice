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

        async Task<IEnumerable<Player>> IFantasyClient.GetPlayersAsync(string sport)
        {
            var uri = new Uri(baseUrl + sport);
            using HttpClient client = new();

            var json = await client.GetStringAsync(uri);
            Console.WriteLine(json);
            return Enumerable.Empty<Player>();
        }
    }
}

