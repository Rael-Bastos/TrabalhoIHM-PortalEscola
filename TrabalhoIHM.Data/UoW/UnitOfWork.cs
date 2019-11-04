using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrabalhoIHM.Domain.Interfaces.UoW;

namespace TrabalhoIHM.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EscolaContext _context;

        public UnitOfWork(EscolaContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
