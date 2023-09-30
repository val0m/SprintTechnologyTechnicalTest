namespace BoardingCards.Extensions
{
    public static class StringExtension
    {
        public static string ToLowerString(this string input) => input.ToLower();
        public static string ToLowerString(this Enum input) => ToLowerString(input.ToString());
    }
}
