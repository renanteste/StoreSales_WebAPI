using Microsoft.EntityFrameworkCore;
using StoreSalesAPI.Data;
using StoreSalesAPI.Models;
using StoreSalesAPI.Services.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreSalesAPI.Services.Customers
{
    public class CustomerService : ICustomerInterface
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> ObterTodosClientes()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> ObterClientePorId(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> CriarCliente(Customer cliente)
        {
            _context.Customers.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Customer> AtualizarCliente(int id, Customer clienteAtualizado)
        {
            var cliente = await _context.Customers.FindAsync(id);
            if (cliente == null) return null;

            cliente.Name = clienteAtualizado.Name;
            cliente.Email = clienteAtualizado.Email;

            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> ExcluirCliente(int id)
        {
            var cliente = await _context.Customers.FindAsync(id);
            if (cliente == null) return false;

            _context.Customers.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
