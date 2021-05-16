using System.Linq;
using Moq;
using MTGCore.Services;
using MTGCore.Services.Interfaces;
using Shouldly;
using Xunit;

namespace MTGCore.Tests
{
    public class ManaCostConverterTests
    {
        [Fact]
        public void Convert_ForInvalidManaCostString_ShouldReturnEmptyManaSymbolEnumerable()
        {
            const string input = null;
            
            var manaSymbolFactoryStub = Mock.Of<IManaSymbolFactory>();
            var converter = new ManaCostConverter(manaSymbolFactoryStub, new ManaStringParser());
            var result = converter.Convert(input);
            
            result.Count().ShouldBe(0);
        }
    }
}