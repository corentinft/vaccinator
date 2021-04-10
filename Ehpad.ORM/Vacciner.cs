using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ehpad.ORM
{
    public class Vacciner
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date de rappel")]
        public DateTime RecallDate { get; set; }

        [Required]
        [Display(Name = "N° de lot")]
        public string BatchNumber { get; set; }

        [Required]
        [Display(Name = "Personne")]
        public int PersonId { get; set; }

        [Required]
        [Display(Name = "Vaccin")]
        public int VaccineId { get; set; }

        [Display(Name = "Personne")]
        public Person Person { get; set; }

        [Display(Name = "Vaccin")]
        public Vaccin Vaccine { get; set; }
    }
}
