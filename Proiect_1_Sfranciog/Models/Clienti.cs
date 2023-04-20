using System.ComponentModel.DataAnnotations;

namespace Proiect_1_Sfranciog.Models
{
    public class Clienti
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nume { get; set; }
        [Required]
        public string? Adresa { get; set; }
        [Required]
        public string? Telefon { get; set; }
    }
}
