namespace pauloq.sports.playfetch
{
    internal record class BaseballPlayer : Player
    {
        public const string SportName = "baseball";

        public override string Sport => SportName;
    }
}