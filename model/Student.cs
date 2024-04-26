using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace cat.itb.M6UF3EA1.Models
{
    public class Student : Model<Student>
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public int _id {  get; set; }
        public string firstname { get; set; }
        public string lastname1 { get; set; }
        public string lastname2 { get; set;}
        public string dni { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string phone_aux { get; set; }
        public int birth_year { get; set; }
        
        public bool ShouldSerialize()
        {
            return true;
        }
    }
}
