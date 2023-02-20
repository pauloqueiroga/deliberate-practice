namespace pauloq.sports.playfetch
{
    internal abstract record class Player
    {
        public required string ID { get; init; }
        public abstract string Sport { get; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Position { get; init; }
        public required int Age { get; init; }
        public DateTime? ImportTime { get; set; }
        public string? FullSource { get; set; }
        public string? ImportUrl { get; set; }
    }
}