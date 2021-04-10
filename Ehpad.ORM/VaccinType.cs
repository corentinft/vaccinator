using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ehpad.ORM
{
    public class VaccinType
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Libelle")]
        [MaxLength(50)]
        public string Label { get; set; }

        public List<Vaccin> Vaccines { get; } = new List<Vaccin>();
    }
}
