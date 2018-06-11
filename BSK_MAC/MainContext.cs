using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BSK_MAC
{
    public class MainContext : DbContext
    {
        public MainContext() : base()
        {

        }
        public DbSet<Garaz> Garazes { get; set; }
        public DbSet<Miasto> Miastas { get; set; }
        public DbSet<Uzytkownik> Uzytkowniks { get; set; }
    }
}
