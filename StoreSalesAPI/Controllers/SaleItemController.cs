using Microsoft.AspNetCore.Mvc;
using StoreSalesAPI.Models;
using StoreSalesAPI.Services.SaleItems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreSalesAPI.Controllers
{
    [Route("api/saleitems")]
    [ApiController]
    public class SaleItemController : ControllerBase
    {
        private readonly ISaleItemInterface _saleItemService;

        public SaleItemController(ISaleItemInterface saleItemService)
        {
            _saleItemService = saleItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleItem>>> ObterTodosItens()
        {
            var itens = await _saleItemService.ObterTodosItens();
            return Ok(itens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleItem>> ObterItemPorId(int id)
        {
            var item = await _saleItemService.ObterItemPorId(id);
            if (item == null) return NotFound("Item não encontrado.");

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<SaleItem>> CriarItem([FromBody] SaleItem item)
        {
            if (item == null) return BadRequest("Dados inválidos.");

            var novoItem = await _saleItemService.CriarItem(item);
            return CreatedAtAction(nameof(ObterItemPorId), new { id = novoItem.Id }, novoItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SaleItem>> AtualizarItem(int id, [FromBody] SaleItem itemAtualizado)
        {
            if (itemAtualizado == null) return BadRequest("Dados inválidos.");

            var item = await _saleItemService.AtualizarItem(id, itemAtualizado);
            if (item == null) return NotFound("Item não encontrado.");

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirItem(int id)
        {
            var sucesso = await _saleItemService.ExcluirItem(id);
            if (!sucesso) return NotFound("Item não encontrado.");

            return NoContent();
        }
    }
}
