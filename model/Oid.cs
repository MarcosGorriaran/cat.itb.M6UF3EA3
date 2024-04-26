using Newtonsoft.Json;

namespace cat.itb.M6UF3EA1.Models
{
    public class Oid
    {
        [JsonProperty("$oid")]
        public string Id { get; set; }
    }
}
