using System;

namespace worthWatchingAPI.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static string TrimNumFromEnd(this String str, int numToDelete)
        {
            int length = str.Length;
            return str.Remove(length-numToDelete);
        }
    }
}