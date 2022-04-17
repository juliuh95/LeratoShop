using System.ComponentModel.DataAnnotations;

namespace LeratoShop.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Producto")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Cantidad del Producto")]
     //   [MaxLength(15, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Quantity { get; set; }


        [Display(Name = "Precio del Producto")]
    //    [MaxLength(15, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Price { get; set; }

        public int ProductTypeId { get; set; }
    
}
}
