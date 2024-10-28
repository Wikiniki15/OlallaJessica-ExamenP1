using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;

namespace OlallaJessica_ExamenP1.Models
{
    public class Celular
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(2000, 2024)]
        public int Anio { get; set; }
        [Required]
        public float Precio { get; set; }
    }
}
