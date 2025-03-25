using Microsoft.AspNetCore.Mvc;
using StoreSalesAPI.Models;
using StoreSalesAPI.Services.Saless;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreSalesAPI.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesInterface _salesService;

        public SalesController(ISalesInterface salesService)
        {
            _salesService = salesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sales>>> ObterTodasVendas()
        {
            var vendas = await _salesService.ObterTodasVendas();
            return Ok(vendas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sales>> ObterVendaPorId(int id)
        {
            var venda = await _salesService.ObterVendaPorId(id);
            if (venda == null) return NotFound("Venda não encontrada.");

            return Ok(venda);
        }

        [HttpPost]
        public async Task<ActionResult<Sales>> CriarVenda([FromBody] Sales venda)
        {
            if (venda == null) return BadRequest("Dados inválidos.");

            var novaVenda = await _salesService.CriarVenda(venda);
            return CreatedAtAction(nameof(ObterVendaPorId), new { id = novaVenda.Id }, novaVenda);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Sales>> AtualizarVenda(int id, [FromBody] Sales vendaAtualizada)
        {
            if (vendaAtualizada == null) return BadRequest("Dados inválidos.");

            var venda = await _salesService.AtualizarVenda(id, vendaAtualizada);
            if (venda == null) return NotFound("Venda não encontrada.");

            return Ok(venda);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelarVenda(int id)
        {
            var sucesso = await _salesService.CancelarVenda(id);
            if (!sucesso) return NotFound("Venda não encontrada.");

            return NoContent();
        }
    }
}
