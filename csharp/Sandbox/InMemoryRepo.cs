internal class InMemoryRepo : IRepository
{
    private readonly Dictionary<int, Document> storage = new Dictionary<int, Document>();

    public void add(Document doc)
    {
        if (doc == null) 
        {
            throw new ArgumentNullException(nameof(doc), "Document should not be null");
        }
        
        storage[doc.id] = doc;
    }

    public Document GetById(int id)
    {
        if (!storage.ContainsKey(id))
        {
            throw new KeyNotFoundException($"No document with id {id}");
        }

        return storage[id];
    }
}