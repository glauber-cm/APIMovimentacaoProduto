using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovimentacaoDeProduto.DTOs;
using MovimentacaoDeProduto.Entities;
using MovimentacaoDeProduto.Models;
using MovimentacaoDeProduto.Services.Interface;

namespace MovimentacaoDeProduto.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        // GET: api/produtos
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtos = await _service.GetAll();
            return Ok(new ApiResponse<List<Produto>>
            {
                Sucesso = true,
                Mensagem = "Lista de Produtos",
                Dados = produtos

            });
        }


        // GET: api/produtos/1
        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _service.GetById(id);

            if (produto == null)
                return NotFound(new ApiResponse<string>
                {
                    Sucesso = false,
                    Mensagem = "Produto não encontrado",
                    Dados = null
                });

            return Ok(new ApiResponse<Produto>
            {
                Sucesso = true,
                Mensagem = "Produto listado",
                Dados = produto

            });
        }



        //POST: api/produtos
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoDTO dto)
        {
            var produto = await _service.Create(dto);
            return Ok(new ApiResponse<Produto>
            {
                Sucesso = true,
                Mensagem = "Produto criado com sucesso",
                Dados = produto

            });
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProdutoDTO dto)
        {
            var produto = await _service.Update(id, dto);

            if (produto == null)
                return NotFound(new ApiResponse<string>
                {
                    Sucesso = false,
                    Mensagem = "Produto não encontrado",
                    Dados = null
                });

            return Ok(new ApiResponse<Produto>
            {
                Sucesso = true,
                Mensagem = "Produto editado com sucesso",
                Dados = produto

            });
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _service.Delete(id);

            if(!removido)
                return NotFound(new ApiResponse<string>
                {
                    Sucesso = false,
                    Mensagem = "Produto não encontrado",
                    Dados = null
                });

            return NoContent();
        }
    }
}
