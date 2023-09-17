using System.Text.RegularExpressions;

namespace CrossCutting.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extract the numbers of a string
        /// </summary>
        /// <param name="texto">Numbers,as string, with special symbols or letters</param>
        /// <returns>Only the numbers, without letters or special chars</returns>
        public static string ExtractNumbers(this string text)
        {
            return Regex.Replace(text, @"[^\d]", "");
        }
    }
}
