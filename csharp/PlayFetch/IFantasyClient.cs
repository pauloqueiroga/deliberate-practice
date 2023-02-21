namespace pauloq.sports.playfetch
{
    /// <summary>
    /// Interface IFantasyClient represents a client for a fantasy sports service.
    /// </summary>
    internal interface IFantasyClient
    {
        /// <summary>
        /// Asynchronously retrieves players from the service and convert to our abstraction of players.
        /// </summary>
        /// <param name="sport">A string representing the sport (e.g. "baseball")</param>
        /// <returns>Set of Players retrieved from the service.</returns>
        Task<IEnumerable<Player>> GetPlayersAsync<T>(string sport) where T : Player;
    }
}