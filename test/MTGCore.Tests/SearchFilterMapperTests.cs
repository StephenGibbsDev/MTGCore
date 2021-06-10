using MTGCore.Services;
using MTGCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Microsoft.AspNetCore.Http.Extensions;

namespace MTGCore.Tests
{
    public class SearchFilterMapperTests
    {
        private SearchFilterMapper mapper = new SearchFilterMapper();
        private SearchFilter searchFilter = new SearchFilter()
        {
            Name = "Bomb",
            Type = "Artifact",
            Rarity = "Common",
            Set = null,
            Colours = new List<string>() {"B","C","U"}
        };

        private SearchFilter searchFilterColoursNull = new SearchFilter()
        {
            Name = "Angel",
            Type = null,
            Rarity = null,
            Set = null,
            Colours = null
        };


        [Fact]
        public void returns_list_of_query_string_Parameters()
        {

            var queryString = mapper.map(searchFilter);

            queryString.ShouldBe("?name=Bomb&type=Artifact&rarity=Common&colours=B,C,U");
        }

        [Fact]
        public void returns_null_Colours()
        {
            var queryString = mapper.map(searchFilterColoursNull);

            queryString.ShouldBe("?name=Angel");
        }

    }
}
