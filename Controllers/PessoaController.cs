using IDentyfica.Domain;
using IDentyfica.Model;
using Microsoft.AspNetCore.Mvc;

namespace IDentyfica.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaDomain _pessoaDomain;

        public PessoaController(PessoaDomain pessoaDomain)
        {
            _pessoaDomain = pessoaDomain;
        }

        [HttpGet]
        public IActionResult BuscarTodas()
        {
            var pessoas = _pessoaDomain.BuscarTodas();
            return Ok(pessoas);
        }

        [HttpPost]
        public IActionResult CadastrarPessoa([FromBody] Pessoa pessoa)
        {
            var pessoaCadastrada = _pessoaDomain.AdicionarPessoa(pessoa);
            if (pessoaCadastrada == null) 
            {
                return BadRequest("Erro ao cadastrar pessoa.");
            }
            return Ok(pessoaCadastrada);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPessoa(Guid id, [FromBody] Pessoa pessoa)
        {
            Pessoa pessoaAtualizada = _pessoaDomain.AtualizarPessoa(id, pessoa);

            if (pessoaAtualizada == null)
            {
                return BadRequest("Erro ao atulizar pessoa.");
            }

            return Ok(pessoaAtualizada);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPessoa(Guid id)
        {
            var retorno = _pessoaDomain.RemoverPessoa(id);

            return Ok(retorno);
        }
    }
}
