namespace pauloq.sports.playfetch
{
    /// <summary>
    /// Interface IFetcher exposes properties and actions for fetching players from another service into ours.
    /// </summary>
    internal interface IFetcher
    {
        /// <summary>
        /// Client to be used to retrieve players data.
        /// </summary>
        public IFantasyClient Client { get; }

        /// <summary>
        /// Repository where player information is to be stored.
        /// </summary>
        public IPlayerRepository Repository { get; }

        /// <summary>
        /// Sport handled by this instance of the fetcher.
        /// </summary>
        public string Sport { get; }
    
        /// <summary>
        /// Executes a full fetch from the service and saves to the repository.
        /// </summary>
        public Task Run();
    }
}