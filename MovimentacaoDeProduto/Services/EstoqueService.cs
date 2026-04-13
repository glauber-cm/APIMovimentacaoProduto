using MovimentacaoDeProduto.DTOs;
using MovimentacaoDeProduto.Entities;
using MovimentacaoDeProduto.Repositories.Interfaces;
using MovimentacaoDeProduto.Services.Interface;

namespace MovimentacaoDeProduto.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository  _produtoRepository;
        private readonly IMovimentacaoRepository  _movimentacaoRepository;

        public EstoqueService(IProdutoRepository produtoRepository, IMovimentacaoRepository movimentacaoRepository)
        {
            _produtoRepository = produtoRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task<string> Movimentar(MovimentacaoDTO dto)
        {
            var produto = await _produtoRepository.GetById(dto.ProdutoId);

            if (produto == null)
                return "Produto não encontrado";

            if (dto.Tipo == "Saida" && produto.QuantidadeEstoque < dto.Quantidade)
                return "Estoque insuficiente";

            if(dto.Tipo == "Entrada")
                produto.QuantidadeEstoque += dto.Quantidade;
            else
                produto.QuantidadeEstoque -= dto.Quantidade;

            await _produtoRepository.Update(produto);

            var mov = new Movimentacao
            {
                ProdutoId = dto.ProdutoId,
                Tipo = dto.Tipo,
                Quantidade = dto.Quantidade
            };

            await _movimentacaoRepository.Add(mov);

            return "Movimentação realizada com sucesso";
         }
    }
}