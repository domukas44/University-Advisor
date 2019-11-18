using System.Web.Hosting;
using System.Web.Services;
using University_advisor.Entity;

namespace WebService
{
    /// <summary>
    /// Summary description for DeserializerWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ReviewWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public Review GetLastReview()
        {
            return Deserializer<Review>.DeserializeLine(HostingEnvironment.ApplicationPhysicalPath + @"..\Resources\LastReview.txt");
        }
    }
}
