using System.Text.RegularExpressions;

namespace StudentSystem.Models
{
    public static class TagTransofrmer
    {
        public static string Transform(string inputString)
        {
            string result = Regex.Replace(inputString, " ", "");

            if (!result.StartsWith("#"))
            {
                result = "#" + result;
            }

            if (result.Length > 20)
            {
                result = result.Substring(0, 19);
            }

            return result;
        }
    }
}