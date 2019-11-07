using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCore.Services.Interfaces
{
    public interface IFileService
    {
        bool FileExists(string file);
    }
}
