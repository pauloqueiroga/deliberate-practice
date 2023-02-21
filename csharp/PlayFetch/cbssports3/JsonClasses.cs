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