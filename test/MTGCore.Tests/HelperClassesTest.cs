using MTGCore.Services;
using MTGCore.Services.Interfaces;
using MTGCore.Services.TestImplementations;
using Shouldly;
using Xunit;

namespace MTGCore.Tests
{
    public class HelperClassesTest
    {
        private readonly ManaConversionService _conversion;

        public HelperClassesTest()
        {
            IFileService fileService = new TestFileService();
            _conversion = new ManaConversionService(fileService, "");
        }

        [Fact]
        public void ManaConvert()
        {
            string manaCostString1 = "{false}{R}{5}";
            string manaCostString2 = "{W}{R}{5}";

            string convertedManaCost1 = _conversion.ConvertToSymbol(manaCostString1);
            string convertedManaCost2 = _conversion.ConvertToSymbol(manaCostString2);

            convertedManaCost1.ShouldBe("{false}<img src=\"/images/R.svg\" height=\"20\" width=\"20\" /><img src=\"/images/5.svg\" height=\"20\" width=\"20\" />");
            convertedManaCost2.ShouldBe("<img src=\"/images/W.svg\" height=\"20\" width=\"20\" /><img src=\"/images/R.svg\" height=\"20\" width=\"20\" /><img src=\"/images/5.svg\" height=\"20\" width=\"20\" />");
        }
    }
}
