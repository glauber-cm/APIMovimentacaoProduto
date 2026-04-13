using MovimentacaoDeProduto.Entities;

namespace MovimentacaoDeProduto.Repositories.Interfaces
{
    public interface IMovimentacaoRepository
    {
        Task Add(Movimentacao mov);
        Task<List<Movimentacao>> GetByProduto(int produtoId);
    }
}
