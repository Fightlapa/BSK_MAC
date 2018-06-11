using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK_MAC
{
    class Dealer:Baza
    {
        [Key]
        public string Nazwa { get; set; }
        public string NazwaMiasta { get; set; }
    }
}
