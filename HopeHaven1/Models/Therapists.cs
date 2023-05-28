using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HopeHaven1.Models
{
    public class Therapists
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Degree { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string Password { get; set; }

        public string profilePhoto { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}