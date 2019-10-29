using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MTGCore.Tests
{
    public class HelperClassesTest
    {
        [Fact]
        public void ManaConvert()
        {
            string manaCost = "{W}{R}{5}";

            string convertedManaCost = MTGCore.HelperClasses.ManaConvert.String(manaCost);

            convertedManaCost.ShouldBe("<img src=\"/images/W.svg\" height=\"20\" width=\"20\" /><img src=\"/images/R.svg\" height=\"20\" width=\"20\" /><img src=\"/images/5.svg\" height=\"20\" width=\"20\" />");
        }
    }
}
