using Agenda.Data.Context;
using Agenda.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data.Repository
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        Contexto _context;

        public PessoaRepository(Contexto context) : base(context)
        {
            context = _context;
        }

        public Pessoa GetById(int id)
        {
            var pessoa = _context.Find(p => p.id)
            if (id != null)
            {

            }
            return null;

        }
    }
}

