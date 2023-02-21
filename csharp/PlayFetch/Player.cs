using System.Text.Json.Serialization;

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
        [JsonPropertyName("id")]
        public int? ID { get; set; }

        /// <summary>
        /// Player's sport.
        /// </summary>
        [JsonIgnore()]
        public abstract string Sport { get; }

        /// <summary>
        /// Player's first name.
        /// </summary>
        [JsonPropertyName("first_name")]
        public required string FirstName { get; set; }

        /// <summary>
        /// Player's last name.
        /// </summary>
        [JsonPropertyName("last_name")]
        public required string LastName { get; set; }

        /// <summary>
        /// Player's position in the team.
        /// </summary>
        [JsonPropertyName("position")]
        public string? Position { get; set; }

        /// <summary>
        /// Player's age.
        /// </summary>
        [JsonPropertyName("age")]
        public int? Age { get; set; }

        /// <summary>
        /// The difference between the age of the player vs the average age for the player’s position.
        /// </summary>
        [JsonPropertyName("average_position_age_diff")]
        public int? AveragePositionAgeDifference { get; set; }

        /// <summary>
        /// Brief name according to the sport's expected way of summarizing names.
        /// </summary>
        [JsonPropertyName("name_brief")]
        public abstract string NameBrief { get; }

        /// <summary>
        /// Unique ID in the source system, when the player was imported from an external system.
        /// </summary>
        [JsonIgnore]
        public string? ImportID { get; set; }

        /// <summary>
        /// Unique ID of the import batch, when the player was imported from an external system.
        /// </summary>
        [JsonIgnore]
        public string? ImportBatch { get; set; }

        /// <summary>
        /// URL for the external system used when importing the player, if player was imported.
        /// </summary>
        [JsonIgnore]
        public string? ImportUrl { get; set; }
    }
}