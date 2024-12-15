
using BunifuAnimatorNS;
using System;
using System.Data;
using System.Windows.Forms;
using AdminsitrasiRumahSakit.Controller;
using AdminsitrasiRumahSakit.Model.Entity;
using Org.BouncyCastle.Crypto.Macs;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AdminsitrasiRumahSakit.Views.Data_Rekam_Medis
{
    public partial class frmEntryDataRekamMedis : Form
    {
        public delegate void CreateUpdateEventHandler(RekamMedis medis);

        public event CreateUpdateEventHandler OnCreate;
        public event CreateUpdateEventHandler OnUpdate;
        private RekamMedisController controller;
        private bool isNewData = true;
        private RekamMedis medis;

        public frmEntryDataRekamMedis(string title, RekamMedisController controller) : this()
        {
            this.Text = title;
            lblTittle.Text = title;
            this.controller = controller;
        }

        public frmEntryDataRekamMedis(string title, RekamMedis obj, RekamMedisController controller) : this()
        {
            this.Text = title;
            lblTittle.Text = title;
            this.controller = controller;

            isNewData = false;
            medis = obj;

            txtIDRM.Text = medis.id_rekam_medis;
            cmbNamaPasien.Text = medis.nama_pasien.ToString();
            cmbNamaDokter.Text = medis.nama_dokter.ToString();
            rtxDiagnosis.Text = medis.diagnosis;
            cmbTindakan.Text = medis.tindakan;
            cmbObat.Text = medis.nama_obat.ToString();
            cmbNamaRuangan.Text = medis.nama_ruangan.ToString();
            dtpMasuk.Text = medis.tgl_masuk.ToString();
            dtpKeluar.Text = medis.tgl_keluar;
        }
        public frmEntryDataRekamMedis()
        {
            InitializeComponent();
            IdOtomatis();
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

        public void IdOtomatis()
        {
            long hitung;
            string urutan;
            SQLiteConnection conn = GetOpenConnection();
            string sql = @"SELECT id_rekam_medis FROM data_rekam_medis ORDER BY id_rekam_medis DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();
            dtr.Read();

            if (dtr.HasRows)
            {
                hitung = Convert.ToInt64(dtr[0].ToString().Substring(dtr["id_rekam_medis"].ToString().Length - 3, 3)) + 1;
                string kodeMedis = "0000" + hitung;
                urutan = "RM" + "0" + kodeMedis.Substring(kodeMedis.Length - 3, 3);
            }
            else
            {
                urutan = "RM00001";
            }

            txtIDRM.Text = urutan;


            dtr.Dispose();
            cmd.Dispose();
            conn.Dispose();

            /*long hitung;
            string urutan;

            SQLiteConnection conn = GetOpenConnection();
            string sql = @"SELECT id_rekam_medis FROM data_rekam_medis ORDER BY id_rekam_medis DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader dtr = cmd.ExecuteReader();

            dtr.Read();
            if (dtr.HasRows)
            {
                hitung = Convert.ToInt64(dtr[0].ToString().Substring(dtr["id_rekam_medis"].ToString().Length - 3, 3)) + 1;
                string kodeMedis = "0000" + hitung;
                urutan = "RM" + kodeMedis.Substring(kodeMedis.Length - 3, 3);
            }
            else
            {
                urutan = "RM00001";
            }
            dtr.Close();
            txtIDRM.Text = urutan;
            conn.Close();*/
        }

        private void cmbNamaPasien_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (isNewData) medis = new RekamMedis();

            medis.id_rekam_medis = txtIDRM.Text;
            medis.nama_pasien = cmbNamaPasien.Text;
            medis.nama_dokter = cmbNamaDokter.Text;
            medis.diagnosis = rtxDiagnosis.Text;
            medis.tindakan = cmbTindakan.Text;
            medis.nama_obat = cmbObat.Text;
            medis.nama_ruangan = cmbNamaRuangan.Text;
            medis.tgl_masuk = dtpMasuk.Text;
            medis.tgl_keluar = dtpKeluar.Text;

            int result = 0;

            if (isNewData)
            {
                result = controller.Create(medis);

                if (result > 0)
                {
                    OnCreate(medis);

                    cmbNamaPasien.ResetText();
                    cmbNamaDokter.ResetText();
                    rtxDiagnosis.ResetText();
                    cmbTindakan.ResetText();
                    cmbObat.ResetText();
                    cmbNamaRuangan.ResetText();
                    dtpMasuk.ResetText();
                    dtpKeluar.ResetText();

                    cmbNamaPasien.Focus();
                    IdOtomatis();
                }
            }
            else
            {
                result = controller.Update(medis);

                if (result > 0)
                {
                    OnUpdate(medis);
                    this.Close();
                }
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEntryDataRekamMedis_Load(object sender, EventArgs e)
        {
            //cmb Pasien
            using (SQLiteConnection connPasien = GetOpenConnection())
            {
                string sqlPasien = @"select id_pasien, nama from pasien order by nama asc";
                using (SQLiteCommand cmdPasien = new SQLiteCommand(sqlPasien, connPasien))
                {
                    using (SQLiteDataReader dtrPasien = cmdPasien.ExecuteReader())
                    {
                        while (dtrPasien.Read())
                        {
                            cmbNamaPasien.Items.Add(dtrPasien["nama"].ToString());
                            cmbNamaPasien.ValueMember = dtrPasien["id_pasien"].ToString();
                        }
                    }
                }
            }

            //cmb dokter
            using (SQLiteConnection connDokter = GetOpenConnection())
            {
                string sqlDokter = @"select id_dokter, nama from dokter order by nama asc";
                using (SQLiteCommand cmdDokter = new SQLiteCommand(sqlDokter, connDokter))
                {
                    using (SQLiteDataReader dtrDokter = cmdDokter.ExecuteReader())
                    {
                        while (dtrDokter.Read())
                        {
                            cmbNamaDokter.ValueMember = dtrDokter["id_dokter"].ToString();
                            cmbNamaDokter.Items.Add(dtrDokter["nama"].ToString());
                        }
                    }
                }
            }

            //cmb Obat
            using (SQLiteConnection connObat = GetOpenConnection())
            {
                string sqlObat = @"select id_obat, nama_obat from obat order by nama_obat asc";
                using (SQLiteCommand cmdObat = new SQLiteCommand(sqlObat, connObat))
                {
                    using (SQLiteDataReader dtrObat = cmdObat.ExecuteReader())
                    {
                        while (dtrObat.Read())
                        {
                            cmbObat.ValueMember = dtrObat["id_obat"].ToString();
                            cmbObat.Items.Add(dtrObat["nama_obat"].ToString());
                        }
                    }
                }
            }

            //cmb Ruangan
            using (SQLiteConnection connRuangan = GetOpenConnection())
            {
                string sqlRuangan = @"select id_ruangan, nama from ruangan_inap order by nama asc";
                using (SQLiteCommand cmdRuangan = new SQLiteCommand(sqlRuangan, connRuangan))
                {
                    using (SQLiteDataReader dtrRuangan = cmdRuangan.ExecuteReader())
                    {
                        while (dtrRuangan.Read())
                        {
                            cmbNamaRuangan.ValueMember = dtrRuangan["id_ruangan"].ToString();
                            cmbNamaRuangan.Items.Add(dtrRuangan["nama"].ToString());
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dtpMasuk_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dtpKeluar_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
