using MongoDB.Bson.Serialization.Attributes;

namespace cat.itb.M6UF3EA1.Models
{
    [Serializable]
    public class Friend
    {
        [BsonElement("_id")]
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(id)}={id.ToString()}, {nameof(name)}={name}}}";
        }
    }
}
