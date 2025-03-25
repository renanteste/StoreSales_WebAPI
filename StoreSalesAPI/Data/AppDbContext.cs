using Microsoft.EntityFrameworkCore;
using StoreSalesAPI.Models;

namespace StoreSalesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Definição das tabelas no banco
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Branch> Branches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definição de chaves estrangeiras e regras de integridade referencial

            // Relacionamento entre Sales e Customer
            modelBuilder.Entity<Sales>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);

            // Relacionamento entre Sales e Branch
            modelBuilder.Entity<Sales>()
                .HasOne(s => s.Branch)
                .WithMany(b => b.Sales)
                .HasForeignKey(s => s.BranchId);

            // Relacionamento entre SaleItem e Sales
            modelBuilder.Entity<SaleItem>()
                .HasOne(si => si.Sale)
                .WithMany(s => s.SaleItems)
                .HasForeignKey(si => si.SaleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento entre SaleItem e Product
            modelBuilder.Entity<SaleItem>()
                .HasOne(si => si.Product)
                .WithMany(p => p.SaleItems)
                .HasForeignKey(si => si.ProductId);

            // Restrição de quantidade no SaleItem (regras de negócio)
            modelBuilder.Entity<SaleItem>()
                .Property(si => si.Quantity)
                .HasDefaultValue(1)
                .HasAnnotation("MinValue", 1)
                .HasAnnotation("MaxValue", 20);
        }
    }
}
