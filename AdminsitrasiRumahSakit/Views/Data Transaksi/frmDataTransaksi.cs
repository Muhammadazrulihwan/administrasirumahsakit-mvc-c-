using AdminsitrasiRumahSakit.Controller;
using AdminsitrasiRumahSakit.Model.Entity;
using AdminsitrasiRumahSakit.Model.Context;
using AdminsitrasiRumahSakit.Views.Data_Rekam_Medis;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminsitrasiRumahSakit.Views.Data_Transaksi
{
    public partial class frmDataTransaksi : Form
    {
        private SQLiteConnection _conn;

        public frmDataTransaksi(DbContext context)
        {
            _conn = context.Conn;
        }

        private List<Transaksi> listOfTransaksi = new List<Transaksi>();
        private TransaksiController controller;
        public frmDataTransaksi()
        {
            InitializeComponent();
            controller = new TransaksiController();
            InisialisasiListView();
            LoadDataTransaksi();
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

        private void InisialisasiListView()
        {
            lvwTransaksi.View = View.Details;
            lvwTransaksi.FullRowSelect = true;
            lvwTransaksi.GridLines = true;

            lvwTransaksi.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwTransaksi.Columns.Add("Nama Pasien", 120, HorizontalAlignment.Center);
            lvwTransaksi.Columns.Add("Diagnosis", 110, HorizontalAlignment.Center); ;
            lvwTransaksi.Columns.Add("Nama Obat", 111, HorizontalAlignment.Center); ;
            lvwTransaksi.Columns.Add("Harga Obat", 115, HorizontalAlignment.Center); ;
            lvwTransaksi.Columns.Add("Jumlah Obat", 117, HorizontalAlignment.Center); ;
            lvwTransaksi.Columns.Add("Nama Ruangan", 124, HorizontalAlignment.Center); ;
            lvwTransaksi.Columns.Add("Harga Ruangan", 125, HorizontalAlignment.Center); ;
            lvwTransaksi.Columns.Add("Lama Menginap", 125, HorizontalAlignment.Center); ;
            lvwTransaksi.Columns.Add("Tanggal Transaksi", 180, HorizontalAlignment.Center); ;
            lvwTransaksi.Columns.Add("Jatuh Tempo", 115, HorizontalAlignment.Center); ;
            lvwTransaksi.Columns.Add("Total", 80, HorizontalAlignment.Center); ;
            lvwTransaksi.Columns.Add("Status", 80, HorizontalAlignment.Center); ;
        }

        private void LoadDataTransaksi()
        {
            lvwTransaksi.Items.Clear();
            listOfTransaksi = controller.ReadAll();


            foreach (var transaksi in listOfTransaksi)
            {
                var noUrut = lvwTransaksi.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());

                item.SubItems.Add(transaksi.nama_pasien);
                item.SubItems.Add(transaksi.diagnosis);
                item.SubItems.Add(transaksi.nama_obat);
                item.SubItems.Add(transaksi.harga_obat.ToString());
                item.SubItems.Add(transaksi.jumlah_obat.ToString());
                item.SubItems.Add(transaksi.nama_ruangan);
                item.SubItems.Add(transaksi.harga_ruangan.ToString());
                item.SubItems.Add(transaksi.lama_inap.ToString());
                item.SubItems.Add(transaksi.tanggal);
                item.SubItems.Add(transaksi.jatuh_tempo);
                item.SubItems.Add(transaksi.total.ToString());
                item.SubItems.Add(transaksi.status);

                lvwTransaksi.Items.Add(item);
            }
        }

        private void OnCreateEventHandler(Transaksi transaksi)
        {
            listOfTransaksi.Add(transaksi);

            int noUrut = lvwTransaksi.Items.Count + 1;

            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(transaksi.nama_pasien);
            item.SubItems.Add(transaksi.diagnosis);
            item.SubItems.Add(transaksi.nama_obat);
            item.SubItems.Add(transaksi.harga_obat.ToString());
            item.SubItems.Add(transaksi.jumlah_obat.ToString());
            item.SubItems.Add(transaksi.nama_ruangan);
            item.SubItems.Add(transaksi.harga_ruangan.ToString());
            item.SubItems.Add(transaksi.lama_inap.ToString());
            item.SubItems.Add(transaksi.tanggal);
            item.SubItems.Add(transaksi.jatuh_tempo);
            item.SubItems.Add(transaksi.total.ToString());
            item.SubItems.Add(transaksi.status);

            lvwTransaksi.Items.Add(item);
            LoadDataTransaksi();
        }

        private void OnUpdateEventHandler(Transaksi transaksi)
        {
            int index = lvwTransaksi.SelectedIndices[0];

            ListViewItem itemRow = lvwTransaksi.Items[index];
            itemRow.SubItems[1].Text = transaksi.nama_pasien;
            itemRow.SubItems[2].Text = transaksi.diagnosis;
            itemRow.SubItems[3].Text = transaksi.nama_obat;
            itemRow.SubItems[4].Text = transaksi.harga_obat.ToString();
            itemRow.SubItems[5].Text = transaksi.jumlah_obat.ToString();
            itemRow.SubItems[6].Text = transaksi.nama_ruangan;
            itemRow.SubItems[7].Text = transaksi.harga_ruangan.ToString();
            itemRow.SubItems[8].Text = transaksi.lama_inap.ToString();
            itemRow.SubItems[9].Text = transaksi.tanggal;
            itemRow.SubItems[10].Text = transaksi.jatuh_tempo;
            itemRow.SubItems[11].Text = transaksi.total.ToString();
            itemRow.SubItems[12].Text = transaksi.status;
        }


        private void btnTambah_Click(object sender, EventArgs e)
        {
            frmEntryDataTransaksi frmEntry = new frmEntryDataTransaksi("Tambah Data Transaksi", controller);

            frmEntry.OnCreate += OnCreateEventHandler;

            frmEntry.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwTransaksi.SelectedItems.Count > 0)
            {
                Transaksi transaksi = listOfTransaksi[lvwTransaksi.SelectedIndices[0]];

                frmEntryDataTransaksi frmEntry = new frmEntryDataTransaksi("Edit Data Transaksi", transaksi, controller);

                frmEntry.OnUpdate += OnUpdateEventHandler;

                frmEntry.ShowDialog();
            }
            else
            {
                MessageBox.Show("Data Transaksi belum dipilih", "Peringatan", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwTransaksi.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data transaksi ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    Transaksi transaksi = listOfTransaksi[lvwTransaksi.SelectedIndices[0]];

                    var result = controller.Delete(transaksi);
                    if (result > 0) LoadDataTransaksi();
                }
            }
            else
            {
                MessageBox.Show("Data Transaksi belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        int result;
        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (lvwTransaksi.SelectedItems.Count > 0)
            {
                Transaksi transaksi = listOfTransaksi[lvwTransaksi.SelectedIndices[0]];
                var result = 0;
                SQLiteConnection conn = GetOpenConnection();
                string sql = @"update transaksi set status = @status where id_transaksi = @id_transaksi";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                try
                {
                    // set parameter untuk nama, angkatan dan npm
                    cmd.Parameters.AddWithValue("@id_transaksi", transaksi.id_transaksi);
                    cmd.Parameters.AddWithValue("@status", "Lunas");
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                }
                if (result > 0)
                {
                    MessageBox.Show("Transaksi berhasil !", "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    LoadDataTransaksi();
                } else { 
                    MessageBox.Show("Transaksi gagal !!!", "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Data Transaksi belum dipilih", "Peringatan", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lvwTransaksi.Items.Clear();
            listOfTransaksi = controller.ReadByNama(txtTransaksi.Text);


            foreach (var transaksi in listOfTransaksi)
            {
                var noUrut = lvwTransaksi.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());

                item.SubItems.Add(transaksi.nama_pasien);
                item.SubItems.Add(transaksi.diagnosis);
                item.SubItems.Add(transaksi.nama_obat);
                item.SubItems.Add(transaksi.harga_obat.ToString());
                item.SubItems.Add(transaksi.jumlah_obat.ToString());
                item.SubItems.Add(transaksi.nama_ruangan);
                item.SubItems.Add(transaksi.harga_ruangan.ToString());
                item.SubItems.Add(transaksi.lama_inap.ToString());
                item.SubItems.Add(transaksi.tanggal);
                item.SubItems.Add(transaksi.jatuh_tempo);
                item.SubItems.Add(transaksi.total.ToString());
                item.SubItems.Add(transaksi.status);

                lvwTransaksi.Items.Add(item);
            }
        }
    }
}
