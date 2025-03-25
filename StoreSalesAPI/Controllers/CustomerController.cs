using Microsoft.AspNetCore.Mvc;
using StoreSalesAPI.Models;
using StoreSalesAPI.Services.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreSalesAPI.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerInterface _customerService;

        public CustomerController(ICustomerInterface customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> ObterTodosClientes()
        {
            var clientes = await _customerService.ObterTodosClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> ObterClientePorId(int id)
        {
            var cliente = await _customerService.ObterClientePorId(id);
            if (cliente == null) return NotFound("Cliente não encontrado.");

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CriarCliente([FromBody] Customer cliente)
        {
            if (cliente == null) return BadRequest("Dados inválidos.");

            var novoCliente = await _customerService.CriarCliente(cliente);
            return CreatedAtAction(nameof(ObterClientePorId), new { id = novoCliente.Id }, novoCliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> AtualizarCliente(int id, [FromBody] Customer clienteAtualizado)
        {
            if (clienteAtualizado == null) return BadRequest("Dados inválidos.");

            var cliente = await _customerService.AtualizarCliente(id, clienteAtualizado);
            if (cliente == null) return NotFound("Cliente não encontrado.");

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirCliente(int id)
        {
            var sucesso = await _customerService.ExcluirCliente(id);
            if (!sucesso) return NotFound("Cliente não encontrado.");

            return NoContent();
        }
    }
}
