using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HopeHaven1.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? PatientId { get; set; }

        public string Name { get; set; }

        public string Age { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string  Amount { get; set; }

        public  Boolean IsPaymentDone { get; set; }

        [ForeignKey("Therapist")]
        public int? TherapistId { get; set; }

        public Therapists Therapist { get; set; }
    }
}