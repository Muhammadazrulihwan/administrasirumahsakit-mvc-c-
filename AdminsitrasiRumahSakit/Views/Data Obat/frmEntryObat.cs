using AdminsitrasiRumahSakit.Controller;
using AdminsitrasiRumahSakit.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminsitrasiRumahSakit.Views.Data_Obat
{
    public partial class frmEntryObat : Form
    {
        public delegate void CreateUpdateEventHandler(Obat obat);

        public event CreateUpdateEventHandler OnCreate;
        public event CreateUpdateEventHandler OnUpdate;
        private ObatController controller;
        private bool isNewData = true;
        private Obat obat;

        public frmEntryObat(string title, ObatController controller) : this()
        {
            this.Text = title;
            this.controller = controller;

        }

        public frmEntryObat(string title, Obat obj, ObatController controller) : this()
        {
            this.Text = title;
            this.controller = controller;

            isNewData = false;
            obat = obj;

            txtNamaObat.Text = obat.nama_obat;
            nupStok.Text = obat.stok.ToString();
            txtHarga.Text = obat.harga.ToString();
        }
        public frmEntryObat()
        {
            InitializeComponent();
        }

        private void btnSimpan_Click_1(object sender, EventArgs e)
        {
            if (isNewData) obat = new Obat();

            obat.nama_obat = txtNamaObat.Text;

            // Periksa apakah field stok dan harga diisi dengan angka yang valid
            if (!int.TryParse(nupStok.Text, out int stok) || stok < 0)
            {
                MessageBox.Show("Stok harus diisi dengan angka non-negatif !");
                return;
            }

            if (!int.TryParse(txtHarga.Text, out int harga) || harga < 0)
            {
                MessageBox.Show("Harga harus diisi dengan angka non-negatif !");
                return;
            }

            obat.stok = stok;
            obat.harga = harga;

            int result = 0;

            if (isNewData)
            {
                result = controller.Create(obat);

                if (result > 0)
                {
                    OnCreate(obat);

                    txtNamaObat.Clear();
                    nupStok.ResetText();
                    txtHarga.Clear();

                    txtNamaObat.Focus();
                }
            }
            else
            {
                result = controller.Update(obat);

                if (result > 0)
                {
                    OnUpdate(obat);
                    this.Close();
                }
            }
        }

        private void btnSelesai_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
