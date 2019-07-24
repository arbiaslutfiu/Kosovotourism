using Monument_Scann.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monument_Scann.Areas.Admin.Models
{
    public class Monument
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string History { get; set; }
        public int NrLike { get; set; }
        public City Citys { get; set; }
        public string Image { get; set; }
        public MonumentComments Coments { get; set; }

        
        public Lajki LajkiM { get; set; }

        public IEnumerable<Monument_Scann.Areas.Admin.Models.Monument> Monuments { get; set; }
    }
}
