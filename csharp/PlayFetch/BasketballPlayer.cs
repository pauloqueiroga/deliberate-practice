namespace pauloq.sports.playfetch
{
    internal class BasketballPlayer : Player
    {
        public const string SportName = "basketball";

        public BasketballPlayer(string id,
                                string firstName,
                                string lastName,
                                string position,
                                int age) : base(id,
                                                firstName,
                                                lastName,
                                                position,
                                                age)
        {
        }

        public override string NameBrief => throw new NotImplementedException();

        public override string Sport => SportName;
    }
}