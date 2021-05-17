using System;
using System.Collections.Generic;
using MTGCore.Services;
using Shouldly;
using Xunit;

namespace MTGCore.Tests
{
    public class ManaStringParserTests
    {
        [Theory]
        [InlineData("{B}{B}{B}", new[] { "B", "B", "B" })]
        [InlineData("{<}{A}{>}", new[] { "<", "A", ">" })]
        public void Parse_ForValidCost_ShouldReturnManaSymbolTextArray(string manaCost, IEnumerable<string> output)
        {
            var parser = new ManaStringParser();
            var result = parser.Parse(manaCost);
            
            result.ShouldBe(output);
        }
        
        [Fact]
        public void Parse_ForInvalidString_ShouldThrow()
        {
            var parser = new ManaStringParser();
            Assert.Throws<InvalidOperationException>(() => parser.Parse(null));
        }
    }
}