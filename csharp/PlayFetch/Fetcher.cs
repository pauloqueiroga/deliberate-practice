namespace pauloq.sports.playfetch
{
    internal class Fetcher
    {
        private readonly IFantasyClient _fantasyClient;
        private readonly PlayerRepository _playerRepo = new PlayerRepository();

        public Fetcher(IFantasyClient client)
        {
            _fantasyClient = client;
        }

        public void Run(string sport)
        {
            if (string.IsNullOrWhiteSpace(sport))
            {
                throw new ArgumentException($"'{nameof(sport)}' cannot be null or whitespace.", nameof(sport));
            }

            var players = _fantasyClient.Get(sport);
            _playerRepo.Update(players);
        }
    }
}