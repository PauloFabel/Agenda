using Agenda.Data.Context;
using Agenda.Data.Domain;

namespace Agenda.Data.Repository
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        /// <summary>
        /// Construtor da PessoaRepository
        /// </summary>
        /// <param name="context"></param>
        public PessoaRepository(Contexto context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Select feito por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pessoa GetById(int id)
        {
            var pessoa = _context.Pessoa.Find(id);
            if (pessoa != null)
            {
                return pessoa;
            }
            return null;
        }


    }
}

