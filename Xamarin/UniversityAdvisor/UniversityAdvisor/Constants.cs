using Xamarin.Forms;

namespace UniversityAdvisor
{
    public static class Constants
    {
        // URL of ASMX service
        public static string SoapUrl
        {
            get
            {
                var defaultUrl = "http://192.168.1.42:59379/SubjectService.asmx";

                if (Device.RuntimePlatform == Device.Android)
                {
                    defaultUrl = "http://192.168.1.42:59379/SubjectService.asmx";
                }

                return defaultUrl;
            }
        }
    }
}
