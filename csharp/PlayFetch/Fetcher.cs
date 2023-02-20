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
        /// <param name="sport">String representing the sport, e.g. "football".</param>
        public async Task Run(string sport)
        {
            if (string.IsNullOrWhiteSpace(sport))
            {
                throw new ArgumentException($"'{nameof(sport)}' cannot be null or whitespace.", nameof(sport));
            }

            var players = _fantasyClient.GetPlayersAsync(sport);
            _playerRepo.Update(await players);
        }
    }
}