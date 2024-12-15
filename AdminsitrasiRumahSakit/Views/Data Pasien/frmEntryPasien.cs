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

namespace AdminsitrasiRumahSakit.Views.Data_Pasien
{
    public partial class frmEntryPasien : Form
    {
        public delegate void CreateUpdateEventHandler(Pasien pasien);

        public event CreateUpdateEventHandler OnCreate;
        public event CreateUpdateEventHandler OnUpdate;
        private PasienController controller;
        private bool isNewData = true;
        private Pasien pasien;

        public frmEntryPasien(string title, PasienController controller) : this()
        {
            this.Text = title;
            lblTittle.Text = title;
            this.controller = controller;
        }

        public frmEntryPasien(string title, Pasien obj, PasienController controller) : this()
        {
            this.Text = title;
            lblTittle.Text = title;
            this.controller = controller;

            isNewData = false;
            pasien = obj;

            txtNama.Text = pasien.nama;
            cmbJenisKelamin.Text = pasien.jenis_kelamin;
            txtAlamat.Text = pasien.alamat;
            txtTinggi.Text = pasien.tinggi_badan.ToString();
            txtBerat.Text = pasien.berat_badan.ToString();
            txtTempat.Text = pasien.tempat_lahir;
            dtmTanggal.Text = pasien.tanggal_lahir;
            txtNomor.Text = pasien.no_telp;
        }
        public frmEntryPasien()
        {
            InitializeComponent();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (isNewData) pasien = new Pasien();

            pasien.nama = txtNama.Text;
            pasien.jenis_kelamin = cmbJenisKelamin.Text;
            pasien.alamat = txtAlamat.Text;

            if (!int.TryParse(txtTinggi.Text, out int tinggi) || tinggi < 0)
            {
                MessageBox.Show("Tinggi badan harus diisi dengan angka non-negatif !");
                return;
            }

            if (!int.TryParse(txtBerat.Text, out int berat) || berat < 0)
            {
                MessageBox.Show("Berat badan harus diisi dengan angka non-negatif !");
                return;
            }

            pasien.tinggi_badan = tinggi;
            pasien.berat_badan = berat;

            pasien.tempat_lahir = txtTempat.Text;
            pasien.tanggal_lahir = dtmTanggal.Text;
            pasien.no_telp = txtNomor.Text;


            int result = 0;

            if (isNewData)
            {
                result = controller.Create(pasien);

                if (result > 0)
                {
                    OnCreate(pasien);

                    txtNama.Clear();
                    cmbJenisKelamin.ResetText();
                    txtAlamat.Clear();
                    txtTinggi.Clear();
                    txtBerat.Clear();
                    txtTempat.Clear();
                    txtNomor.Clear();

                    txtNama.Focus();
                }
            }
            else
            {
                result = controller.Update(pasien);

                if (result > 0)
                {
                    OnUpdate(pasien);
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
