using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DTO.Entity
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}