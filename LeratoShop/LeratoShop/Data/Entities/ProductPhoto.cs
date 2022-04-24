using System.ComponentModel.DataAnnotations;

namespace LeratoShop.Data.Entities
{
    public class ProductPhoto
    {
        public int Id { get; set; }

        [Display(Name = "Descripcion")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public string Description { get; set; }

    }
}
