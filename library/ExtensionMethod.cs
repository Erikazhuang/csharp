namespace ExtensionLibrary
{
    public static class StringExtensions
    {
        public static int WordCount(this string str)
        {
            return  str.Split(new char[] { ' ', '.', '?' },StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}


