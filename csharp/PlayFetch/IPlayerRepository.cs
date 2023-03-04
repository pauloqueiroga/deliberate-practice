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
        /// Retrieves a player from the repository by ID.
        /// </summary>
        /// <param name="id">Unique ID of the player.</param>
        /// <returns>Player with given ID or NULL if not found.</param>
        Player? GetById(int id);

        /// <summary>
        /// Retrieves all players in the repository.
        /// </summary>
        IEnumerable<Player> GetAll();

        /// <summary>
        /// Inserts or updates repository with the given collection of players.
        /// </summary>
        /// <param name="players">Collection of players to be imported.</param>
        void InsertOrUpdate(IEnumerable<Player> players);
    }
}