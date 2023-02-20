namespace pauloq.sports.playfetch
{
    internal class FootballPlayer : Player
    {
        private const string SportName = "football";

        public FootballPlayer(string id,
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