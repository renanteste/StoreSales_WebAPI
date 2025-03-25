using Microsoft.EntityFrameworkCore;
using StoreSalesAPI.Data;
using StoreSalesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreSalesAPI.Services.SaleItems
{
    public class SaleItemService : ISaleItemInterface
    {
        private readonly AppDbContext _context;

        public SaleItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SaleItem>> ObterTodosItens()
        {
            return await _context.SaleItems
                .Include(i => i.Product) // Carrega os detalhes do produto
                .Include(i => i.Sale)    // Carrega os detalhes da venda
                .ToListAsync();
        }

        public async Task<SaleItem> ObterItemPorId(int id)
        {
            return await _context.SaleItems
                .Include(i => i.Product)
                .Include(i => i.Sale)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<SaleItem> CriarItem(SaleItem item)
        {
            _context.SaleItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<SaleItem> AtualizarItem(int id, SaleItem itemAtualizado)
        {
            var item = await _context.SaleItems.FindAsync(id);
            if (item == null) return null;

            item.ProductId = itemAtualizado.ProductId;
            item.Quantity = itemAtualizado.Quantity;
            item.UnitPrice = itemAtualizado.UnitPrice;
            item.Discount = itemAtualizado.Discount;
            item.TotalPrice = itemAtualizado.TotalPrice;
            item.IsCancelled = itemAtualizado.IsCancelled;

            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> ExcluirItem(int id)
        {
            var item = await _context.SaleItems.FindAsync(id);
            if (item == null) return false;

            _context.SaleItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
