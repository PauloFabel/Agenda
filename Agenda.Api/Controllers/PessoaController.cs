using Agenda.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Agenda.Data.Domain;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        /// <summary>
        ///Construtor da Controller
        /// </summary>
        /// <param name="pessoaRepository"></param>
        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        /// <summary>
        /// Busca todos os registros do banco de dados.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<Pessoa>), StatusCodes.Status200OK)]
        public ActionResult Get()
        {
            var pessoas = _pessoaRepository.Get();

            if (pessoas == null)
            {
                NotFound();
            }
            return Ok(pessoas);
        }

        /// <summary>
        /// Retorna um registro do banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Pessoa), StatusCodes.Status200OK)]
        public ActionResult Get(int Id)
        {
            var pessoa = _pessoaRepository.GetById(Id);

            if (pessoa == null)
            {
                NotFound();
            }

            return Ok(pessoa);
        }

        /// <summary>
        /// Método que adiciona uma pessoa ao banco.
        /// </summary>
        /// <param name="pessoa"></param>
        [HttpPost]
        public void Post([Bind("Id,Nome,Cidade,Estado")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _pessoaRepository.Add(pessoa);
            }
            else
            {
                BadRequest();
            }
        }

        /// <summary>
        /// Fazer alteração de uma pessoa (update)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pessoa"></param>
        [HttpPut("{Id}")]
        public void Put([Bind("Nome,Cidade,Estado,Id")] Pessoa pessoa)
        {
            _pessoaRepository.Edit(pessoa);

        }

        /// <summary>
        /// Deleta um registro do banco de dados.
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var pessoa = _pessoaRepository.GetById(id);

            if (pessoa == null)
            {
                NotFound();
            }
            _pessoaRepository.Delete(pessoa);
        }
    }
}
