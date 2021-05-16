using Moq;
using MTGCore.Configuration.Interfaces;
using MTGCore.Dtos.Enums;
using MTGCore.Services;
using MTGCore.Services.Exceptions;
using Shouldly;
using Xunit;

namespace MTGCore.Tests
{
    public class ManaSymbolFactoryTests
    {
        [Fact]
        public void Build_WithUnknownManaSymbol_ShouldThrow()
        {
            var imageMapper = Mock.Of<IManaSymbolImageMap>();
            var factory = new ManaSymbolFactory(imageMapper);
            
            Assert.Throws<ManaSymbolFactoryException>(() => factory.Build("Unknown"));
        }
        
        [Theory]
        [InlineData("U", ManaSymbolType.Blue)]
        [InlineData("B", ManaSymbolType.Black)]
        [InlineData("0", ManaSymbolType.Colorless)]
        [InlineData("W", ManaSymbolType.White)]
        [InlineData("R", ManaSymbolType.Red)]
        [InlineData("G", ManaSymbolType.Green)]
        public void Build_WithValidSymbol_ShouldValidManaSymbol(string manaSymbol, ManaSymbolType type)
        {
            const string imageName = "ImageName.jpg";

            var imageMapper = Mock.Of<IManaSymbolImageMap>(m => m.GetValue(manaSymbol) == imageName);
            var factory = new ManaSymbolFactory(imageMapper);

            var result = factory.Build(manaSymbol);
            result.ImageName.ShouldBe(imageName);
            result.Type.ShouldBe(type);
        }
    }
}