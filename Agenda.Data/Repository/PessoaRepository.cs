using Agenda.Data.Context;
using Agenda.Data.Domain;

namespace Agenda.Data.Repository
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        
        public PessoaRepository(Contexto context) : base(context)
        {
        }

        public Pessoa GetById(int id)
        {
            if (id == 1)
            {
                return new Pessoa
                {
                    Id = 1,
                    Nome = "Teste"
                };
            }

            return null;

         }
     }
}

