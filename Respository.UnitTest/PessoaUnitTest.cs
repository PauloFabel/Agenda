using System;
using Agenda.Data.Domain;
using Agenda.Data.Context;
using Agenda.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marten.Services;

namespace Repository.UnitTest
{
    [TestClass]
    public class PessoaUnitTest
    {
         UnitOfWork _unitOfWork = new UnitOfWork();

        [TestMethod]
        public void Adicionar()
        {
            Pessoa novaPessoa = new Pessoa();

            novaPessoa.Nome = "Paulo Fabel";
            novaPessoa.Cidade = "São Paulo";
            novaPessoa.Estado = "SP";
           

            _unitOfWork.PessoaRepository.Add(novaPessoa);
        }

        [TestMethod]
        public void Editar()
        {
            Pessoa editarPessoa = _unitOfWork.PessoaRepository.Get(x => x.id == 1000)[0];

            editarPessoa.Nome = "John Doel Gates";
            editarPessoa.Cidade = "São Paulo";
            editarPessoa.Estado = "SP";

            _unitOfWork.PessoaRepository.Add(editarPessoa);
        }

        [TestMethod]
        public void Deletar()
        {
            Pessoa deletarPessoa = _unitOfWork.PessoaRepository.Get(x => x.id == 1000)[0];
            _unitOfWork.PessoaRepository.Delete(deletarPessoa);
        }
    }
}