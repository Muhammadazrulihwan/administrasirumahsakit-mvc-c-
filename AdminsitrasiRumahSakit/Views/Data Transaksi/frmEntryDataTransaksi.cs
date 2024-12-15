using AdminsitrasiRumahSakit.Controller;
using AdminsitrasiRumahSakit.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace AdminsitrasiRumahSakit.Views.Data_Transaksi
{
    public partial class frmEntryDataTransaksi : Form
    {
        public delegate void CreateUpdateEventHandler(Transaksi transaksi);

        public event CreateUpdateEventHandler OnCreate;
        public event CreateUpdateEventHandler OnUpdate;
        private TransaksiController controller;
        private bool isNewData = true;
        private Transaksi transaksi;

        public frmEntryDataTransaksi(string title, TransaksiController controller) : this()
        {
            this.Text = title;
            lblTittle.Text = title;
            this.controller = controller;
        }

        public frmEntryDataTransaksi(string title, Transaksi obj, TransaksiController controller) : this()
        {
            this.Text = title;
            lblTittle.Text = title;
            this.controller = controller;
            cmbIDRM.Enabled = false;

            isNewData = false;
            transaksi = obj;

            cmbIDRM.Text = transaksi.id_rekam_medis;
            txtNamaPasien.Text = transaksi.nama_pasien;
            txtNamaDokter.Text = transaksi.nama_dokter;
            rtxDiagnosis.Text = transaksi.diagnosis;
            txtObat.Text = transaksi.nama_obat;
            txtHargaObat.Text = transaksi.harga_obat.ToString();
            txtJumlahObat.Text = transaksi.jumlah_obat.ToString();
            txtNamaRuangan.Text = transaksi.nama_ruangan;
            txtHargaRuangan.Text = transaksi.harga_ruangan.ToString();
            txtLamaInap.Text = transaksi.lama_inap.ToString();
            dtpTanggal.Text = transaksi.tanggal;
            dtpJatuhTempo.Text = transaksi.jatuh_tempo;
        }
        public frmEntryDataTransaksi()
        {
            InitializeComponent();
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

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (isNewData) transaksi = new Transaksi();

            transaksi.id_rekam_medis = cmbIDRM.Text;
            transaksi.jumlah_obat = Convert.ToInt32(txtJumlahObat.Text);
            transaksi.lama_inap = Convert.ToInt32(txtLamaInap.Text);
            transaksi.tanggal = dtpTanggal.Text;
            transaksi.jatuh_tempo = dtpJatuhTempo.Text;
            transaksi.status = "Belum Lunas";
            transaksi.total = (Convert.ToInt32(txtHargaObat.Text) * transaksi.jumlah_obat) + (Convert.ToInt32(txtHargaRuangan.Text) * transaksi.lama_inap);


            int result = 0;

            if (isNewData)
            {
                result = controller.Create(transaksi);

                if (result > 0)
                {
                    OnCreate(transaksi);

                    cmbIDRM.ResetText();
                    txtNamaPasien.Clear();
                    txtNamaDokter.Clear();
                    rtxDiagnosis.ResetText();
                    txtObat.Clear();
                    txtHargaObat.Clear();
                    txtJumlahObat.Clear();
                    txtNamaRuangan.Clear();
                    txtHargaRuangan.Clear();
                    txtLamaInap.Clear();
                    dtpTanggal.ResetText();
                    dtpJatuhTempo.ResetText();

                    cmbIDRM.Focus();
                }
            }
            else
            {
                result = controller.Update(transaksi);

                if (result > 0)
                {
                    OnUpdate(transaksi);
                    this.Close();
                }
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEntryDataTransaksi_Load(object sender, EventArgs e)
        {
            using (SQLiteConnection connRM = GetOpenConnection())
            {
                string sqlRM = @"select id_rekam_medis from data_rekam_medis order by id_rekam_medis asc";
                using (SQLiteCommand cmdRM = new SQLiteCommand(sqlRM, connRM))
                {
                    using (SQLiteDataReader dtrRM = cmdRM.ExecuteReader())
                    {
                        while (dtrRM.Read())
                        {
                            cmbIDRM.Items.Add(dtrRM["id_rekam_medis"]);
                        }
                    }
                }
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbIDRM.Text))
            {
                MessageBox.Show("ID rekam medis harus !!!", "Informasi", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                cmbIDRM.Focus();
                return;
            }
            SQLiteConnection conn = GetOpenConnection();
            string sql = @"SELECT data_rekam_medis.nama_pasien, data_rekam_medis.nama_dokter, data_rekam_medis.diagnosis, 
                            data_rekam_medis.nama_obat, obat.harga, data_rekam_medis.nama_ruangan, ruangan_inap.harga 
                            from data_rekam_medis 
                            INNER join obat on data_rekam_medis.nama_obat = obat.nama_obat
                            INNER join ruangan_inap on data_rekam_medis.nama_ruangan = ruangan_inap.nama 
                            WHERE id_rekam_medis = @id_RM";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id_RM", cmbIDRM.Text);
            SQLiteDataReader dtr = cmd.ExecuteReader(); 
            if (dtr.Read()) 
            {
                txtNamaPasien.Text = dtr[0].ToString();
                txtNamaDokter.Text = dtr[1].ToString();
                rtxDiagnosis.Text = dtr[2].ToString();
                txtObat.Text = dtr[3].ToString();
                txtHargaObat.Text = dtr[4].ToString();
                txtNamaRuangan.Text = dtr[5].ToString();
                txtHargaRuangan.Text = dtr[6].ToString();

            } else { 
                MessageBox.Show("Data rekam medis tidak ditemukan !", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            dtr.Dispose();
            cmd.Dispose();
            conn.Dispose();
        }
    }
}
