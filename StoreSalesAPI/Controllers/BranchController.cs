using Microsoft.AspNetCore.Mvc;
using StoreSalesAPI.Models;
using StoreSalesAPI.Services.Branchess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreSalesAPI.Controllers
{
    [Route("api/branches")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchInterface _branchService;

        public BranchController(IBranchInterface branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> ObterTodasFiliais()
        {
            var filiais = await _branchService.ObterTodasFiliais();
            return Ok(filiais);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> ObterFilialPorId(int id)
        {
            var filial = await _branchService.ObterFilialPorId(id);
            if (filial == null) return NotFound("Filial não encontrada.");

            return Ok(filial);
        }

        [HttpPost]
        public async Task<ActionResult<Branch>> CriarFilial([FromBody] Branch filial)
        {
            if (filial == null) return BadRequest("Dados inválidos.");

            var novaFilial = await _branchService.CriarFilial(filial);
            return CreatedAtAction(nameof(ObterFilialPorId), new { id = novaFilial.Id }, novaFilial);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Branch>> AtualizarFilial(int id, [FromBody] Branch filialAtualizada)
        {
            if (filialAtualizada == null) return BadRequest("Dados inválidos.");

            var filial = await _branchService.AtualizarFilial(id, filialAtualizada);
            if (filial == null) return NotFound("Filial não encontrada.");

            return Ok(filial);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirFilial(int id)
        {
            var sucesso = await _branchService.ExcluirFilial(id);
            if (!sucesso) return NotFound("Filial não encontrada.");

            return NoContent();
        }
    }
}

