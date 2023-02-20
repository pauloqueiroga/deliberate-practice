namespace pauloq.sports.playfetch
{
    internal abstract class Player
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public abstract string NameBrief { get; }
        public abstract string Sport { get; }
        public int AvgPositionAgeDiff { get; }
        public DateTime? ImportTime { get; set; }
        public string? FullSource { get; set; }
        public string? ImportUrl { get; set; }

        public Player(string id,
                      string firstName,
                      string lastName,
                      string position,
                      int age)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
        }
    }
}