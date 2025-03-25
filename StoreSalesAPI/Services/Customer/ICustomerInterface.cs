using StoreSalesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreSalesAPI.Services.Customers
{
    public interface ICustomerInterface
    {
        Task<IEnumerable<Customer>> ObterTodosClientes();
        Task<Customer> ObterClientePorId(int id);
        Task<Customer> CriarCliente(Customer cliente);
        Task<Customer> AtualizarCliente(int id, Customer clienteAtualizado);
        Task<bool> ExcluirCliente(int id);
    }
}
