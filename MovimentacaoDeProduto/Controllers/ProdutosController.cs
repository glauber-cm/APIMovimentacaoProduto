using Microsoft.AspNetCore.Mvc;
using MovimentacaoDeProduto.DTOs;
using MovimentacaoDeProduto.Services.Interface;

namespace MovimentacaoDeProduto.Controllers
{
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtos = await _service.GetAll();
            return Ok(produtos);
        }

        // GET: api/produtos/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _service.GetById(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        //POST: api/produtos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoDTO dto)
        {
            var produto = await _service.Create(dto);
            return Ok(produto);
        }
    }
}
