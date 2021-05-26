using MTGCore.Services;
using MTGCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace MTGCore.Tests
{
    public class SearchFilterMapperTests
    {
        private SearchFilterMapper mapper = new SearchFilterMapper();
        private SearchFilterWithColours searchFilter = new SearchFilterWithColours()
        {
            Name = "Bomb",
            Type = "Artifact",
            Rarity = "Common",
            Price = "100",
            Set = null,
            Colours = new List<string>() {"B","C","U"}
        };


        [Fact]
        public void returns_list_of_query_string_Parameters()
        {

            Dictionary<string,string> queryStringList = mapper.map(searchFilter);


            var name = queryStringList.Where(x => x.Key == "name").Single();
            name.Value.ShouldBe("Bomb");


            var type = queryStringList.Where(x => x.Key == "type").Single();
            type.Value.ShouldBe("Artifact");
        }

        [Fact]
        public void returns_CSV()
        {

            var queryStringList = mapper.map(searchFilter);

            var csv = queryStringList.Where(x => x.Key == "colours").Single();
            csv.Value.ShouldBe("B,C,U");
        }

    }
}
