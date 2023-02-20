namespace pauloq.sports.playfetch
{
    internal interface IFantasyClient
    {
        IEnumerable<Player> Get(string sport);
    }
}