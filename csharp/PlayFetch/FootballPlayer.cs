namespace pauloq.sports.playfetch
{
    internal record class FootballPlayer : Player
    {
        private const string SportName = "football";

        public override string Sport => SportName;
    }
}