using MTGCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCore.Services
{
    public class FileService : IFileService
    {
        // Standard file service
        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
