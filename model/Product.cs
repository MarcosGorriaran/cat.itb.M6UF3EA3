

using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cat.itb.M6UF3EA1.Models
{
    public class Product : Model<Product>
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("_id")]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public string picture { get; set; }
        public float discount { get; set; }
        public List<string> categories { get; set; }
    }
}
