using System;
using System.ComponentModel.DataAnnotations;

namespace LoginSignup.Models
{
    public class TripModel
    {
        [Required]
        public string source { get; set; }

        [Required]
        public string destination { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public /*DateTime*/string date { get; set; }

        //[Required]
        public string created_by { get { return "ef16bcbc-cc81-4330-a837-5b7f02426c2d"; } }

        [Required]
        public bool carAvailable { get; set; }
        
        public string description { get; set; }
        
        public int vacant_seats { get; set; }
        
        public float estimated_cost { get; set; }
    }
}