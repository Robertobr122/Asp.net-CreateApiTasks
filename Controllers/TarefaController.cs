using Microsoft.AspNetCore.Mvc;
using GerenciamentoDeTarefas.Context;
using GerenciamentoDeTarefas.entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeTarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly AgendaContext _context;

        public TarefaController(AgendaContext context)
        {
            _context = context;
        }

        // Método auxiliar para obter tarefa por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefas>> ObterTarefaPorId(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return tarefa;
        }

        // 1. Cadastrar tarefa
        [HttpPost("cadastrar")]
        public async Task<ActionResult<Tarefas>> CadastrarTarefa(Tarefas tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterTarefaPorId), new { id = tarefa.Id }, tarefa);
        }

        // 2. Atualizar tarefa
        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> AtualizarTarefa(int id, Tarefas tarefaAtualizada)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            // Atualiza as propriedades da tarefa
            tarefa.Titulo = tarefaAtualizada.Titulo;
            tarefa.Descricao = tarefaAtualizada.Descricao;
            tarefa.Data = tarefaAtualizada.Data;
            tarefa.Status = tarefaAtualizada.Status;
            tarefa.Ativo = tarefaAtualizada.Ativo;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // 3. Deletar tarefa
        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeletarTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // 4. Obter todas as tarefas
        [HttpGet("obterTodas")]
        public async Task<ActionResult<IEnumerable<Tarefas>>> ObterTodasTarefas()
        {
            return await _context.Tarefas.ToListAsync();
        }

        // 5. Obter tarefa por Título
        [HttpGet("obterPorTitulo/{titulo}")]
        public async Task<ActionResult<IEnumerable<Tarefas>>> ObterTarefasPorTitulo(string titulo)
        {
            var tarefas = await _context.Tarefas
                .Where(t => t.Titulo.Contains(titulo))
                .ToListAsync();

            if (tarefas == null || !tarefas.Any())
            {
                return NotFound();
            }

            return tarefas;
        }

        // 6. Obter tarefa por Data
        [HttpGet("obterPorData/{data}")]
        public async Task<ActionResult<IEnumerable<Tarefas>>> ObterTarefasPorData(DateTime data)
        {
            var tarefas = await _context.Tarefas
                .Where(t => t.Data.Date == data.Date) // Compara apenas a data, sem considerar a hora
                .ToListAsync();

            if (tarefas == null || !tarefas.Any())
            {
                return NotFound();
            }

            return tarefas;
        }

        // 7. Obter tarefa por Status
        [HttpGet("obterPorStatus/{status}")]
        public async Task<ActionResult<IEnumerable<Tarefas>>> ObterTarefasPorStatus(string status)
        {
            var tarefas = await _context.Tarefas
                .Where(t => t.Status.ToString().Contains(status))
                .ToListAsync();

            if (tarefas == null || !tarefas.Any())
            {
                return NotFound();
            }

            return tarefas;
        }

        // 8. Criar nova tarefa
        [HttpPost("novaTarefa")]
        public async Task<ActionResult<Tarefas>> CriarTarefa(Tarefas tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterTarefaPorId), new { id = tarefa.Id }, tarefa);
        }
    }
}

