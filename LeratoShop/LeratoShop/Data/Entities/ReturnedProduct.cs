using System.ComponentModel.DataAnnotations;

namespace LeratoShop.Data.Entities
{
    public class ReturnedProduct
    {
        public int Id { get; set; }

        [Display(Name = "Fecha de devolucion")]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Daño")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FaultDescription { get; set; }

        [Display(Name = "Garantia")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Warranty { get; set; }
    }
}
