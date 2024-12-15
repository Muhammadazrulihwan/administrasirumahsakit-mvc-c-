using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminsitrasiRumahSakit.Model.Entity
{
    public class RekamMedis
    {
        public string id_rekam_medis { get; set; }
        public string nama_pasien { get; set; }
        public string nama_dokter { get; set; }
        public string nama_ruangan { get; set; }
        public string nama_obat { get; set; }
        public string diagnosis { get; set; }
        public string tindakan { get; set; }
        public string tgl_masuk { get; set; }
        public string tgl_keluar { get; set; }
    }
}
