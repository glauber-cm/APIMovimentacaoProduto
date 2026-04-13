using Microsoft.EntityFrameworkCore;
using MovimentacaoDeProduto.Data;
using MovimentacaoDeProduto.Entities;
using MovimentacaoDeProduto.Repositories.Interfaces;

namespace MovimentacaoDeProduto.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly AppDbContext _context;

        public MovimentacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Movimentacao mov)
        {
            await _context.Movimentacoes.AddAsync(mov);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Movimentacao>> GetByProduto(int produtoId)
        {
            return await _context.Movimentacoes.Where(m => m.ProdutoId == produtoId).ToListAsync();
        }
    }
}
