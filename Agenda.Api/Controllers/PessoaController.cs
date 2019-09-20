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
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
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
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Pessoa>> Get()
        {
            var pessoas = _pessoaRepository.Get();
            return pessoas;
            // new string[] { "value1", "value2" };
        }
        
        /// <summary>
        /// Retorna um registro do banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Pessoa> Get(int id)
        {
            var pessoa = _pessoaRepository.GetById(id);

            if (pessoa == null)
            {
                return NotFound();
            }
            return pessoa;

        }

        /// <summary>
        /// Método que adiciona uma pessoa ao banco.
        /// POST
        /// </summary>
        /// <param name="pessoa"></param>
        // POST api/values
        [HttpPost]
        public void Post([FromBody] Pessoa pessoa)
        {
            _pessoaRepository.Add(pessoa);
        }

        /// <summary>
        /// Fazer alteração de uma pessoa (update)
        /// PUT
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pessoa"></param>
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
               
            }
            var pes = _pessoaRepository.GetById(id);
            _pessoaRepository.Edit(pes);

        }

        /// <summary>
        /// Deleta um registro do banco de dados.
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var pessoa = _pessoaRepository.GetById(id);
            _pessoaRepository.Delete(pessoa);
        }
    }
}
