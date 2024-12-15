using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using AdminsitrasiRumahSakit.Model.Context;
using AdminsitrasiRumahSakit.Model.Entity;
using AdminsitrasiRumahSakit.Model.Repository;

namespace AdminsitrasiRumahSakit.Controller
{
    public class ObatController
    {
        private ObatRepository _repository;

        public int Create(Obat obat)
        {
            int result = 0;

            if (string.IsNullOrEmpty(obat.nama_obat) || obat.stok <= 0 || obat.harga <= 0)
            {
                MessageBox.Show("Semua field harus diisi dan nilai stok serta harga harus lebih dari 0 !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new ObatRepository(context);
                result = _repository.Create(obat);
            }

            if (result > 0)
            {
                MessageBox.Show("Data obat berhasil disimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data obat gagal disimpan !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        public int Update(Obat obat)
        {
            int result = 0;

            if (obat.id_obat == 0 || string.IsNullOrEmpty(obat.nama_obat) || obat.stok <= 0 || obat.harga <= 0)
            {
                MessageBox.Show("Semua field harus diisi dan nilai stok serta harga harus lebih dari 0 !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new ObatRepository(context);
                result = _repository.Update(obat);
            }

            if (result > 0)
            {
                MessageBox.Show("Data obat berhasil diupdate !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data obat gagal diupdate !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        public int Delete(Obat obat)
        {
            int result = 0;
            if (obat.id_obat == 0)
            {
                MessageBox.Show("ID Obat harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _repository = new ObatRepository(context);
                result = _repository.Delete(obat);
            }

            if (result > 0)
            {
                MessageBox.Show("Data obat berhasil dihapus !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data obat gagal dihapus !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public List<Obat> ReadAll()
        {
            List<Obat> list = new List<Obat>();
            using (DbContext context = new DbContext())
            {
                _repository = new ObatRepository(context);
                list = _repository.ReadAll();
            }
            return list;
        }
        public List<Obat> ReadByNama(string nama)
        {
            List<Obat> list = new List<Obat>();
            using (DbContext context = new DbContext())
            {
                _repository = new ObatRepository(context);
                list = _repository.ReadByNama(nama);
            }
            return list;
        }

    }
}
