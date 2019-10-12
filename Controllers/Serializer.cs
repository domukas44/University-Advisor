using Newtonsoft.Json;
using System.IO;

namespace University_advisor.Controllers
{
    public static class Serializer
    {
        static JsonSerializer serializer = new JsonSerializer();
        public static void serialize(Review review)
        {
            
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(@"..\..\Resources\Reviews.txt", true))       // true means append to file
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, review);
            }
        }

        public static Review deserialize()       // kol kas neveikia
        {
            using (StreamReader sr = new StreamReader(@"..\..\Resources\Reviews.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return JsonConvert.DeserializeObject<Review>(reader.ReadAsString());
            }
        }
    }
}
