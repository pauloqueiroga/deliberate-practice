namespace pauloq.sports.playfetch
{
    /// <summary>
    /// Represents a Football Player.
    /// </summary>
    internal record class FootballPlayer : Player
    {
        /// <summary>
        /// String key representing this player's sport.
        /// </summary>
        public const string SportName = "football";

        /// <summary>
        /// This player plays football.
        /// </summary>
        public override string Sport => SportName;
    }
}