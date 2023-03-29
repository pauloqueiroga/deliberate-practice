public interface IRepository
{
    void add(Document doc);
    Document GetById(int x);
}

public class Document
{
    public Document(int id, string contents)
    {
        this.id = id;
        this.contents = contents;
    }

    public int id { get; set; }
    public string? contents { get; set; }
}