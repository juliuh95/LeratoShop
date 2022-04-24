using System.ComponentModel.DataAnnotations;

namespace LeratoShop.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Fecha de compra")]
        public DateTime DatePurchase { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Quantity { get; set; }

        [Display(Name = "Total")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Total { get; set; }

        [Display(Name = "Ganancia")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Revenue { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<ReturnedProduct> ReturnedProducts { get; set; }


    }
}
