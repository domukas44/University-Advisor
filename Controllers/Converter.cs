using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_advisor.Entity;

namespace University_advisor.Controllers
{
    public class Converter
    {
        public static Subject ConvertToMySubject(SubjectWS.Subject s)
        {
            return new Subject() { Id = s.Id, Name = s.Name, Rating = s.Rating };
        }

        public static University_advisor.SubjectWS.Subject ConvertToWSSubject(Subject s)
        {
            return new University_advisor.SubjectWS.Subject() { Id = s.Id, Name = s.Name, Rating = s.Rating };
        }

        public static List<User> ConvertUserWSArrayToUserList(UserWS.User[] arr)
        {
            var list = new List<User>();
            foreach (var u in arr)
            {
                list.Add(new User() { Name = u.Name, Email = u.Email, Password = u.Password });
            }
            return list;
        }
    }
}
