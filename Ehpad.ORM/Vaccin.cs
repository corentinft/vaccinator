using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ehpad.ORM
{
    public class Vaccin
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Marque")]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Type")]
        public int VaccineTypeId { get; set; }

        [Display(Name = "Type")]
        public VaccinType VaccineType { get; set; }

        public List<Vacciner> Vaccinates { get; } = new List<Vacciner>();
    }
}
