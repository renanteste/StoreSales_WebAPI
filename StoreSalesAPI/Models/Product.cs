using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreSalesAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }  // Nome do produto

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }  // Preço unitário do produto

        // Relacionamento com itens de venda
        public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}
