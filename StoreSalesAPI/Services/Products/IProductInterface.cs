using StoreSalesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreSalesAPI.Services.Products // <-- Nome corrigido para evitar conflito
{
    public interface IProductInterface
    {
        Task<IEnumerable<Product>> ObterTodosProdutos();
        Task<Product> ObterProdutoPorId(int id);
        Task<Product> CriarProduto(Product produto);
        Task<Product> AtualizarProduto(int id, Product produtoAtualizado);
        Task<bool> ExcluirProduto(int id);
    }
}
