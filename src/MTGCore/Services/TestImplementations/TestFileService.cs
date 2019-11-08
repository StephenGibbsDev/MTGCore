using MTGCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCore.Services.TestImplementations
{
    public class TestFileService : IFileService
    {
        // File service for unit tests
        public bool FileExists(string filePath)
        {
            if (filePath.Contains("false"))
                return false;
            else
                return true;
        }
    }
}
