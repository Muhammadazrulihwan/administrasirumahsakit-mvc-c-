using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AdminsitrasiRumahSakit.Views;
using AdminsitrasiRumahSakit.Views.Data_Pasien;
using AdminsitrasiRumahSakit.Views.Data_Obat;
using AdminsitrasiRumahSakit.Views.Data_Ruang_Inap;
using AdminsitrasiRumahSakit.Views.Data_Rekam_Medis;
using AdminsitrasiRumahSakit.Views.Data_Transaksi;

namespace AdminsitrasiRumahSakit
{
    public partial class Dashboard : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect, 
            int nWidthEllipse,
            int nHeightEllipse

        );
        public Dashboard()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(128, 128, 255);
            lblTitle.Text = "Dashboard";

            this.pnlFormLoader.Controls.Clear();
            frmDashboard frmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_Vrb);
            frmDashboard_Vrb.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(128, 128, 255);
            lblTitle.Text = "Dashboard";

            this.pnlFormLoader.Controls.Clear();

            frmDashboard frmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_Vrb);
            frmDashboard_Vrb.Show();
            btnDashboard.BackColor = Color.FromArgb(128, 128, 255);
            btnDataPasien.BackColor = Color.FromArgb(7, 37, 65);
            btnDataObat.BackColor = Color.FromArgb(7, 37, 65);
            btnDataRekamMedis.BackColor = Color.FromArgb(7, 37, 65);
            btnDataDokter.BackColor = Color.FromArgb(7, 37, 65);
            btnDataRuangInap.BackColor = Color.FromArgb(7, 37, 65);
            btnTransaksi.BackColor = Color.FromArgb(7, 37, 65);
        }

        private void btnDataPasien_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDataPasien.Height;
            pnlNav.Top = btnDataPasien.Top;
            btnDataPasien.BackColor = Color.FromArgb(128, 128, 255);
            lblTitle.Text = "Data Pasien";

            this.pnlFormLoader.Controls.Clear();

            frmDataPasien frmDataPasien_Vrb = new frmDataPasien() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDataPasien_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDataPasien_Vrb);
            frmDataPasien_Vrb.Show();

            btnDataPasien.BackColor = Color.FromArgb(128, 128, 255);
            btnDashboard.BackColor = Color.FromArgb(7, 37, 65);
            btnDataObat.BackColor = Color.FromArgb(7, 37, 65);
            btnDataRekamMedis.BackColor = Color.FromArgb(7, 37, 65);
            btnDataDokter.BackColor = Color.FromArgb(7, 37, 65);
            btnDataRuangInap.BackColor = Color.FromArgb(7, 37, 65);
            btnTransaksi.BackColor = Color.FromArgb(7, 37, 65);
        }

        private void btnDataDokter_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDataDokter.Height;
            pnlNav.Top = btnDataDokter.Top;
            btnDataDokter.BackColor = Color.FromArgb(128, 128, 255);
            lblTitle.Text = "Data Dokter";

            this.pnlFormLoader.Controls.Clear();

            frmDataDokter frmDatadokter_Vrb = new frmDataDokter() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDatadokter_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDatadokter_Vrb);
            frmDatadokter_Vrb.Show();
            btnDataDokter.BackColor = Color.FromArgb(128, 128, 255);
            btnDataPasien.BackColor = Color.FromArgb(7, 37, 65);
            btnDashboard.BackColor = Color.FromArgb(7, 37, 65);
            btnDataObat.BackColor = Color.FromArgb(7, 37, 65);
            btnDataRekamMedis.BackColor = Color.FromArgb(7, 37, 65);
            btnDataRuangInap.BackColor = Color.FromArgb(7, 37, 65);
            btnTransaksi.BackColor = Color.FromArgb(7, 37, 65);
        }

        private void btnDataObat_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDataObat.Height;
            pnlNav.Top = btnDataObat.Top;
            btnDataObat.BackColor = Color.FromArgb(128, 128, 255);
            lblTitle.Text = "Data Obat";

            this.pnlFormLoader.Controls.Clear();

            frmDataObat frmDataObat_Vrb = new frmDataObat() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDataObat_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDataObat_Vrb);
            frmDataObat_Vrb.Show();
            btnDataObat.BackColor = Color.FromArgb(128, 128, 255);
            btnDataDokter.BackColor = Color.FromArgb(7, 37, 65);
            btnDataPasien.BackColor = Color.FromArgb(7, 37, 65);
            btnDashboard.BackColor = Color.FromArgb(7, 37, 65);
            btnDataRekamMedis.BackColor = Color.FromArgb(7, 37, 65);
            btnDataRuangInap.BackColor = Color.FromArgb(7, 37, 65);
            btnTransaksi.BackColor = Color.FromArgb(7, 37, 65);
        }

        private void btnDataRuangInap_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDataRuangInap.Height;
            pnlNav.Top = btnDataRuangInap.Top;
            btnDataRuangInap.BackColor = Color.FromArgb(128, 128, 255);
            lblTitle.Text = "Data Ruangan Inap";

            this.pnlFormLoader.Controls.Clear();

            frmDataRuangInap frmDataRuangInap_Vrb = new frmDataRuangInap() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDataRuangInap_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDataRuangInap_Vrb);
            frmDataRuangInap_Vrb.Show();
            btnDataRuangInap.BackColor = Color.FromArgb(128, 128, 255);
            btnDataObat.BackColor = Color.FromArgb(7, 37, 65);
            btnDataDokter.BackColor = Color.FromArgb(7, 37, 65);
            btnDataPasien.BackColor = Color.FromArgb(7, 37, 65);
            btnDashboard.BackColor = Color.FromArgb(7, 37, 65);
            btnDataRekamMedis.BackColor = Color.FromArgb(7, 37, 65);
            btnTransaksi.BackColor = Color.FromArgb(7, 37, 65);
        }

        private void btnDataRekamMedis_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDataRekamMedis.Height;
            pnlNav.Top = btnDataRekamMedis.Top;
            btnDataRekamMedis.BackColor = Color.FromArgb(128, 128, 255);
            lblTitle.Text = "Data Rekam Medis";

            this.pnlFormLoader.Controls.Clear();

            frmDataRekamMedis frmDataRekamMedis_Vrb = new frmDataRekamMedis() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDataRekamMedis_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDataRekamMedis_Vrb);
            frmDataRekamMedis_Vrb.Show();
            btnDataRekamMedis.BackColor = Color.FromArgb(128, 128, 255);
            btnDataRuangInap.BackColor = Color.FromArgb(7, 37, 65);
            btnDataObat.BackColor = Color.FromArgb(7, 37, 65);
            btnDataDokter.BackColor = Color.FromArgb(7, 37, 65);
            btnDataPasien.BackColor = Color.FromArgb(7, 37, 65);
            btnDashboard.BackColor = Color.FromArgb(7, 37, 65);
            btnTransaksi.BackColor = Color.FromArgb(7, 37, 65);
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnTransaksi.Height;
            pnlNav.Top = btnTransaksi.Top;
            btnTransaksi.BackColor = Color.FromArgb(128, 128, 255);
            lblTitle.Text = "Data Transaksi";

            this.pnlFormLoader.Controls.Clear();

            frmDataTransaksi frmDataTransaksi_Vrb = new frmDataTransaksi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDataTransaksi_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDataTransaksi_Vrb);
            frmDataTransaksi_Vrb.Show();
            btnTransaksi.BackColor = Color.FromArgb(128, 128, 255);
            btnDataRekamMedis.BackColor = Color.FromArgb(7, 37, 65);
            btnDataRuangInap.BackColor = Color.FromArgb(7, 37, 65);
            btnDataObat.BackColor = Color.FromArgb(7, 37, 65);
            btnDataDokter.BackColor = Color.FromArgb(7, 37, 65);
            btnDataPasien.BackColor = Color.FromArgb(7, 37, 65);
            btnDashboard.BackColor = Color.FromArgb(7, 37, 65);
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(7, 37, 65);
        }

        private void btnDataPasien_Leave(object sender, EventArgs e)
        {
            btnDataPasien.BackColor = Color.FromArgb(7, 37, 65);
        }

        private void btnDataDokter_Leave(object sender, EventArgs e)
        {
            btnDataDokter.BackColor = Color.FromArgb(7, 37, 65);
        }

        private void btnDataObat_Leave(object sender, EventArgs e)
        {
            btnDataObat.BackColor = Color.FromArgb(7, 37, 65);
        }

        private void btnDataRuangInap_Leave(object sender, EventArgs e)
        {
            btnDataRuangInap.BackColor = Color.FromArgb(7, 37, 65);
        }

        private void btnDataRekamMedis_Leave(object sender, EventArgs e)
        {
            btnDataRekamMedis.BackColor = Color.FromArgb(7, 37, 65);
        }

        private void btnTransaksi_Leave(object sender, EventArgs e)
        {
            btnTransaksi.BackColor = Color.FromArgb(7, 37, 65);
        }

        private void pnlNav_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)



        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void pnlPatient_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void pcbMinimize_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Minimized;
            TopMost = false;
        }
    }
}
