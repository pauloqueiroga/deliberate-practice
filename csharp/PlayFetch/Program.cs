namespace pauloq.sports.playfetch
{
    internal class Program
    {
        private static readonly Dictionary<string, IPlayerRepository> repos = new Dictionary<string, IPlayerRepository>();

        private static void Main(string[] args)
        {
            // default values for optional command-line arguments
            var baseUrl = CBSSports3FantasyClient.DefaultUrl;
            var scheme = CBSSports3FantasyClient.SchemeName;

            // base URL
            if (args.Length >= 1)
            {
                baseUrl = args[0];
            }

            // scheme name
            if (args.Length >= 2)
            {
                scheme = args[1];
            }

            try
            {
                IFantasyClient client;

                // "Factory" code to build the right client for service we'll be connecting to 
                switch (scheme)
                {
                    case CBSSports3FantasyClient.SchemeName:
                        client = new CBSSports3FantasyClient(baseUrl);
                        break;
                    default:
                        throw new ArgumentException($"Scheme unknown: {scheme}");
                }

                // Using In-Memory implementation for now, can easily be replaced by anything else
                repos[BaseballPlayer.SportName] = new InMemoryRepository(BaseballPlayer.SportName);
                repos[FootballPlayer.SportName] = new InMemoryRepository(FootballPlayer.SportName);
                repos[BasketballPlayer.SportName] = new InMemoryRepository(BasketballPlayer.SportName);

                IFetcher baseballFetcher = new Fetcher<BaseballPlayer>(client, repos[BaseballPlayer.SportName], BaseballPlayer.SportName);
                baseballFetcher.Run().Wait();
                IFetcher footballFetcher = new Fetcher<FootballPlayer>(client, repos[FootballPlayer.SportName], FootballPlayer.SportName);
                footballFetcher.Run().Wait();
                IFetcher basketballFetcher = new Fetcher<BasketballPlayer>(client, repos[BasketballPlayer.SportName], BasketballPlayer.SportName);
                basketballFetcher.Run().Wait();

                var builder = WebApplication.CreateBuilder();
                var server = builder.Build();

                server.MapGet("/players/{sport}/{id}", (string sport, int id) =>
                {
                    var player = repos[sport].GetById(id);

                    if (player is null)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(player);
                });

                server.MapGet("/search-players", SearchPlayers);
                server.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            IEnumerable<Player> SearchPlayers(string sport = "all",
                                              string lastInitial = "",
                                              int age = 0,
                                              int minAge = 0,
                                              int maxAge = 999,
                                              string position = "any")
            {
                var results = new List<Player>();

                if (sport == BaseballPlayer.SportName || sport == "all")
                {
                    results.AddRange(repos[BaseballPlayer.SportName].GetAll());
                }

                if (sport == BasketballPlayer.SportName || sport == "all")
                {
                    results.AddRange(repos[BasketballPlayer.SportName].GetAll());
                }

                if (sport == FootballPlayer.SportName || sport == "all")
                {
                    results.AddRange(repos[FootballPlayer.SportName].GetAll());
                }

                if (lastInitial != string.Empty)
                {
                    results = results.Where(x => x.LastName.StartsWith(lastInitial)).ToList();
                }

                if (age != 0)
                {
                    results = results.Where(x => x.Age == age).ToList();
                }

                if (minAge != 0)
                {
                    results = results.Where(x => x.Age >= minAge).ToList();
                }

                if (maxAge != 999)
                {
                    results = results.Where(x => x.Age <= maxAge).ToList();
                }

                if (position != "any")
                {
                    results = results.Where(x => x.Position == position).ToList();
                }

                return results;
            }
        }
    }
}