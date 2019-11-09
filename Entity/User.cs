using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace University_advisor.Entity
{
    public class User
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public User(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;

            if (!CheckIfExists())
                SaveAccountToFile();
            else
                throw new Exception();
        }

        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
            if (CheckIfExists())
            {
                if (MatchEmailAndPassword())
                {
                }
                else throw new Exception();
            }
            else
            {
                throw new Exception();
            }
        }

        public User()
        {

        }

        public bool CheckIfExists()
        {
            List<User> users = GetUserList();
            return (users.Find(x => x.email == this.email)) != null;
        }

        public bool MatchEmailAndPassword()
        {
            List<User> users = GetUserList();
            var query = from User u in users
                        where u.email == this.email && u.password == this.password
                        select u;
            return query != null;
        }

        public List<User> GetUserList()
        {
            var users = new List<User>();
            using (StreamReader sr = new StreamReader(@"C:\Resources\User.txt"))
            {
                while (!sr.EndOfStream)
                {
                    users.Add(JsonConvert.DeserializeObject<User>(sr.ReadLine()));
                }
            }
            return users;
        }

        public void SaveAccountToFile() 
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(@"C:\Resources\User.txt", true))       // true means append to file
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this);
                sw.WriteLine();
            }
        }
    }
}
