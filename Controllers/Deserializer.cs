using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace University_advisor.Controllers
{
    public class Deserializer<T>
    {
        public static T DeserializeLine(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                return JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
            }
        }

        public static List<T> DeserializeFile(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                List <T> list = new List<T>();
                while (!sr.EndOfStream)
                {
                    list.Add(JsonConvert.DeserializeObject<T>(sr.ReadLine()));
                }
                return list;
            }
        }
    }
}
