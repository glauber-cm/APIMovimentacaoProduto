using MovimentacaoDeProduto.Entities;

namespace MovimentacaoDeProduto.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> GetById(int id);
        Task Update(Produto produto);
    }
}
