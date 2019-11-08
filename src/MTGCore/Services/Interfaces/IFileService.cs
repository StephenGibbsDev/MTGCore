using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCore.Services.Interfaces
{
    public interface IFileService
    {
        // File service interface implemented to help with unit testing
        // Can use a separate file service for unit testing
        bool FileExists(string file);
    }
}
