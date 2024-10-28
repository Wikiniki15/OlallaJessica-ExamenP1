using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlallaJessica_ExamenP1.Models
{
    public class Olalla
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [Range(1, 2)]
        public float Estatura {  get; set; }
        [Required]
        public bool Mascota {  get; set; }
        [Required]
        public DateTime Nacimiento { get; set; }
        [ForeignKey("CelularId")]
        public int CelularId { get; set; }
        public Celular? celular { get; set; }

    }
}
