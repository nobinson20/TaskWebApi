using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Data;
using WebApi.Repo;
using WebApi.Service.DTO;

namespace TaskWebApi.WebApi.Service
{
    public class QuoteService
    {
        public UnitOfWork uow { get; set; }
        public TaskDBEntities taskDb;
        MapperConfiguration config;
        IMapper mapper;

        public QuoteService()
        {
            this.taskDb = new TaskDBEntities();
            this.uow = new UnitOfWork(taskDb);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Quote, QuoteDTO>();
                cfg.CreateMap<QuoteDTO, Quote>();
            }
            );
            mapper = config.CreateMapper();
        }

        public QuoteDTO GetById(int id)
        {
            var quote = uow.Quotes.GetById(id);
            return mapper.Map<QuoteDTO>(quote);
        }


        public List<QuoteDTO> GetAll()
        {
            IEnumerable<Quote> quotes = uow.Quotes.GetAll();
            List<QuoteDTO> quoteDTOs = new List<QuoteDTO>();

    

            foreach(var quote in quotes)
            {
                quoteDTOs.Add(mapper.Map<QuoteDTO>(quote));
            }

            return quoteDTOs;
        }

        // post
        public void PostQuote(QuoteDTO quoteDTO)
        {
            Quote quote = mapper.Map<Quote>(quoteDTO);
            uow.Quotes.Add(quote);
            uow.Complete();
        }

        // delete
        public QuoteDTO DeleteQuote(int id)
        {
            Quote foundQuote = uow.Quotes.GetById(id);
            if (foundQuote != null)
            {
                uow.Quotes.Remove(foundQuote);
                uow.Complete();
                return mapper.Map<QuoteDTO>(foundQuote);
            }
            else
            {
                return null;
            }
            

            
        }

        // put
        public void PutQuoteType(int id, string quoteType)
        {
            uow.Quotes.ChangeQuoteType(id, quoteType);
          
        }

        public void PutQuote(int id, QuoteDTO quoteDTO)
        {
            uow.Quotes.PutQuote(id, mapper.Map<Quote>(quoteDTO));
        }
    }
}
