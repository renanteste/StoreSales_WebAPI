using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreSalesAPI.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string SaleNumber { get; set; }

        [Required]
        public DateTime SaleDate { get; set; } = DateTime.Now;

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }  // Relacionamento com Cliente

        [Required]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }  // Relacionamento com Filial

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        public bool IsCancelled { get; set; } = false;

        // Relacionamento com os Itens da Venda
        public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}
