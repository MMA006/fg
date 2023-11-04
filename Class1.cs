using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laba_1
{
    internal class Class1
    {
        public static MatchCollection Find(string s, string signature)
        {
            Regex regex = new Regex(signature, RegexOptions.IgnoreCase);
            if (s != null)
            {
                MatchCollection matches = regex.Matches(s);
                return matches;
            }
            else
            {
                return null;
            }
        }
        public static MatchCollection Date(string s)
        {
            Regex regex = new Regex(@"[0-9]{2}.[0-9]{2}.[0-9]{4}");
            if (s != null)
            {
                MatchCollection matches = regex.Matches(s);
                return matches;
            }
            else
            {
                return null;
            }
        }
    }
}
