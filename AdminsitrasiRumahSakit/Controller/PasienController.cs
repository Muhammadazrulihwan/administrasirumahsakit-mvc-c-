using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminsitrasiRumahSakit.Model.Context;
using AdminsitrasiRumahSakit.Model.Entity;
using AdminsitrasiRumahSakit.Model.Repository;

namespace AdminsitrasiRumahSakit.Controller
{
    public class PasienController
    {
        private PasienRepository _repository;

        public int Create(Pasien pasien)
        {
            int result = 0;
            if (string.IsNullOrEmpty(pasien.nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(pasien.jenis_kelamin))
            {
                MessageBox.Show("Jenis kelamin harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(pasien.alamat))
            {
                MessageBox.Show("Alamat harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (pasien.tinggi_badan == 0)
            {
                MessageBox.Show("Tinggi badan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (pasien.berat_badan == 0)
            {
                MessageBox.Show("Berat badan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(pasien.tempat_lahir))
            {
                MessageBox.Show("Tempat lahir harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(pasien.tanggal_lahir))
            {
                MessageBox.Show("Tanggal lahir harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(pasien.no_telp))
            {
                MessageBox.Show("Nomor Telephone harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                _repository = new PasienRepository(context);
                result = _repository.Create(pasien);
            }
            if (result > 0)
            {
                MessageBox.Show("Data pasien berhasil disimpan !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data pasien gagal disimpan !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public int Update(Pasien pasien)
        {
            int result = 0;

            if (string.IsNullOrEmpty(pasien.nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(pasien.jenis_kelamin))
            {
                MessageBox.Show("Jenis kelamin harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(pasien.alamat))
            {
                MessageBox.Show("Alamat harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (pasien.tinggi_badan == 0)
            {
                MessageBox.Show("Tinggi badan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (pasien.berat_badan == 0)
            {
                MessageBox.Show("Berat badan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(pasien.tempat_lahir))
            {
                MessageBox.Show("Tempat lahir harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(pasien.tanggal_lahir))
            {
                MessageBox.Show("Tanggal lahir harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(pasien.no_telp))
            {
                MessageBox.Show("Nomor Telephone harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new PasienRepository(context);
                result = _repository.Update(pasien);
            }

            if (result > 0)
            {
                MessageBox.Show("Data pasien berhasil diupdate !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data pasien gagal diupdate !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        public int Delete(Pasien pasien)
        {
            int result = 0;
            if (pasien.id_pasien <= 0)
            {
                MessageBox.Show("ID pasien harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new PasienRepository(context);
                result = _repository.Delete(pasien);
            }

            if (result > 0)
            {
                MessageBox.Show("Data pasien berhasil dihapus !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data pasien gagal dihapus !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public List<Pasien> ReadAll()
        {
            List<Pasien> list = new List<Pasien>();
            using (DbContext context = new DbContext())
            {
                _repository = new PasienRepository(context);
                list = _repository.ReadAll();
            }
            return list;
        }

        public List<Pasien> ReadByNama(string nama)
        {
            List<Pasien> list = new List<Pasien>();
            using (DbContext context = new DbContext())
            {
                _repository = new PasienRepository(context);
                list = _repository.ReadByNama(nama);
            }
            return list;
        }
    }
}
