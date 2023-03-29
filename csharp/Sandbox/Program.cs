/*
# Full term searching
index = SearchIndex.new
index.add(0, "some more examples")
index.search("exam")
  =>  returns nothing
index.search("examples")
  =>  returns Document 0
*/

var index = new SearchIndex();
index.add(0, "some more examples");

var result = index.search("exam");
PrintResult(result);

result = index.search("examples");
PrintResult(result);

/*
# Normalized terms
index = SearchIndex.new
index.add(0, "this is a capitalized EXAMPLE")
index.add(1, "here is a lower case example")
index.add(2, "and one More example")
index.search("example")
  =>  returns Document 0, 1 and 2

# Scoring of Documents for a Query
index = SearchIndex.new
index.add(0, "some more examples")
index.add(1, "Examples are great for examples of examples")
index.search("examples")
  =>  returns Document 1 with score 1.0, Document 0 with score 0.5
*/


void PrintResult(IEnumerable<Document> result)
{
    foreach (var item in result) 
    {
        Console.WriteLine(item.id);
        Console.WriteLine(item.contents);
    }

    Console.WriteLine("---");
}
