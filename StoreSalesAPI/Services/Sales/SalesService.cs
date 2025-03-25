using Microsoft.EntityFrameworkCore;
using StoreSalesAPI.Data;
using StoreSalesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreSalesAPI.Services.Saless
{
    public class SalesService : ISalesInterface
    {
        private readonly AppDbContext _context;

        public SalesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sales>> ObterTodasVendas()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<Sales> ObterVendaPorId(int id)
        {
            return await _context.Sales.FindAsync(id);
        }

        public async Task<Sales> CriarVenda(Sales venda)
        {
            _context.Sales.Add(venda);
            await _context.SaveChangesAsync();
            return venda;
        }

        public async Task<Sales> AtualizarVenda(int id, Sales vendaAtualizada)
        {
            var venda = await _context.Sales.FindAsync(id);
            if (venda == null) return null;

            venda.SaleNumber = vendaAtualizada.SaleNumber;
            venda.TotalAmount = vendaAtualizada.TotalAmount;
            venda.IsCancelled = vendaAtualizada.IsCancelled;

            await _context.SaveChangesAsync();
            return venda;
        }

        public async Task<bool> CancelarVenda(int id)
        {
            var venda = await _context.Sales.FindAsync(id);
            if (venda == null) return false;

            venda.IsCancelled = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
