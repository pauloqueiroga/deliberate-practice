public class SearchIndex
{
    private readonly Dictionary<string, HashSet<int>> idsByTerm = new Dictionary<string, HashSet<int>>();
    private readonly IRepository documents;

    public SearchIndex() : this (new InMemoryRepo()) 
    {

    }

    public SearchIndex(IRepository documentRepo) {
        this.documents = documentRepo;
    }

    public void add(int id, string contents)
    {
        documents.add(new Document(id, contents));

        var terms = contents.Split(" ");

        foreach (var term in terms) 
        {
            if (!idsByTerm.ContainsKey(term))
            {
                idsByTerm[term] = new HashSet<int>();
            }

            idsByTerm[term].Add(id);
        }
    }

    public IEnumerable<Document> search(string term)
    {
        if (idsByTerm.ContainsKey(term))
        {
            return idsByTerm[term].Select(x => documents.GetById(x));
        }
        
        return Enumerable.Empty<Document>();
    }
}