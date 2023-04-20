using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_1_Sfranciog.Models
{
    public class Dosare
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nume { get; set; }
        [Required]
        public string? Tip { get; set; }
        public string? Informatii { get; set; }
        public string? Concluzii { get; set; }
        [Required]
        public float? Onorariu { get; set; }
        [ForeignKey("Clienti")]
        [Required]        
        public int Id_Client { get; set; }
    }
}
