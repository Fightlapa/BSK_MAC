using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK_MAC
{
    public class Baza
    {
        public int Classification { get; set; }

        public override string ToString()
        {
            return Classification.ToString();
        }
    }

}
