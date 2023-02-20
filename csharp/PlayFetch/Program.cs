using pauloq.sports.playfetch;

// default values for optional command-line arguments
var sport = BaseballPlayer.SportName;
var baseUrl = "http://api.cbssports.com/fantasy/players/list?version=3.0&response_format=JSON&SPORT=";
var scheme = CBSSports3.SchemeName;

// first argument after executable name should be the sport
if (args.Length >= 2)
{
    sport = args[1];
}

// second argument after executable name should be the base URL
if (args.Length >= 3)
{
    baseUrl = args[2];
}

// third argument after executable name should be the scheme name
if (args.Length >= 4)
{
    scheme = args[3];
}

try
{
    IFantasyClient importer;

    switch (scheme) 
    {
        case CBSSports3.SchemeName:
            importer = new CBSSports3(baseUrl);
            break;
        default:
            throw new ArgumentException($"Scheme unknown: {scheme}");
    }

    var fetcher = new Fetcher(importer);
    fetcher.Run(sport);
}
catch (System.Exception e)
{
    Console.WriteLine(e.Message);
}
