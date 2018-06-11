using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK_MAC
{
    public class Garaz:Baza
    {
        [Key]
        public int ID { get; set; }
        public int PojemnoscOsobowych { get; set; }
        public int PojemnoscCiezarowych { get; set; }
        public Miasto NazwaMiasta { get; set; }
    }
}
