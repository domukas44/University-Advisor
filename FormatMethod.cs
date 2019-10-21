using System;

namespace Formats

{
    public static class FormatMethod
    {
        public static string FormatForRating(this double line)
        {
            return line.ToString("0.##") + "/10";
        }
    }
}
