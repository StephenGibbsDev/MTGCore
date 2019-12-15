using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTGCore.Dtos.Models;
using MTGCore.Services;
using MTGCore.Services.Interfaces;
using MTGCore.ViewModels;

namespace MTGCore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private MTGService _mtgService;
        private readonly IConversionService _conversion;
        private IMapper _mapper;

        public SearchController(MTGService mtgservice, IConversionService conversion, IMapper mapper )
        {
            _mtgService = mtgservice;
            _conversion = conversion;
            _mapper = mapper;
        }

        // GET: api/Search
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Search/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Search
        //[HttpPost]
        //public string Post([FromBody] FormViewModel value)
        //{


        //    return value.Name;
        //}

        // PUT: api/Search/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


       [HttpPost]
       public async Task<List<CardDto>> Post([FromBody] FormViewModel form)
       {
           var response = await _mtgService.GetCardByName(form.Name);

           response.Select(x => { x.manaCost = _conversion.ConvertToSymbol(x.manaCost); return x; }).ToList();

           var cardList = _mapper.Map<List<CardDto>>(response);

           return cardList;
       }
    }
}
