using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monument_Scann.Models
{
    public class ComentAdnMonument
    {
        public Monument_Scann.Areas.Admin.Models.Monument Monumente { get; set; }
        public Monument_Scann.Areas.Admin.Models.MonumentComments MonumentComment { get; set; }
        public List<Monument_Scann.Areas.Admin.Models.MonumentComments> MonumentComments { get; set; }

        public int Id { get; set; }
        
        public string Comented { get; set; }

        public int MonumentId { get; set; }
        


    }
}
