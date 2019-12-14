namespace UniversityAdvisor
{
    public static class Constants
    {
        // URL of ASMX service
        public static string SubjectSoapUrl
        {
            get
            {
                return "http://192.168.1.42:59379/SubjectService.asmx";
            }
        }
        public static string ReviewSoapUrl
        {
            get
            {
                return "http://192.168.1.42:59379/ReviewService.asmx";
            }
        }
    }
}
