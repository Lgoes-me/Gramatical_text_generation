using System.Collections.Generic;

namespace Utils
{
    public static class Extensions
    {
        public static bool ContainsAny(this string text, List<string> keys, out List<string> found)
        {
            found = new List<string>();
            
            foreach (var key in keys)
            {
                if (text.Contains(key))
                {
                    found.Add(key);
                }
            }

            return found.Count > 0;
        }
    }
}