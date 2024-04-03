using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LynxWebRazor.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(39)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Name")]
        [Range(1, 100, ErrorMessage = "The field Display Name must be between 1-100.")]
        public int DisplayOrder { get; set; }
    }
}
