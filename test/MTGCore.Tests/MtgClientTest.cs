using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using RichardSzalay.MockHttp;
using Shouldly;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using MTGCore.MtgClient.Api.Services;
using Xunit;

namespace MTGCore.Tests
{
    public class MtgClientTest
    {

        [Fact]
        public async Task returns_a_single_card()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"card\": {\"name\": \"TestyCard\"}}"),
                });
            
            var client = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://localhost:44317/v1/")
            };

            var mtgHttpClient = new MtgHttpClient(client, Mock.Of<ILogger<MtgHttpClient>>());
            var user = await mtgHttpClient.GetCardByMultiverseId(74208);

            user.name.ShouldBe("TestyCard");
        }

        [Fact]
        public async Task returns_multiple_card()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"cards\": [{\"name\": \"TestyCard\"},{\"name\": \"secondtesty\"}]}"),
                });
            
            var client = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://localhost:44317/v1/")
            };

            var mtgService = new MtgHttpClient(client, Mock.Of<ILogger<MtgHttpClient>>());
            var user = await mtgService.GetCardsByPage(1);

            user.Count().ShouldBe(2);
        }
    }
}
