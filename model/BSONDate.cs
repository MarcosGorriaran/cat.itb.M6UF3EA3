using MongoDB.Bson.Serialization.Attributes;

namespace cat.itb.M6UF3EA3.model
{
    public class BSONDate
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime date {  get; set; }
    }
}
