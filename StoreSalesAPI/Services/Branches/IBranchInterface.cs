using StoreSalesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreSalesAPI.Services.Branchess
{
    public interface IBranchInterface
    {
        Task<IEnumerable<Branch>> ObterTodasFiliais();
        Task<Branch> ObterFilialPorId(int id);
        Task<Branch> CriarFilial(Branch filial);
        Task<Branch> AtualizarFilial(int id, Branch filialAtualizada);
        Task<bool> ExcluirFilial(int id);
    }
}
