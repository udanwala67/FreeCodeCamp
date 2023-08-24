using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FreeCodeCamp.Models
{
    public class Catagory
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required(ErrorMessage = "The Display Order Feild Is Required")]
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order Must Be Between 1 To 100")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
