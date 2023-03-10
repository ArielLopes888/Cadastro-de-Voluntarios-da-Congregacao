using Microsoft.EntityFrameworkCore;
using TabelaTPL.Models;

namespace TabelaTPL.Context
{
    public class TabelaContext : DbContext
    {
        public TabelaContext(DbContextOptions<TabelaContext> options) : base(options)
        {
        }

        public DbSet<Voluntarios> Voluntarios { get; set; }
        public DbSet<Disponibilidade> Disponibilidades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder Configuracao)
        {
            Configuracao.UseSqlServer(@"Data Source=ME003391\SQLEXPRESS;Initial Catalog=Voluntarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        }
    }
}