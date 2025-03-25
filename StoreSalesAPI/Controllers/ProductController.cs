using Microsoft.AspNetCore.Mvc;
using StoreSalesAPI.Models;
using StoreSalesAPI.Services.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreSalesAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductInterface _productService;

        public ProductController(IProductInterface productService)
        {
            _productService = productService;
        }

        // Obter todos os produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> ObterTodosProdutos()
        {
            var produtos = await _productService.ObterTodosProdutos();
            return Ok(produtos);
        }

        // Obter um produto pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> ObterProdutoPorId(int id)
        {
            var produto = await _productService.ObterProdutoPorId(id);
            if (produto == null) return NotFound("Produto não encontrado.");

            return Ok(produto);
        }

        // Criar um novo produto
        [HttpPost]
        public async Task<ActionResult<Product>> CriarProduto([FromBody] Product produto)
        {
            if (produto == null) return BadRequest("Dados inválidos.");

            var novoProduto = await _productService.CriarProduto(produto);
            return CreatedAtAction(nameof(ObterProdutoPorId), new { id = novoProduto.Id }, novoProduto);
        }

        // Atualizar um produto existente
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> AtualizarProduto(int id, [FromBody] Product produtoAtualizado)
        {
            if (produtoAtualizado == null) return BadRequest("Dados inválidos.");

            var produto = await _productService.AtualizarProduto(id, produtoAtualizado);
            if (produto == null) return NotFound("Produto não encontrado.");

            return Ok(produto);
        }

        // Excluir um produto
        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirProduto(int id)
        {
            var sucesso = await _productService.ExcluirProduto(id);
            if (!sucesso) return NotFound("Produto não encontrado.");

            return NoContent();
        }
    }
}
