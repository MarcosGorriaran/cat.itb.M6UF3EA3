
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace cat.itb.M6UF3EA1.Models
{
    [Serializable]
    public class Restaurant : Model<Restaurant>
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("_id")]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public Address address { get; set; }
        public string borough {  get; set; }
        public string cuisine { get; set; }
        public RestGrade[] grades { get; set; }
        public string name { get; set; }
        public string restaurant_id { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id}, {nameof(address)}={address}, {nameof(borough)}={borough}, {nameof(cuisine)}={cuisine}, {nameof(grades)}={grades}, {nameof(name)}={name}, {nameof(restaurant_id)}={restaurant_id}}}";
        }
    }
}
