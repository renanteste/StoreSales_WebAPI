using Microsoft.EntityFrameworkCore;
using StoreSalesAPI.Data;
using StoreSalesAPI.Models;
using StoreSalesAPI.Services.Branchess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreSalesAPI.Services.Branchess
{
    public class BranchService : IBranchInterface
    {
        private readonly AppDbContext _context;

        public BranchService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Branch>> ObterTodasFiliais()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<Branch> ObterFilialPorId(int id)
        {
            return await _context.Branches.FindAsync(id);
        }

        public async Task<Branch> CriarFilial(Branch filial)
        {
            _context.Branches.Add(filial);
            await _context.SaveChangesAsync();
            return filial;
        }

        public async Task<Branch> AtualizarFilial(int id, Branch filialAtualizada)
        {
            var filial = await _context.Branches.FindAsync(id);
            if (filial == null) return null;

            filial.Name = filialAtualizada.Name;
            filial.Location = filialAtualizada.Location;

            await _context.SaveChangesAsync();
            return filial;
        }

        public async Task<bool> ExcluirFilial(int id)
        {
            var filial = await _context.Branches.FindAsync(id);
            if (filial == null) return false;

            _context.Branches.Remove(filial);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
