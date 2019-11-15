using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using University_advisor.Controllers;

namespace University_advisor.Entity
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;

            if (!CheckIfExists())
                SaveAccountToFile();
            else
                throw new Exception();
        }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
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
            return (users.Find(x => x.Email == this.Email)) != null;
        }

        public bool MatchEmailAndPassword()
        {
            List<User> users = GetUserList();
            var query = from User u in users
                        where u.Email == this.Email && u.Password == this.Password
                        select u;
            return query != null;
        }

        public List<User> GetUserList()
        {
            return Converter.ConvertUserWSArrayToUserList(new UserWS.UserWebService().GetUserList());
        }

        public void SaveAccountToFile()
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
