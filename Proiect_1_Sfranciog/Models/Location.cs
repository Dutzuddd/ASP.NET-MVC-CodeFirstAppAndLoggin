﻿using System.ComponentModel.DataAnnotations;

namespace Proiect_1_Sfranciog.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
