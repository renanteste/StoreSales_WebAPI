using System.ComponentModel.DataAnnotations;

namespace StoreSalesAPI.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }  // Nome da filial

        [Required]
        [StringLength(255)]
        public string Location { get; set; }  // Endereço ou localização da filial

        // Relacionamento com as vendas feitas nesta filial
        public List<Sales> Sales { get; set; } = new List<Sales>();
    }
}
