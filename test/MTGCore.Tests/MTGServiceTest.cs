using MTGCore.Services;
using NSubstitute;
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
            mockHttp.When("https://api.magicthegathering.io/v1/*")
                    .Respond("application/json", "{'card': {'name': 'TestyCard'}}"); // Respond with JSON

           var client = mockHttp.ToHttpClient();

            var mtgservice = new MTGService(client);
            var user = await mtgservice.GetCardByID(74208);

            user.name.ShouldBe("TestyCard");
        }

        [Fact]
        public async Task returns_multiple_card()
        {
            var mockHttp = new MockHttpMessageHandler();

            //setup mock test
            mockHttp.When("https://api.magicthegathering.io/v1/*")
                    .Respond("application/json", "{'cards': [{'name': 'TestyCard'},{'name': 'secondtesty'}]}"); // Respond with JSON

            var client = mockHttp.ToHttpClient();

            var mtgservice = new MTGService(client);
            var user = await mtgservice.GetCardsByPage(1);

            user.Count.ShouldBe(2);
        }

        [Fact]
        public void ManaConvert()
        {
            char manaTokenOne = 'W', manaTokenTwo = 'R', manaTokenThree = '5';
            string manaCost = string.Format("{{{0}}}{{{1}}}{{{2}}}", manaTokenOne, manaTokenTwo, manaTokenThree);

            string convertedManaCost = MTGCore.HelperClasses.ManaConvert.String(manaCost);

            convertedManaCost.ShouldBe(string.Format("<img src=\"/images/{0}.svg\" height=\"20\" width=\"20\" /><img src=\"/images/{1}.svg\" height=\"20\" width=\"20\" /><img src=\"/images/{2}.svg\" height=\"20\" width=\"20\" />", manaTokenOne, manaTokenTwo, manaTokenThree));
        }
    }
}
