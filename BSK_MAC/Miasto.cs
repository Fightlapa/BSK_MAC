using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK_MAC
{
    public class Miasto:Baza
    {
        public Miasto()
        {

        }
        [Key]
        public string Nazwa { get; set; }
        public string Wojewodztwo { get; set; }
        public ICollection<Garaz> Garaze { get; set; }

        public override string ToString()
        {
            return (Nazwa + ", " + Wojewodztwo + ", " + base.ToString()); 
        }
    }
}
