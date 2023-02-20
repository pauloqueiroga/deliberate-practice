namespace pauloq.sports.playfetch
{
    internal record class FootballPlayer : Player
    {
        public const string SportName = "football";

        public override string Sport => SportName;
    }
}