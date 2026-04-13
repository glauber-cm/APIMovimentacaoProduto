using Microsoft.EntityFrameworkCore;
using MovimentacaoDeProduto.Entities;

namespace MovimentacaoDeProduto.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
