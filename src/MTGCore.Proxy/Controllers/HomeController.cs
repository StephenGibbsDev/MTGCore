﻿using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MTGCore.Proxy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("{*anyRoute}")]
        public async Task<IActionResult> cards(int id)

        {
            //https://localhost:44305/card/Details?id=397641

            var path = Request.Path + Request.QueryString;

            var hashedPath = CalculateMD5Hash(path);

            var root = Environment.CurrentDirectory;
            var fullPath = $@"{root}\Data\{hashedPath}.json";

            if (!System.IO.File.Exists(fullPath))
            {
                var request = new HttpRequestMessage(HttpMethod.Get,
                   "https://api.magicthegathering.io" + path);

                var httpClient = _httpClientFactory.CreateClient();

                var mtgResponse = await httpClient.SendAsync(request);

                if (!mtgResponse.IsSuccessStatusCode)
                {
                    // TODO(CD): Use more specific exception
                    throw new Exception("Call to MTG API failed");
                }
                
                var responseStream = await mtgResponse.Content.ReadAsStringAsync();
                //store card here as json
                System.IO.File.WriteAllText(fullPath, responseStream);

                return Content(responseStream);
            }
                //reads from json file and return the string to 
                string json = System.IO.File.ReadAllText(fullPath);

                return Content(json);
        }

        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}
