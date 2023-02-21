using pauloq.sports.playfetch;

// default values for optional command-line arguments
var sport = BaseballPlayer.SportName;
var baseUrl = CBSSports3FantasyClient.DefaultUrl;
var scheme = CBSSports3FantasyClient.SchemeName;

// first argument after executable name should be the sport
if (args.Length >= 1)
{
    sport = args[0];
}

// second argument after executable name should be the base URL
if (args.Length >= 2)
{
    baseUrl = args[1];
}

// third argument after executable name should be the scheme name
if (args.Length >= 3)
{
    scheme = args[2];
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
    IPlayerRepository repo = new InMemoryRepository(sport);

    // We'd create one fetcher for each combination of client, repository and sport
    IFetcher fetcher;

    switch (sport)
    {
        case BaseballPlayer.SportName:
            fetcher = new Fetcher<BaseballPlayer>(client, repo, sport);
            break;
        case BasketballPlayer.SportName:
            fetcher = new Fetcher<BasketballPlayer>(client, repo, sport);
            break;
        case FootballPlayer.SportName:
            fetcher = new Fetcher<FootballPlayer>(client, repo, sport);
            break;
        default:
            throw new ArgumentException($"Sport unknown: {sport}");
    }

    // Finally runs the fetch and conversion
    var fetching = fetcher.Run();

    var builder = WebApplication.CreateBuilder();
    var server = builder.Build();
    
    server.MapGet("/players/{id}", (int id) => 
    {
        var player = repo.GetById(id);
        
        if (player is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(player);
    });

    server.Run();

    // If we want to wait for the fetching to be done
    fetching.Wait();
}
catch (System.Exception e)
{
    Console.WriteLine(e.Message);
}
