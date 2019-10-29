using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCore.HelperClasses
{
    public static class ManaConvert
    {
        public static string String (string manaCost)
        {
            string[] sections = manaCost.Split(new string[] { "{", "}" }, StringSplitOptions.RemoveEmptyEntries);
            string output = "";
            foreach (string section in sections)
            {
                output += string.Format($"<img src=\"/images/{section}.svg\" height=\"20\" width=\"20\" />");
            }
            return output;
        }
    }
}
