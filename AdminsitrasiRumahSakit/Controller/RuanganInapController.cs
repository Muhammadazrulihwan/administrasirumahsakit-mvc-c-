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
    public class RuanganInapController
    {
        private RuanganInapRepository _repository;

        public int Create(RuanganInap kamar)
        {
            int result = 0;
            if (string.IsNullOrEmpty(kamar.nama))
            {
                MessageBox.Show("Nama kamar harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(kamar.tipe))
            {
                MessageBox.Show("Tipe kamar kelamin harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (kamar.harga == 0)
            {
                MessageBox.Show("Harga kamar harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                _repository = new RuanganInapRepository(context);
                result = _repository.Create(kamar);
            }
            if (result > 0)
            {
                MessageBox.Show("Data ruangan inap berhasil disimpan !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data ruangan inap gagal disimpan !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public int Update(RuanganInap kamar)
        {
            int result = 0;

            if (string.IsNullOrEmpty(kamar.nama))
            {
                MessageBox.Show("Nama kamar harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(kamar.tipe))
            {
                MessageBox.Show("Tipe kamar kelamin harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (kamar.harga == 0)
            {
                MessageBox.Show("Harga kamar harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new RuanganInapRepository(context);
                result = _repository.Update(kamar);
            }

            if (result > 0)
            {
                MessageBox.Show("Data ruangan inap berhasil diupdate !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data ruangan inap gagal diupdate !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        public int Delete(RuanganInap kamar)
        {
            int result = 0;
            if (kamar.id_ruangan <= 0)
            {
                MessageBox.Show("ID ruangan inap harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new RuanganInapRepository(context);
                result = _repository.Delete(kamar);
            }

            if (result > 0)
            {
                MessageBox.Show("Data ruangan inap berhasil dihapus !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data ruangan inap gagal dihapus !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public List<RuanganInap> ReadAll()
        {
            List<RuanganInap> list = new List<RuanganInap>();
            using (DbContext context = new DbContext())
            {
                _repository = new RuanganInapRepository(context);
                list = _repository.ReadAll();
            }
            return list;
        }

        public List<RuanganInap> ReadByNama(string nama)
        {
            List<RuanganInap> list = new List<RuanganInap>();
            using (DbContext context = new DbContext())
            {
                _repository = new RuanganInapRepository(context);
                list = _repository.ReadByNama(nama);
            }
            return list;
        }
    }
}
