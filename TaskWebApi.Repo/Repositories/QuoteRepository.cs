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

        public void PutQuote(int id, Quote quote)
        {
            using (var db = new TaskDBEntities())
            {
                var result = db.Quote.SingleOrDefault(q => q.ID == id);
                if (result != null)
                {
                    var target = quote.QuoteType;
                    if (target != null)
                        result.QuoteType = target;

                    target = quote.Contact;
                    if (target != null)
                        result.Contact = target;

                    target = quote.Task;
                    if (target != null)
                        result.Task = target;

                    var target2 = quote.DueDate;
                    if (target != null)
                        result.DueDate = target2;

                    target = quote.TaskType;
                    if (target != null)
                        result.TaskType = target;
                }
                db.SaveChanges();
            }
        }
    }
}
