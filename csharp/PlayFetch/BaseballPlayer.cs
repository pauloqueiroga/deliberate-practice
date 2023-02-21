namespace pauloq.sports.playfetch
{
    /// <summary>
    /// Represents one baseball player.
    /// </summary>
    internal record class BaseballPlayer : Player
    {
        /// <summary>
        /// String key to be used for Baseball.
        /// </summary>
        public const string SportName = "baseball";

        /// <summary>
        /// This is a Baseball player.
        /// </summary>
        public override string Sport => SportName;
    }
}