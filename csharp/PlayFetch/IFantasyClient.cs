namespace pauloq.sports.playfetch
{
    /// <summary>
    /// Interface IFantasyClient represents a client for a fantasy sports service.
    /// </summary>
    internal interface IFantasyClient
    {
        /// <summary>
        /// Gets data from the service and translates them to Players.
        /// </summary>
        /// <param name="sport">A string representing the sport (e.g. "baseball")</param>
        /// <returns>Set of Players retrieved from the service.</returns>
        Task<IEnumerable<Player>> GetPlayersAsync<T>(string sport) where T : Player;
    }
}