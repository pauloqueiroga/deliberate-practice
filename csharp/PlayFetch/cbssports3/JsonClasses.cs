// Classes generated based on the JSON structure returned by the service.
// Only the types and fields that matter to us are included here. 
// As implementation changes, if we need more fields that already exist in the current model, we can add them.

namespace pauloq.sports.playfetch.cbssports3 
{
    public record class Body
    {
        public List<Player>? players { get; init; }
    }

    public record class Player
    {
        public string? firstname { get; set; }
        public int? age { get; set; }
        public string? id { get; set; }
        public string? lastname { get; set; }
        public string? position { get; set; }
    }

    public record class Root
    {
        public Body? body { get; set; }
        public string? uriAlias { get; set; }
        public string? uri { get; set; }
        public int? statusCode { get; set; }
        public string? statusMessage { get; set; }
    }
}