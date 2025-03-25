using StoreSalesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreSalesAPI.Services.SaleItems
{
    public interface ISaleItemInterface
    {
        Task<IEnumerable<SaleItem>> ObterTodosItens();
        Task<SaleItem> ObterItemPorId(int id);
        Task<SaleItem> CriarItem(SaleItem item);
        Task<SaleItem> AtualizarItem(int id, SaleItem itemAtualizado);
        Task<bool> ExcluirItem(int id);
    }
}
