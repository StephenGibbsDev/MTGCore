using Microsoft.AspNetCore.Hosting;
using Moq;
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
            string manaCostString1 = "{POOP}{R}{5}";
            string manaCostString2 = "{W}{R}{5}";
            string rootPath = @"D:\Program Files (x86)\Github\MTGCore\src\MTGCore\wwwroot";

            string convertedManaCost1 = _conversion.ConvertToSymbol(manaCostString1, $@"{rootPath}\images\");
            string convertedManaCost2 = _conversion.ConvertToSymbol(manaCostString2, $@"{rootPath}\images\");

            convertedManaCost1.ShouldBe("{POOP}<img src=\"/images/R.svg\" height=\"20\" width=\"20\" /><img src=\"/images/5.svg\" height=\"20\" width=\"20\" />");
            convertedManaCost2.ShouldBe("<img src=\"/images/W.svg\" height=\"20\" width=\"20\" /><img src=\"/images/R.svg\" height=\"20\" width=\"20\" /><img src=\"/images/5.svg\" height=\"20\" width=\"20\" />");
        }
    }
}
