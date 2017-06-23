using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace xBountyHunter.Models
{
    public class mFugitivos
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Capturado { get; set; }
        public string Foto { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
    }
}
