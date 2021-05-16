using MTGCore.Services.Interfaces;

namespace MTGCore.Services.TestImplementations
{
    public class TestFileService : IFileService
    {
        private readonly bool _fileExists;
        public TestFileService(bool exists)
        {
            _fileExists = exists;
        }
        
        public bool FileExists(string filePath)
        {
            return _fileExists;
        }
    }
}
