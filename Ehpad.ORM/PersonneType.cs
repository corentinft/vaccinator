using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ehpad.ORM
{
    public class PersonneType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Label { get; set; }

        public List<Person> Persons { get; } = new List<Person>();

    }
}
