using MTGCore.Services.Interfaces;
using System;
using System.IO;

namespace MTGCore.Services
{
    public class ManaConversionService : IConversionService
    {
        public string ConvertToSymbol(string? manaCost, string root)
        {
            //this may be a redundant check
            if (manaCost == null)
            {
                return "";
            }

            string[] sections = manaCost.Split(new string[] { "{", "}" }, StringSplitOptions.RemoveEmptyEntries);
            string output = "";
            foreach (string section in sections)
            {
                if (File.Exists(root + $"{section}.svg"))
                {
                    output += string.Format("<img src=\"/images/{0}.svg\" height=\"20\" width=\"20\" />", section);
                } else
                {
                    output += $"{{{section}}}";
                }
                
            }
            return output;
        }
    }
}
