using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using AdminsitrasiRumahSakit.Model.Context;
using AdminsitrasiRumahSakit.Model.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AdminsitrasiRumahSakit
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            jumlahPasien();
            jumlahDokter();
            jumlahRekamMedis();
            jumlahTransaksi();
        }

        private SQLiteConnection GetOpenConnection()
        {
            SQLiteConnection conn = null;
            try
            {
                string dbName = @"D:\amikom\Semester 3\Pemrograman Lanjut\uas\DBase\rumah-sakit-no-foreignkey.db";
                string connectionString = string.Format("Data Source ={0}; FailIfMissing = True", dbName);

                conn = new SQLiteConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            return conn;
        }

        public void jumlahPasien()
        {
            SQLiteConnection conn = GetOpenConnection();
            string sql = @"select count(id_pasien) from pasien";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            dtr.Read();

            txtPasien.Text = dtr[0].ToString();

            dtr.Dispose();
            cmd.Dispose();
            conn.Dispose();
        }

        public void jumlahDokter()
        {
            SQLiteConnection conn = GetOpenConnection();
            string sql = @"select count(id_dokter) from dokter";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            dtr.Read();

            txtDokter.Text = dtr[0].ToString();

            dtr.Dispose();
            cmd.Dispose();
            conn.Dispose();
        }

        public void jumlahTransaksi()
        {
            SQLiteConnection conn = GetOpenConnection();
            string sql = @"select count(id_transaksi) from transaksi";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            dtr.Read();

            txtTransaksi.Text = dtr[0].ToString();

            dtr.Dispose();
            cmd.Dispose();
            conn.Dispose();
        }

        public void jumlahRekamMedis()
        {
            SQLiteConnection conn = GetOpenConnection();
            string sql = @"select count(id_rekam_medis) from data_rekam_medis";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            dtr.Read();

            txtRekamMedis.Text = dtr[0].ToString();

            dtr.Dispose();
            cmd.Dispose();
            conn.Dispose();
        }
    }
}
