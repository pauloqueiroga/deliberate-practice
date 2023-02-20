namespace pauloq.sports.playfetch
{
    internal class PlayerRepository
    {
        public PlayerRepository()
        {
        }

        internal void Update(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Sport}: {player.FirstName} {player.LastName}");
            }
        }
    }
}