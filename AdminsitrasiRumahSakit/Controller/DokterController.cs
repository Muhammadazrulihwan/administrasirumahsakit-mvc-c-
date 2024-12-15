using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminsitrasiRumahSakit.Model.Context;
using AdminsitrasiRumahSakit.Model.Entity;
using AdminsitrasiRumahSakit.Model.Repository;

namespace AdminsitrasiRumahSakit.Controller
{
    public class DokterController
    {
        private DokterRepository _repository;

        public int Create(Dokter dokter)
        {
            int result = 0;

            if (string.IsNullOrEmpty(dokter.nama) || string.IsNullOrEmpty(dokter.spesialis) || string.IsNullOrEmpty(dokter.no_telp) || string.IsNullOrEmpty(dokter.alamat))
            {
                MessageBox.Show("Semua field harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new DokterRepository(context);
                result = _repository.Create(dokter);
            }

            if (result > 0)
            {
                MessageBox.Show("Data dokter berhasil disimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data dokter gagal disimpan !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        public int Update(Dokter dokter)
        {
            int result = 0;

            if (dokter.id_dokter == 0 || string.IsNullOrEmpty(dokter.nama) || string.IsNullOrEmpty(dokter.spesialis) || string.IsNullOrEmpty(dokter.no_telp) || string.IsNullOrEmpty(dokter.alamat))
            {
                MessageBox.Show("Semua field harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new DokterRepository(context);
                result = _repository.Update(dokter);
            }

            if (result > 0)
            {
                MessageBox.Show("Data dokter berhasil diupdate !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data dokter gagal diupdate !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        public int Delete(Dokter dokter)
        {
            int result = 0;
            if (dokter.id_dokter == 0)
            {
                MessageBox.Show("ID Dokter harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new DokterRepository(context);
                result = _repository.Delete(dokter);
            }

            if (result > 0)
            {
                MessageBox.Show("Data dokter berhasil dihapus !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data dokter gagal dihapus !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public List<Dokter> ReadByNama(string nama)
        {
            List<Dokter> list = new List<Dokter>();
            using (DbContext context = new DbContext())
            {
                _repository = new DokterRepository(context);
                list = _repository.ReadByNama(nama);
            }
            return list;
        }
        public List<Dokter> ReadAll()
        {
            List<Dokter> list = new List<Dokter>();
            using (DbContext context = new DbContext())
            {
                _repository = new DokterRepository(context);
                list = _repository.ReadAll();
            }
            return list;
        }
    }
}
