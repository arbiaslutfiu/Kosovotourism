using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monument_Scann.Models
{
    public class IndexViewModel
    {
        public PaginatedList<Monument_Scann.Areas.Admin.Models.Monument> Monumentet { get; set; }
        public List<Monument_Scann.Areas.Admin.Models.Monument> Monumente { get; set; }
        public List<Monument_Scann.Areas.Admin.Models.touristspot> ToursitSpot { get; set; }
    }
}
