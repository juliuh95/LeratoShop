using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeratoShop.Models
{
    public class SalesViewModel
    {
        [Display(Name = "Tipo Producto")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un tipo producto.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int ProductTypesId { get; set; }

        public IEnumerable<SelectListItem> ProductTypes { get; set; }

        [Display(Name = "Producto")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un producto.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int ProductsId { get; set; }

        public IEnumerable<SelectListItem> Products { get; set; }

        [Display(Name = "Detalle del Producto")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un detalle del producto.")]
        public int ProductDetailsId { get; set; }

        public IEnumerable<SelectListItem> ProductDetails { get; set; }
    }
}
