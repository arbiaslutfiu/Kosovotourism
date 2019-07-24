using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Monument_Scann.Areas.Admin.Models
{
    public class MonumentComments
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Comented { get; set; }
        [Required]
        public DateTime kohadergimit { get; set; }

        public int MonumentId { get; set; }
        public Monument Monumenti { get; set; }
    }
}
