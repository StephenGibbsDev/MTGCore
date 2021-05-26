using System.Linq;
using RichardSzalay.MockHttp;
using Shouldly;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using MTGCore.MtgClient.Api.Services;
using Xunit;

namespace MTGCore.Tests
{
    public class MtgClientTest
    {

        [Fact]
        public async Task returns_a_single_card()
        {
            var mockHttp = new MockHttpMessageHandler();

            //setup mock test
            mockHttp.When("https://localhost:44317/v1/*")
                    .Respond("application/json", "{'card': {'name': 'TestyCard'}}"); // Respond with JSON

            var client = mockHttp.ToHttpClient();

            var mtgservice = new MtgHttpClient(client, Mock.Of<ILogger<MtgHttpClient>>());
            var user = await mtgservice.GetCardByMultiverseId(74208);

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

            var mtgservice = new MtgHttpClient(client, Mock.Of<ILogger<MtgHttpClient>>());
            var user = await mtgservice.GetCardsByPage(1);

            user.Count().ShouldBe(2);
        }
    }
}
