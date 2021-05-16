using MTGCore.Dtos.Enums;

namespace MTGCore.Dtos.Models
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