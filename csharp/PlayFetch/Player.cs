namespace pauloq.sports.playfetch
{
    /// <summary>
    /// Represents the properties that are common to all types of players.
    /// </summary>
    internal abstract record class Player
    {
        /// <summary>
        /// Player unique ID in our system.
        /// </summary>
        public string? ID { get; init; }

        /// <summary>
        /// Player's sport.
        /// </summary>
        public abstract string Sport { get; }

        /// <summary>
        /// Player's first name.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Player's last name.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Player's position in the team.
        /// </summary>
        public string? Position { get; set; }

        /// <summary>
        /// Player's age.
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Unique ID in the source system, when the player was imported from an external system.
        /// </summary>
        public string? ImportID { get; set; }

        /// <summary>
        /// Unique ID of the import batch, when the player was imported from an external system.
        /// </summary>
        public string? ImportBatch { get; set; }

        /// <summary>
        /// URL for the external system used when importing the player, if player was imported.
        /// </summary>
        public string? ImportUrl { get; set; }
    }
}