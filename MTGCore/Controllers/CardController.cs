using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTGCore.Models;
using MTGCore.Services;
using Newtonsoft.Json;

namespace MTGCore.Controllers
{
    public class CardController : Controller
    {
        private MTGService _mtgService;


        public CardController( MTGService mtgservice)
        {
            _mtgService = mtgservice;
        }


        public async Task<ActionResult> Index(int Page)
        {
            string baseUrl = "https://api.magicthegathering.io/";

            List<Card> cards = new List<Card>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("v1/cards?page=1");

                Res = await client.GetAsync("v1/cards?page=" + Page.ToString());

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    var t1 = JsonConvert.DeserializeObject<RootObject>(EmpResponse).cards;
                    return View(t1);
                }

            }

            return NotFound();
            
        }

        [HttpGet]
        public async Task<ActionResult> Get() 
        {

            var response = await _mtgService.GetCardByID(74208);

            var response2 = await _mtgService.GetCardsByPage(1);

            if (response == null)
                return NotFound();

            return Ok(response);

        }
    }
}