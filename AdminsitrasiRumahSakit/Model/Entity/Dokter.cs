using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminsitrasiRumahSakit.Model.Entity
{
    public class Dokter
    {
        public int id_dokter { get; set; }
        public string nama { get; set; }
        public string spesialis { get; set; }
        public string no_telp { get; set; }
        public string alamat { get; set; }
    }
}
