using AdminsitrasiRumahSakit.Model.Entity;
using AdminsitrasiRumahSakit.Model.Repository;
using AdminsitrasiRumahSakit.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminsitrasiRumahSakit.Controller
{
    public class TransaksiController
    {
        private TransaksiRepository _repository;

        public int Create(Transaksi transaksi)
        {
            int result = 0;
            if (string.IsNullOrEmpty(transaksi.id_rekam_medis))
            {
                MessageBox.Show("Id harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (transaksi.jumlah_obat <= 0)
            {
                MessageBox.Show("Jumlah obat harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (transaksi.lama_inap < 0)
            {
                MessageBox.Show("Lama inap harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(transaksi.jatuh_tempo))
            {
                MessageBox.Show("Jatuh Tempo harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                _repository = new TransaksiRepository(context);
                result = _repository.Create(transaksi);
            }
            if (result > 0)
            {
                MessageBox.Show("Data transaksi berhasil disimpan !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data transaksi gagal disimpan !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public int Update(Transaksi transaksi)
        {
            int result = 0;

            if (string.IsNullOrEmpty(transaksi.id_rekam_medis))
            {
                MessageBox.Show("Id harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (transaksi.jumlah_obat <= 0)
            {
                MessageBox.Show("Jumlah obat harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (transaksi.lama_inap < 0)
            {
                MessageBox.Show("Lama inap harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(transaksi.jatuh_tempo))
            {
                MessageBox.Show("Jatuh tempo harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new TransaksiRepository(context);
                result = _repository.Update(transaksi);
            }

            if (result > 0)
            {
                MessageBox.Show("Data transaksi berhasil diupdate !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data transaksi gagal diupdate !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        public int Delete(Transaksi transaksi)
        {
            int result = 0;
            if (transaksi.id_transaksi <= 0)
            {
                MessageBox.Show("ID transaksi harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new TransaksiRepository(context);
                result = _repository.Delete(transaksi);
            }

            if (result > 0)
            {
                MessageBox.Show("Data transaksi berhasil dihapus !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data transaksi gagal dihapus !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public List<Transaksi> ReadAll()
        {
            List<Transaksi> list = new List<Transaksi>();
            using (DbContext context = new DbContext())
            {
                _repository = new TransaksiRepository(context);
                list = _repository.ReadAll();
            }
            return list;
        }

        public List<Transaksi> ReadByNama(string nama)
        {
            List<Transaksi> list = new List<Transaksi>();
            using (DbContext context = new DbContext())
            {
                _repository = new TransaksiRepository(context);
                list = _repository.ReadByNama(nama);
            }
            return list;
        }
    }
}
