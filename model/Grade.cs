using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using MongoDB.Bson.Serialization.Attributes;

namespace cat.itb.M6UF3EA1.Models
{
    public class Grade : Model<Grade>
    {
        [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("_id")]
        [BsonElement("_id")]
        public string Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int class_id { get; set; }
        public string group {  get; set; }
        public List<Score> scores { get; set; }
        public int student_id { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> interests { get; set; }
    }
}
