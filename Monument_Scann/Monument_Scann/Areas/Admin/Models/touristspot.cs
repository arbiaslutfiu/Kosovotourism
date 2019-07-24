using Monument_Scann.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monument_Scann.Areas.Admin.Models
{
    public class touristspot
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string History { get; set; }
        public int NrLike { get; set; }
        
       
        public LajkiTurS LajkiTS { get; set; }

        public City Citys { get; set; }
        public string Image { get; set; }
        public TouristSpotComents Coments { get; set; }
    }
}
