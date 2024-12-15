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

namespace AdminsitrasiRumahSakit.Views.Data_Dokter
{
    public partial class frmEntryDokter : Form
    {
        public delegate void CreateUpdateEventHandler(Dokter dokter);

        public event CreateUpdateEventHandler OnCreate;
        public event CreateUpdateEventHandler OnUpdate;
        private DokterController controller;
        private bool isNewData = true;
        private Dokter dokter;

        public frmEntryDokter(string title, DokterController controller) : this()
        {
            this.Text = title;
            this.controller = controller;
            lblTitle.Text = title;
        }

        public frmEntryDokter(string title, Dokter obj, DokterController controller) : this()
        {
            this.Text = title;
            this.controller = controller;
            lblTitle.Text = title;

            isNewData = false;
            dokter = obj;

            txtNama.Text = dokter.nama;
            txtSpesialis.Text = dokter.spesialis;
            txtNoTelp.Text = dokter.no_telp.ToString();
            txtAlamat.Text = dokter.alamat;
        }


        public frmEntryDokter()
        {
            InitializeComponent();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (isNewData) dokter = new Dokter();

            dokter.nama = txtNama.Text;
            dokter.spesialis = txtSpesialis.Text;

            // Periksa apakah field no_telp diisi dengan nomor telepon yang valid
            if(txtNoTelp.Text.Trim().Length > 15)
{
                // Tampilkan pesan kesalahan
                MessageBox.Show("No. telepon tidak boleh lebih dari 15 karakter !");
                return;
            }

            dokter.no_telp = txtNoTelp.Text;
            dokter.alamat = txtAlamat.Text.Trim();

            int result = 0;

            if (isNewData)
            {
                result = controller.Create(dokter);

                if (result > 0)
                {
                    OnCreate(dokter);

                    txtNama.Clear();
                    txtSpesialis.Clear();
                    txtNoTelp.Clear();
                    txtAlamat.Clear();

                    txtNama.Focus();
                }
            }
            else
            {
                result = controller.Update(dokter);

                if (result > 0)
                {
                    OnUpdate(dokter);
                    this.Close();
                }
            }

        }


        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSpesialis_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoTelp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAlamat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
