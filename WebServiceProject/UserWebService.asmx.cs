using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using System.Web.Services;
using University_advisor.Entity;

namespace WebService
{
    /// <summary>
    /// Summary description for UserWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public bool EmailValidation(string email)
        {
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Match match = Regex.Match(email, pattern);
            return match.Success;
        }
        [WebMethod]
        public bool PasswordValidation(string password)
        {
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";
            Match match = Regex.Match(password, pattern);
            return match.Success;
        }

        [WebMethod]
        public List<User> GetUserList()
        {
            return Deserializer<User>.DeserializeFile(HostingEnvironment.ApplicationPhysicalPath + @"..\Resources\User.txt");
        }
    }
}
