using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ehpad.ORM
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Prénom")]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nom")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "Sexe")]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date de naissance")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Type")]
        public int PersonTypeId { get; set; }

        [Display(Name = "Type")]
        public PersonneType PersonType { get; set; }

        public List<Vacciner> Vaccinates { get; } = new List<Vacciner>();
    }
}
