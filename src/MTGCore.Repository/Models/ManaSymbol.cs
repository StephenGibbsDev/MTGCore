using MTGCore.Repository.Enums;

namespace MTGCore.Repository.Models
{
    public class ManaSymbol
    {
        public ManaSymbol(ManaSymbolType type, string imageName)
        {
            Type = type;
            ImageName = imageName;
        }
        
        public ManaSymbolType Type { get; }
        public string ImageName { get; }
    }
}