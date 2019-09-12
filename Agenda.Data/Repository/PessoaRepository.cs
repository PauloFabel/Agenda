using System;
using System.Collections.Generic;
using System.Text;
using Agenda.Data.Context;
using Agenda.Data.Domain;

namespace Agenda.Data.Repository
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(Contexto context) : base(context)
        {
        }
    }
}
