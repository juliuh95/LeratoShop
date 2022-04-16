using System.ComponentModel.DataAnnotations;

namespace LeratoShop.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Tipo Producto")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Cantidad del Producto")]
      //  [MaxLength(15, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Quantity { get; set; }


        [Display(Name = "Precio del Producto")]
       // [MaxLength(15, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Price { get; set; }

        public ProductType ProductType { get; set; }
    }
}
