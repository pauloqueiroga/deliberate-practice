using System.Text;
using System.Text.Json.Serialization;

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

        /// <summary>
        /// For baseball players it should just be the first initial and the last initial like “G. S.”
        /// </summary>
        [JsonPropertyName("name_brief")]
        public override string NameBrief {
            get 
            {
                var brief = string.Empty;

                if (!string.IsNullOrEmpty(FirstName))
                {
                    brief += $"{FirstName.Substring(0,1)}. ";
                }

                if (!string.IsNullOrEmpty(LastName))
                {
                    brief += $"{LastName.Substring(0,1)}.";
                }

                return brief;
            }
        }
    }
}