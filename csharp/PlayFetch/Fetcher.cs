namespace pauloq.sports.playfetch
{
    /// <summary>
    /// Fetcher retrieves players' data from a service and saves in the underlying repository.
    /// </summary>
    internal class Fetcher
    {
        private readonly IFantasyClient _fantasyClient;
        private readonly PlayerRepository _playerRepo = new PlayerRepository();

        /// <summary>
        /// Creates an instance of Fetcher for the given client.
        /// </summary>
        /// <param name="client">Client for the fantasy service to be used.</param>
        public Fetcher(IFantasyClient client)
        {
            _fantasyClient = client;
        }

        /// <summary>
        /// Executes a full fetch for the given sport.
        /// </summary>
        /// <param name="playerType">Type of player to be fetched and converted (e.g.: FootballPlayer).</param>
        public async Task Run<T>(string sport) where T : Player
        {
            var players = _fantasyClient.GetPlayersAsync<T>(sport);
            _playerRepo.Update(await players);
        }
    }
}