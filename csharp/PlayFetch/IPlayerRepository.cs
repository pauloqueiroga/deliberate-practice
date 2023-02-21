namespace pauloq.sports.playfetch
{
    /// <summary> 
    /// Interface IPlayerRepository provides repository actions.
    /// </summary>
    internal interface IPlayerRepository
    {
        /// <summary> 
        /// Name of this repository. 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Inserts or updates repository with the given collection of players.
        /// </summary>
        /// <param name="players">Collection of players to be imported.</param>
        void InsertOrUpdate(IEnumerable<Player> players);
    }
}