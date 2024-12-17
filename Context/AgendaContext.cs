
using Microsoft.EntityFrameworkCore;
using GerenciamentoDeTarefas.entities;

namespace GerenciamentoDeTarefas.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
        }
        public DbSet<Tarefas> Tarefas { get; set; }
    }
}
