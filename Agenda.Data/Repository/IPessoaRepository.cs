using Agenda.Data.Domain;

namespace Agenda.Data.Repository
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa>
    {
        Pessoa GetById(int id);

    }
}
