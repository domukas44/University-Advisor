using University_advisor.Data;

namespace University_advisor.Entity
{
    public class RegularUser : User, IUser
    {

        public RegularUser(string name, string email, string password) : base(name, email, password)
        {
            
        }
        public RegularUser(string email, string password) : base(email, password)
        {
        }
        public RegularUser()
        {

        }
        public string ReturnCurrentUserEmail()
        {
            return Email;
        }

    }
}
