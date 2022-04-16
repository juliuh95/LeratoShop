using System.ComponentModel.DataAnnotations;

namespace LeratoShop.Data.Entities
{
    public class ProductType
    {
        public int Id { get; set; }
        [Display(Name = "Tipo Producto")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

        [Display(Name = "Cantidad de Productos")]
        public int ProductsNumber => Products == null ? 0 : Products.Count;
    }
}
