using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminsitrasiRumahSakit.Model.Entity
{
    public class Pasien
    {
        public int id_pasien { get; set; }
        public string nama { get; set; }
        public string jenis_kelamin { get; set; }
        public string alamat { get; set; }
        public int tinggi_badan { get; set; }
        public int berat_badan { get; set; }
        public string tempat_lahir { get; set; }
        public string tanggal_lahir { get; set; }
        public string no_telp { get; set; }
    }
}
