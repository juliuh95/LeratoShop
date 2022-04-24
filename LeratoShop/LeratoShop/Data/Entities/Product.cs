using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LeratoShop.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Producto")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }


        [Display(Name = "Cantidad del Producto")]     
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Quantity { get; set; }


        [Display(Name = "Precio del Producto")]      
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Price { get; set; }

        [JsonIgnore]
        public ProductType ProductType { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }

        [Display(Name = "Detalle productos")]
        public int ProductDetailNumber => ProductDetails == null ? 0 : ProductDetails.Count;
    }
}
