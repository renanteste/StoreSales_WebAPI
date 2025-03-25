using Microsoft.EntityFrameworkCore;
using StoreSalesAPI.Data;
using StoreSalesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreSalesAPI.Services.Products // <-- Nome corrigido para evitar conflito
{
    public class ProductService : IProductInterface
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> ObterTodosProdutos()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> ObterProdutoPorId(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CriarProduto(Product produto)
        {
            _context.Products.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Product> AtualizarProduto(int id, Product produtoAtualizado)
        {
            var produto = await _context.Products.FindAsync(id);
            if (produto == null)
                return null;

            produto.Name = produtoAtualizado.Name;
            produto.Price = produtoAtualizado.Price;

            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> ExcluirProduto(int id)
        {
            var produto = await _context.Products.FindAsync(id);
            if (produto == null)
                return false;

            _context.Products.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
