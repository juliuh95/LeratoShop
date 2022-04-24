using System.ComponentModel.DataAnnotations;

namespace LeratoShop.Data.Entities
{
    public class DocumentType
    {
        public int Id { get; set; }
        [Display(Name = "Tipo documento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
