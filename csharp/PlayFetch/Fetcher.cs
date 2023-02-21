namespace pauloq.sports.playfetch
{
    internal interface IFetcher
    {
        public IFantasyClient Client { get; }
        public IPlayerRepository Repository { get; }
        public string Sport { get; }
    
        /// <summary>
        /// Executes a full fetch from the service and saves to the repository.
        /// </summary>
        public Task Run();
    }

    /// <summary>
    /// Fetcher retrieves players' data from a service and saves in the underlying repository.
    /// </summary>
    internal class Fetcher<T> : IFetcher where T : Player
    {
        public IFantasyClient Client { get; }
        public IPlayerRepository Repository { get; }
        public string Sport { get; }

        /// <summary>
        /// Creates an instance of Fetcher for the given client.
        /// </summary>
        /// <param name="client">Client for the fantasy service to be used by this fetcher.</param>
        /// <param name="repo">Repository to be used to store players.</param>
        /// <param name="sport">Name of the sport handled by this fetcher (e.g. "baseball")</param>
        public Fetcher(IFantasyClient client, IPlayerRepository repo, string sport)
        {
            Client = client;
            Repository = repo;
            Sport = sport;
        }

        /// <summary>
        /// Executes a full fetch for the given sport.
        /// </summary>
        async Task IFetcher.Run()
        {
            var players = Client.GetPlayersAsync<T>(Sport);
            Repository.Update(await players);
        }
    }
}