using Newtonsoft.Json;
using System.IO;

namespace University_advisor.Controllers
{
    public static class Serializer
    {
        static JsonSerializer serializer = new JsonSerializer();
        public static void serializeReview(Review review)
        {
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(@"..\..\Resources\Reviews.txt", true))       // true means append to file
            using (StreamWriter sw2 = new StreamWriter(@"..\..\Resources\LastReview.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            using (JsonWriter writer2 = new JsonTextWriter(sw2))
            {
                serializer.Serialize(writer, review);
                sw.WriteLine();
                serializer.Serialize(writer2, review);
            }
        }
    }
}