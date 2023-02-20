namespace pauloq.sports.playfetch
{
    internal class CBSSports3 : IFantasyClient
    {
        public const string SchemeName = "cbssports3.0";
        private string baseUrl;

        public CBSSports3(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        IEnumerable<Player> IFantasyClient.Get(string sport)
        {
            throw new NotImplementedException();
        }
    }
}

