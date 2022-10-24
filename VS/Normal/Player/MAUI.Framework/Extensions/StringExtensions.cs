using System.Text.RegularExpressions;

namespace MAUIApp.Framework.Extensions
{
    public static class StringExtensions
    {
        public static string CleanCacheKey(this string uri) =>
            Regex.Replace(new Regex("[\\~#%&*{}/:<>?|\"-]").Replace(uri, " "), @"\s+", "-");

        public static string FormattedNumber(this string number) =>
            Convert.ToDouble(number).FormattedNumber();
    }
}
