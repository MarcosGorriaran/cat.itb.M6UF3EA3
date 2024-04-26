using System.IO;
using Newtonsoft.Json;

namespace cat.itb.M6UF3EA1.Models
{
    public abstract class Model<T>
    {
        public static List<T> ReadJSONArray(IEnumerable<string> json)
        {
            List<T> result = new List<T>();
            foreach(string element in json) 
            {
                if(element != string.Empty)
                {
                    result.Add(JsonConvert.DeserializeObject<T>(element));
                }
                
            }
            return result;
        }
        public static T ReadJSON(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static List<T> ReadJSONArrayFile(string path)
        {
            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
        }
        public static T ReadJSONFile(string path)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }
    }
}
