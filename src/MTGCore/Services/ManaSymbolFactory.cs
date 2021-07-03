using MTGCore.Configuration.Interfaces;
using MTGCore.Repository.Enums;
using MTGCore.Repository.Models;
using MTGCore.Services.Exceptions;
using MTGCore.Services.Interfaces;

namespace MTGCore.Services
{
    public class ManaSymbolFactory : IManaSymbolFactory
    {
        private readonly IManaSymbolImageMap _imageMapper;

        public ManaSymbolFactory(IManaSymbolImageMap imageMapper)
        {
            _imageMapper = imageMapper;
        }
        
        public ManaSymbol Build(string manaSymbol)
        {
            switch (manaSymbol)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "11":
                case "12":
                case "C":
                case "X":
                    return new ManaSymbol(ManaSymbolType.Colorless,  TryGetImageName(manaSymbol));
                case "R":
                case "2R":
                    return new ManaSymbol(ManaSymbolType.Red,  TryGetImageName(manaSymbol));
                case "G":
                case "2G":
                    return new ManaSymbol(ManaSymbolType.Green, TryGetImageName(manaSymbol));
                case "B":
                case "2B":
                    return new ManaSymbol(ManaSymbolType.Black,  TryGetImageName(manaSymbol));
                case "U":
                case "2U":
                    return new ManaSymbol(ManaSymbolType.Blue,  TryGetImageName(manaSymbol));
                case "W":
                case "2W":
                    return new ManaSymbol(ManaSymbolType.White,  TryGetImageName(manaSymbol));
                default:
                    throw new ManaSymbolFactoryException($"The symbol {manaSymbol} is not supported in {nameof(ManaSymbolFactory)}");
            }
        }

        private string TryGetImageName(string manaSymbol)
        {
            return _imageMapper.GetValue(manaSymbol);
        }
    }
}