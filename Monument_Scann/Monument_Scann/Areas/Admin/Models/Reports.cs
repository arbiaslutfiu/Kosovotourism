using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Monument_Scann.Areas.Admin.Models
{
    public class Reports
    {
        public int id { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        
        public string description { get; set; }
        [Required]
        public DateTime  kohadergimit { get; set; }
    }
}
