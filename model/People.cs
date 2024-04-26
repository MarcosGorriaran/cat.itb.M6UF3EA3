
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using System.Text.Json.Serialization;
namespace cat.itb.M6UF3EA1.Models
{
    [Serializable]
    public class People : Model<People>
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public ObjectId Id { get; set; }
        public bool isActive { get; set; }
        public string balance { get; set; }
        public string picture { get; set; }
        public int age { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string about { get; set; }
        public string registered { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string email { get; set; }
        public string[] tags { get; set; }
        public List<Friend> friends { get; set; }
        public string gender { get; set; }
        public string randomArrayItem { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id}, {nameof(isActive)}={isActive.ToString()}, {nameof(balance)}={balance}, {nameof(picture)}={picture}, {nameof(age)}={age.ToString()}, {nameof(name)}={name}, {nameof(company)}={company}, {nameof(phone)}={phone}, {nameof(address)}={address}, {nameof(about)}={about}, {nameof(registered)}={registered}, {nameof(latitude)}={latitude.ToString()}, {nameof(longitude)}={longitude.ToString()}, {nameof(email)}={email}, {nameof(tags)}={tags}, {nameof(friends)}={friends}, {nameof(gender)}={gender}, {nameof(randomArrayItem)}={randomArrayItem}}}";
        }
    }
}
