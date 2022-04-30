using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repo.Repositories;

namespace WebApi.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        IQuoteRepository Quotes { get; }

        int Complete();
    }
}
