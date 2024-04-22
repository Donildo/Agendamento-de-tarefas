using AgendamentoApi.Context;
using AgendamentoApi.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController: ControllerBase
    {
        private readonly AgendamentoContext _context;
        public TarefaController(AgendamentoContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato =  _context.Contatos.Find(id);
            if(contato ==null){
                return NotFound();
            }
            return Ok(contato);
        }
        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var contato = _context.Contatos.ToList();
            return Ok(contato);
        }
        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var contato = _context.Contatos.Where(x => x.Titulo.ToUpper().Contains(titulo.ToUpper())).ToList();

            return Ok(contato);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var contato = _context.Contatos.Where(x => x.Status == status);

            return Ok(contato);
        }
        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if (contato.Data ==DateTime.MinValue)
             return BadRequest(new{ Erro = "A data do contato não pode estar vazia"});

             _context.Contatos.Add(contato);
             _context.SaveChanges();

             return CreatedAtAction(nameof(ObterPorId), new{id = contato.Id}, contato);
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco ==null)
             return NotFound();

            if(contato.Data == DateTime.MinValue)
              return BadRequest(new{Erro ="A data do contato não pode ser ser vazia"});


            _context.Contatos.Add(contato);
            _context.SaveChanges();

            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco ==null)
              return NotFound();
            
            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}