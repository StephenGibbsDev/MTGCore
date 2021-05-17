using MTGCore.Services;
using RichardSzalay.MockHttp;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace MTGCore.Tests
{
    public class MTGServiceTest
    {

        [Fact]
        public async Task returns_a_single_card()
        {
            var mockHttp = new MockHttpMessageHandler();

            //setup mock test
            mockHttp.When("https://localhost:44317/v1/*")
                    .Respond("application/json", "{'card': {'name': 'TestyCard'}}"); // Respond with JSON

            var client = mockHttp.ToHttpClient();

            var mtgservice = new MTGService(client);
            var user = await mtgservice.GetCardByMultiverseID(74208);

            user.name.ShouldBe("TestyCard");
        }

        [Fact]
        public async Task returns_multiple_card()
        {
            var mockHttp = new MockHttpMessageHandler();

            //setup mock test
            mockHttp.When("https://localhost:44317/v1/*")
                    .Respond("application/json", "{'cards': [{'name': 'TestyCard'},{'name': 'secondtesty'}]}"); // Respond with JSON

            var client = mockHttp.ToHttpClient();

            var mtgservice = new MTGService(client);
            var user = await mtgservice.GetCardsByPage(1);

            user.Count.ShouldBe(2);
        }
    }
}
