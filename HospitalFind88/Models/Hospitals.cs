using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalFind88.Models
{
    public class Hospitals
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter hospital name")]
        [Display(Name = "Hospital Name")]
        public string Name { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string Phone { get; set; }

        public string Emergency { get; set; }

        public string Website { get; set; }

        public string Street { get; set; }

        public int Postcode { get; set; }
    }
}