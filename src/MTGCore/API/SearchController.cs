using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
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

        public SearchController(MTGService mtgservice, IConversionService conversion, IMapper mapper)
        {
            _mtgService = mtgservice;
            _conversion = conversion;
            _mapper = mapper;
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        public async Task<List<CardDto>> Post([FromBody] FormViewModel form)
        {
            var response = await _mtgService.GetCardByName(form.Name);

            var cardList = _mapper.Map<List<CardDto>>(response);

            return cardList;
        }
    }
}
