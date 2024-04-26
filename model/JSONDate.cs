using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
namespace cat.itb.M6UF3EA1.Models;
public class JSONDate
    {
        [JsonProperty("$date")]
        public String date { get; set; }
    
        public override string ToString()
        {
            return 
                "PublishedDate{" + 
                "$date = '" + date + '\'' + 
                "}";
        }
    }
