using MTGCore.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MTGCore.Tests
{
    public class HelperClassesTest
    {
        private readonly ManaConversionService _conversion;
        public HelperClassesTest()
        {
            _conversion = new ManaConversionService();
        }

        [Fact]
        public void ManaConvert()
        {
            string manaCost = "{W}{R}{5}";

            string convertedManaCost = _conversion.ConvertToSymbol(manaCost);

            convertedManaCost.ShouldBe("<img src=\"/images/W.svg\" height=\"20\" width=\"20\" /><img src=\"/images/R.svg\" height=\"20\" width=\"20\" /><img src=\"/images/5.svg\" height=\"20\" width=\"20\" />");
        }
    }
}
