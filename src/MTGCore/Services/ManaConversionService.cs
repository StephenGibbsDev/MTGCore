using Microsoft.AspNetCore.Hosting;
using MTGCore.Services.Interfaces;
using System;
using System.IO;

namespace MTGCore.Services
{
    public class ManaConversionService : IConversionService
    {
        private readonly IFileService _file;
        private readonly string _root;

        public ManaConversionService(IFileService file, string root)
        {
            _file = file;
            _root = root;
        }

        public string ConvertToSymbol(string manaCost)
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
                if (_file.FileExists($"{_root}{section}.svg"))
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
