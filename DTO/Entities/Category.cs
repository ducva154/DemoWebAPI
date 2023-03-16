using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DTO.Entity
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
