using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_advisor.Controllers;

namespace University_advisor.Controllers
{
    public class User : IAccount
    {
        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public User(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;

            if (!checkIfExists())
                saveAccountToFile();
            else
                throw new ArgumentException("This email is already registered.");
        }

        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public User()
        {

        }

        public bool checkIfExists()
        {
            List<User> users = getUserList();
            if ((users.Find(x => x.email == this.email)) != null)
                return true;
            else
                return false;
        }

        public bool checkIfExists(IAccount user)
        {
            List<User> users = getUserList();
            if ((users.Find(x => x.email == user.email)) != null)
                return true;
            else
                return false;
        }

        public List<User> getUserList()
        {
            var users = new List<User>();
            using (StreamReader sr = new StreamReader(@"..\..\Resources\User.txt"))
            {
                while (!sr.EndOfStream)
                {
                    users.Add(JsonConvert.DeserializeObject<User>(sr.ReadLine()));
                }
            }

            return users;
        }

        public void saveAccountToFile() 
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(@"..\..\Resources\User.txt", true))       // true means append to file
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this);
                sw.WriteLine();
            }
        }



    }
}
