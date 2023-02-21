using System.Text.Json.Serialization;

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

        /// <summary>
        /// For football players it should be the first initial and their last name like “P. Manning”.
        /// </summary>
        [JsonPropertyName("name_brief")]
        public override string NameBrief => $"{FirstName.Substring(0, 1)}. {LastName}";
    }
}