using StoreSalesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreSalesAPI.Services.Saless
{
    public interface ISalesInterface
    {
        Task<IEnumerable<Sales>> ObterTodasVendas();
        Task<Sales> ObterVendaPorId(int id);
        Task<Sales> CriarVenda(Sales venda);
        Task<Sales> AtualizarVenda(int id, Sales vendaAtualizada);
        Task<bool> CancelarVenda(int id);
    }
}
