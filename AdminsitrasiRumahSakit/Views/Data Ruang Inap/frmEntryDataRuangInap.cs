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

namespace AdminsitrasiRumahSakit.Views.Data_Ruang_Inap
{
    public partial class frmEntryDataRuangInap : Form
    {
        public delegate void CreateUpdateEventHandler(RuanganInap kamar);

        public event CreateUpdateEventHandler OnCreate;
        public event CreateUpdateEventHandler OnUpdate;
        private RuanganInapController controller;
        private bool isNewData = true;
        private RuanganInap kamar;

        public frmEntryDataRuangInap(string title, RuanganInapController controller) : this()
        {
            this.Text = title;
            lblTittle.Text = title;
            this.controller = controller;
        }

        public frmEntryDataRuangInap(string title, RuanganInap obj, RuanganInapController controller) : this()
        {
            this.Text = title;
            lblTittle.Text = title;
            this.controller = controller;

            isNewData = false;
            kamar = obj;

            txtNamaKamar.Text = kamar.nama;
            txtTipeKamar.Text = kamar.tipe;
            txtHarga.Text = kamar.harga.ToString();
        }

        public frmEntryDataRuangInap()
        {
            InitializeComponent();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (isNewData) kamar = new RuanganInap();

            kamar.nama = txtNamaKamar.Text;
            kamar.tipe = txtTipeKamar.Text;

            if (!int.TryParse(txtHarga.Text, out int harga) || harga < 0)
            {
                MessageBox.Show("Harga kamar harus diisi dengan angka non-negatif !");
                return;
            }

            kamar.harga = harga;

            int result = 0;

            if (isNewData)
            {
                result = controller.Create(kamar);

                if (result > 0)
                {
                    OnCreate(kamar);

                    txtNamaKamar.Clear();
                    txtTipeKamar.ResetText();
                    txtHarga.Clear();

                    txtNamaKamar.Focus();
                }
            }
            else
            {
                result = controller.Update(kamar);

                if (result > 0)
                {
                    OnUpdate(kamar);
                    this.Close();
                }
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
