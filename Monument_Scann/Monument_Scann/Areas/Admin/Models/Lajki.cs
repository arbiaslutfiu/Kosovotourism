using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monument_Scann.Areas.Admin.Models
{
    public class Lajki
    {
        public int Id { get; set; }
        public bool Liked { get; set; }
        public string UserId { get; set; }

        public int MonumentsId { get; set; }
        public Monument Monuments { get; set; }
    }
}
