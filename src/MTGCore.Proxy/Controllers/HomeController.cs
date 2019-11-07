using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MTGCore.Proxy.Models;

namespace MTGCore.Proxy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("v1/cards/{id}")]
        public async Task<IActionResult> cards(int id)
        
        {
            //https://localhost:44305/card/Details?id=397641
            //get path
            var path = Request.Path;


            //hash path


            //see if path exists as json object

            //if yes
            //serve up object using json contents


            //if not 
            //call mtg service

            //generate new json with {hash}.json from returned string from webservice


            

            //var uri = new Uri(t1);
            //Request.Url.Segments[2]; //Index of directory2

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://api.magicthegathering.io" + path);



            var httpClient = _httpClientFactory.CreateClient();

            var mtgResponse = await httpClient.SendAsync(request);

            if (mtgResponse.IsSuccessStatusCode)
            {
                var responseStream = await mtgResponse.Content.ReadAsStringAsync();

                return Content(responseStream);
            }

            return Content("FAIL");
        }
    }
}
