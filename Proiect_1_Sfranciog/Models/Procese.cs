using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_1_Sfranciog.Models
{
    public class Procese
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nume { get; set; }
        [Required]
        public string? Locatie { get; set; }
        [Required]
        public DateTime? Data_Ora { get; set; }
        public string? Rezultat { get; set; }
        [ForeignKey("Dosare")]
        [Required]
        public int Id_dosar { get; set; }
    }
}
