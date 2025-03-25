using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreSalesAPI.Models
{
    public class SaleItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SaleId { get; set; }
        public Sales Sale { get; set; }  // Relacionamento com a Venda

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }  // Relacionamento com o Produto

        [Required]
        [Range(1, 20, ErrorMessage = "A quantidade deve ser entre 1 e 20.")]
        public int Quantity { get; set; }  // Restrição: máximo de 20 unidades por produto

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }  // Preço unitário do produto

        [Column(TypeName = "decimal(10,2)")]
        public decimal Discount { get; set; } = 0;  // Desconto aplicado

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }  // Preço total com desconto aplicado

        public bool IsCancelled { get; set; } = false;  // Indica se o item foi cancelado
    }
}
