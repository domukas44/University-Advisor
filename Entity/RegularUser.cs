namespace University_advisor.Entity
{
    public class RegularUser : User
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

        
    }
}
