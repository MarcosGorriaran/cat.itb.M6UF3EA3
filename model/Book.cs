using cat.itb.M6UF3EA3.model;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace cat.itb.M6UF3EA1.Models;
public class Book : Model<Book>
{
    public int _id { get; set; }
    public string title { get; set; }
    public string isbn { get; set; }
    public int pageCount { get; set; }
    public BSONDate publishedDate { get; set; }
    [BsonIgnoreIfNull]
    public string thumbnailUrl { get; set; }
    [BsonIgnoreIfNull]
    public string shortDescription { get; set; }
    [BsonIgnoreIfNull]
    public string longDescription { get; set; }
    public string status { get; set; }
    public List<string> authors { get; set; }
    public List<string> categories { get; set; }
    public override string ToString()
    {
        return 
            "Book{" + 
            "_id = '" + _id + '\'' +
            ",title = '" + title + '\'' + 
            ",isbn = '" + isbn + '\'' + 
            ",pageCount = '" + pageCount + '\'' + 
            ",publishedDate = '" + publishedDate + '\'' + 
            ",thumbnailUrl = '" + thumbnailUrl + '\'' + 
            ",shortDescription = '" + shortDescription + '\'' + 
            ",longDescription = '" + longDescription + '\'' + 
            ",status = '" + status + '\'' + 
            ",authors = '" + authors + '\'' + 
            ",categories = '" + categories + '\'' + 
            "}";
    }
}
    
