using System;

namespace YRM.Fulfillment.Processing.Helpers
{
    public static class StringHelper
    {
        public static string ProcessArgs(string arg)
        {
            var s = arg?.ToLower() ?? "";
            if (s.Length > 0 && (s[0] == '-' || s[0] == '/'))
                s = s.Substring(1);
            return s;
        }
    }
}
