using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskWebApi.WebApi.Models;
using TaskWebApi.WebApi.Service;
using WebApi.Service.DTO;

namespace TaskWebApi.WebApi.Controllers
{
    [Authorize]
    public class QuoteController : ApiController
    {
        public QuoteService quoteService;
        MapperConfiguration config;
        IMapper mapper;

        public QuoteController()
        {
            quoteService = new QuoteService();
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuoteModel, QuoteDTO>();
                cfg.CreateMap<QuoteDTO, QuoteModel>();
            }
            );
            mapper = config.CreateMapper();
        }

        /// <summary>
        /// GET api/quote
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<QuoteDTO> GetQuotes()
        {
            return quoteService.GetAll();
        }

        [HttpGet]
        [Route("api/Quote/{id}")]
        public QuoteDTO GetQuoteById(int id)
        {
            return quoteService.GetById(id);
        }

        [HttpPost]
        public void PostQuote(QuoteModel quoteModel)
        {
            QuoteDTO quoteDTO = mapper.Map<QuoteDTO>(quoteModel);
            quoteService.PostQuote(quoteDTO);
        }

        [HttpDelete]
        [Route("api/Quote/{id}")]
        public void DeleteQuote(int id)
        {
            quoteService.DeleteQuote(id);
        }

        [HttpPut]
        [Route("api/Quote/{id}/{quoteType}")]
        public void PutQuoteType(int id, string quoteType)
        {
            quoteService.PutQuoteType(id, quoteType);
        }
    }
}
