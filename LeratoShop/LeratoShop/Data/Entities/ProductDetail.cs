using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LeratoShop.Data.Entities
{
    public class ProductDetail
    {
        public int Id { get; set; }

        [Display(Name = "Color Producto")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
      
        public string Color { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }

    }
}
