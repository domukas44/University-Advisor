using Newtonsoft.Json;
using System.IO;
using University_advisor.Entity;

namespace University_advisor.Controllers
{
    public static class Serializer
    {
        static JsonSerializer serializer = new JsonSerializer();
        public static void Serialize(Review review)
        {
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(@"..\..\Resources\Reviews.txt", true))       // true means append to file
            using (StreamWriter sw2 = new StreamWriter(@"..\..\Resources\LastReview.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            using (JsonWriter writer2 = new JsonTextWriter(sw2))
            {
                Action<JsonWriter, Review> ser = serializer.Serialize;      // delegate?
                ser(writer, review);
                sw.WriteLine();
                ser(writer2, review);
            }
        }

        public static void Serialize(User user)
        {
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(@"..\..\Resources\User.txt", true))       // true means append to file
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, user);
                sw.WriteLine();
            }
        }
    }
}
