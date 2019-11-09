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
            using (StreamWriter sw = new StreamWriter(@"C:\Resources\Reviews.txt", true))       // true means append to file
            using (StreamWriter sw2 = new StreamWriter(@"C:\Resources\LastReview.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            using (JsonWriter writer2 = new JsonTextWriter(sw2))
            {
                serializer.Serialize(writer, review);
                sw.WriteLine();
                serializer.Serialize(writer2, review);
            }
        }

        public static void Serialize(User user)
        {
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(@"C:\Resources\User.txt", true))       // true means append to file
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, user);
                sw.WriteLine();
            }
        }
    }
}
