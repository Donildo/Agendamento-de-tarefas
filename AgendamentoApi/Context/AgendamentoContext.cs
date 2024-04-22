using AgendamentoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoApi.Context
{
    public class AgendamentoContext: DbContext
    {
        public AgendamentoContext(DbContextOptions<AgendamentoContext>options): base(options)
        {

        }
        public DbSet<Contato> Contatos{get; set;}
    }
}