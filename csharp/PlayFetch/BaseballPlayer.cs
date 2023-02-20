namespace pauloq.sports.playfetch
{
    internal class BaseballPlayer : Player
    {
        public const string SportName = "baseball";

        public BaseballPlayer(string id,
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