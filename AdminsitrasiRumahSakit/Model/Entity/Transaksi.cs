using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminsitrasiRumahSakit.Model.Entity
{
    public class Transaksi
    {
        public int id_transaksi { get; set; }
        public string id_rekam_medis { get; set; }
        public string nama_pasien { get; set; }
        public string nama_dokter { get; set; }
        public string diagnosis { get; set; }
        public string nama_obat { get; set; }
        public int harga_obat { get; set; }
        public int jumlah_obat { get; set; }
        public string nama_ruangan { get; set; }
        public int harga_ruangan { get; set; }
        public int lama_inap { get; set; }
        public string tanggal { get; set; }
        public string jatuh_tempo { get; set; }
        public string status { get; set; }
        public int total { get; set; }
    }
}
