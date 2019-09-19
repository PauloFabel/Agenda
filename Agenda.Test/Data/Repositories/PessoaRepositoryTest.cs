using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Agenda.Data.Repository;

namespace Sample.Teste.Data.Repositories
{
    public class PessoaRepositoryTest : BaseTest
    {
        [Fact]
        public void GetById_Success()
        {
            var repository = GetService<IPessoaRepository>();

            var result = repository.GetById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            
        }

        [Fact]
        public void GetById_NotFound()
        {
            var repository = GetService<IPessoaRepository>();

            var result = repository.GetById(2);

            Assert.Null(result);

        }
    }

}
