using System;
using System.Linq;

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

        public static string ProcessArgsByName(string name, params string[] param)
        {
            var s = param.FirstOrDefault(x => x.Substring(0, x.IndexOf(":", StringComparison.InvariantCultureIgnoreCase)).Equals(name, StringComparison.InvariantCultureIgnoreCase) || x.StartsWith(name[0].ToString()));
            return s?.Substring(s.IndexOf(":", StringComparison.InvariantCultureIgnoreCase), s.Length);
        }
    }
}
