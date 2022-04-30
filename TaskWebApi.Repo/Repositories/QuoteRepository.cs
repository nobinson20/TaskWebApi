using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Data;

namespace WebApi.Repo.Repositories
{
    public class QuoteRepository : GenericRepository<Quote>, IQuoteRepository
    {
        
        public QuoteRepository(TaskDBEntities taskDb) : base(taskDb)
        {

        }

        public void ChangeQuoteType(int id, string quoteType)
        {
            using (var db = new TaskDBEntities())
            {
                var result = db.Quote.SingleOrDefault(q => q.ID == id);
                if (result != null)
                {
                    result.QuoteType = quoteType;
                }
                db.SaveChanges();
            }

            
        }
    }
}
