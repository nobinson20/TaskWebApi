using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Data;
using WebApi.Repo.Repositories;

namespace WebApi.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskDBEntities _context;

        public UnitOfWork(TaskDBEntities context)
        {
            _context = context;
            Quotes = new QuoteRepository(context);
        }

        public IQuoteRepository Quotes { get; set; }



        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
