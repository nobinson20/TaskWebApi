using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Data;

namespace WebApi.Repo.Repositories
{
    public interface IQuoteRepository : IGenericRepository<Quote>
    {
        void ChangeQuoteType(int id, string quoteType);
        void PutQuote(int id, Quote quote);
    }
}
