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
        [Fact]
        public void returns_list_of_query_string_Parameters()
        {
            var mapper = new SearchFilterMapper();
            var searchFilter = new SearchFilter() 
            { 
                Name = "Bomb",
                Type = "Artifact",
                Rarity = "Common",
                Price = "100",
                Set = "TEST"
            };

            IEnumerable<KeyValuePair<string,string>> queryStringList = mapper.map(searchFilter);


            var name = queryStringList.Where(x => x.Key == "Name").Single();
            name.Value.ShouldBe("Bomb");


            var type = queryStringList.Where(x => x.Key == "Type").Single();
            type.Value.ShouldBe("Artifact");

        }
    }
}
