namespace pauloq.sports.playfetch
{
    internal abstract record class Player
    {
        public string? ID { get; init; }
        public abstract string Sport { get; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Position { get; set; }
        public int? Age { get; set; }
        public string? ImportID { get; set; }
        public string? ImportBatch { get; set; }
        public string? ImportUrl { get; set; }
    }
}