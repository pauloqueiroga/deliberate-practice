using System.Text.Json.Serialization;

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

        /// <summary>
        /// For basketball players it should be first name plus last initial like "Kobe B."
        /// </summary>
        [JsonPropertyName("name_brief")]
        public override string NameBrief => $"{FirstName} {LastName.Substring(0,1)}.";
    }
}