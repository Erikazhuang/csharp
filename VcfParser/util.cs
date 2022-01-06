using System.Text.RegularExpressions;

namespace VcfService
{
    public static class Util
    {
        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }

    }
    
 }
 