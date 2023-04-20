using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_1_Sfranciog.Models;

namespace Proiect_1_Sfranciog
{
    public class AppDataContext : DbContext
    {
        public AppDataContext (DbContextOptions<AppDataContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_1_Sfranciog.Models.Clienti> Clienti { get; set; } = default!;

        public DbSet<Proiect_1_Sfranciog.Models.Dosare>? Dosare { get; set; }

        public DbSet<Proiect_1_Sfranciog.Models.Procese>? Procese { get; set; }

       
    }
}
