namespace pauloq.sports.playfetch
{
        /// <summary>
        /// Represents a Basketball Player.
        /// </summary>
    internal record class BasketballPlayer : Player
    {
        /// <summary>
        /// String key for basketball.
        /// </summary>
        public const string SportName = "basketball";

        /// <summary>
        /// This player plays basketball.
        /// </summary>
        public override string Sport => SportName;
    }
}