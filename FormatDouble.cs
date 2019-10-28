namespace University_advisor
{
    public static class FormatDouble
    {
        public static string FormatForRating(this double line)
        {
            return line.ToString("0.##") + "/10";
        }
    }
}