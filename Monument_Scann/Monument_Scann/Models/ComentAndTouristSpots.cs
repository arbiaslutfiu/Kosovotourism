using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monument_Scann.Models
{
    public class ComentAndTouristSpots
    {
        public Monument_Scann.Areas.Admin.Models.touristspot TouristSpot { get; set; }
        public Monument_Scann.Areas.Admin.Models.TouristSpotComents TouristSpotComment { get; set; }
        public List<Monument_Scann.Areas.Admin.Models.TouristSpotComents> TouristSpotComments { get; set; }

        public int Id { get; set; }

        public string Comented { get; set; }

        public int touristspotId { get; set; }


    }
}
