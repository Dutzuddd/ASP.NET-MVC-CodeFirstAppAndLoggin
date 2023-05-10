using Microsoft.AspNetCore.Identity;

namespace Proiect_1_Sfranciog.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Event> Events { get; set; }
    }
}
