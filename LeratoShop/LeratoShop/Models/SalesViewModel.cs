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

        public string Id { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Display(Name = "Nombre Cliente")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Address { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PhoneNumber { get; set; }


        public IEnumerable<SelectListItem> ProductDetails { get; set; }
    }
}
