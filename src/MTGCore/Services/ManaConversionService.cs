using MTGCore.Models;
using MTGCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCore.Services
{
    public class ManaConversionService : IConversionService
    {
        public string ConvertToSymbol(string? manaCost)
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
                output += string.Format("<img src=\"/images/{0}.svg\" height=\"20\" width=\"20\" />", section);
            }
            return output;
        }
    }
}
