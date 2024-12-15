using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminsitrasiRumahSakit.Model.Entity
{
    public class Obat
    {
        public int id_obat { get; set; }
        public string nama_obat { get; set; }
        public int stok { get; set; }
        public int harga { get; set; }

    }
}
