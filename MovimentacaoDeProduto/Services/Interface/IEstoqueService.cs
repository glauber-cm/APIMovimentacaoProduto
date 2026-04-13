using MovimentacaoDeProduto.DTOs;

namespace MovimentacaoDeProduto.Services.Interface
{
    public interface IEstoqueService
    {
        Task<string> Movimentar(MovimentacaoDTO dto);
    }
}
