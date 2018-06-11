using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK_MAC
{
    public class Uzytkownik
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Clearance { get; set; }
        public override string ToString()
        {
            return ID + ", " + Imie + ", " + Nazwisko + ", " + Clearance;
        }
    }
}
