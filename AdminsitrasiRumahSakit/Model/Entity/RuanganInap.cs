using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminsitrasiRumahSakit.Model.Entity
{
    public class RuanganInap
    {
        public int id_ruangan { get; set; }
        public string nama { get; set; }
        public string tipe { get; set; }
        public int harga { get; set; }
    }
}
