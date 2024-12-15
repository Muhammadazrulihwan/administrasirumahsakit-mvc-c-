using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminsitrasiRumahSakit.Model.Context;
using AdminsitrasiRumahSakit.Model.Entity;
using AdminsitrasiRumahSakit.Model.Repository;
using Org.BouncyCastle.Crypto.Macs;

namespace AdminsitrasiRumahSakit.Controller
{
   
    public class RekamMedisController
    {
        private RekamMedisRepository _repository;

        public int Create(RekamMedis medis)
        {
            int result = 0;
            if (string.IsNullOrEmpty(medis.nama_pasien))
            {
                MessageBox.Show("Nama Pasien harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(medis.nama_dokter))
            {
                MessageBox.Show("Nama Dokter harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(medis.diagnosis))
            {
                MessageBox.Show("diagnosis harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(medis.tindakan))
            {
                MessageBox.Show("tindakan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(medis.tgl_masuk))
            {
                MessageBox.Show("Tanggal masuk harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(medis.tgl_keluar))
            {
                MessageBox.Show("Tanggal keluar harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                _repository = new RekamMedisRepository(context);
                result = _repository.Create(medis);
            }
            if (result > 0)
            {
                MessageBox.Show("Data Rekam Medis berhasil disimpan !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data rekam medis gagal disimpan !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public int Update(RekamMedis medis)
        {
            int result = 0;

            if (string.IsNullOrEmpty(medis.nama_pasien))
            {
                MessageBox.Show("Nama Pasien harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(medis.nama_dokter))
            {
                MessageBox.Show("Nama Dokter harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(medis.diagnosis))
            {
                MessageBox.Show("diagnosis harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(medis.tindakan))
            {
                MessageBox.Show("tindakan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(medis.tgl_masuk))
            {
                MessageBox.Show("Tanggal masuk harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(medis.tgl_keluar))
            {
                MessageBox.Show("Tanggal keluar harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new RekamMedisRepository(context);
                result = _repository.Update(medis);
            }

            if (result > 0)
            {
                MessageBox.Show("Data rekam medis berhasil diupdate !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data rekam medis gagal diupdate !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        public int Delete(RekamMedis medis)
        {
            int result = 0;
            if (string.IsNullOrEmpty(medis.id_rekam_medis))
            {
                MessageBox.Show("ID rekam medis harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new RekamMedisRepository(context);
                result = _repository.Delete(medis);
            }

            if (result > 0)
            {
                MessageBox.Show("Data rekam medis berhasil dihapus !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data rekam medis gagal dihapus !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public List<RekamMedis> ReadAll()
        {
            List<RekamMedis> list = new List<RekamMedis>();
            using (DbContext context = new DbContext())
            {
                _repository = new RekamMedisRepository(context);
                list = _repository.ReadAll();
            }
            return list;
        }

        public List<RekamMedis> ReadByNama(string nama)
        {
            List<RekamMedis> list = new List<RekamMedis>();
            using (DbContext context = new DbContext())
            {
                _repository = new RekamMedisRepository(context);
                list = _repository.ReadByNama(nama);
            }
            return list;
        }
    }
}
