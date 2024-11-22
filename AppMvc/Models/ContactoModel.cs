using System.ComponentModel.DataAnnotations;

namespace AppMvc.Models
{
    public class ContactoModel
    {
        public int idContacto { get; set; }

        [Required]
        public string? nombre { get; set; }

        [Required]
        public string? telefono { get; set; }
        [Required]
        public string? correo { get; set; }

    }
}
