using System.ComponentModel.DataAnnotations;

namespace StoreSalesAPI.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }  // Nome do cliente

        [Required]
        [EmailAddress]
        public string Email { get; set; }  // E-mail do cliente

        // Relacionamento com as vendas feitas por este cliente
        public List<Sales> Sales { get; set; } = new List<Sales>();
    }
}
