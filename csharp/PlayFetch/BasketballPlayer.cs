namespace pauloq.sports.playfetch
{
    internal record class BasketballPlayer : Player
    {
        public const string SportName = "basketball";

        public override string Sport => SportName;
    }
}