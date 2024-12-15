using AdminsitrasiRumahSakit.Controller;
using AdminsitrasiRumahSakit.Model.Entity;
using AdminsitrasiRumahSakit.Model.Context;
using AdminsitrasiRumahSakit.Views.Data_Ruang_Inap;
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

namespace AdminsitrasiRumahSakit.Views.Data_Rekam_Medis
{
    public partial class frmDataRekamMedis : Form
    {
        private List<RekamMedis> listOfRekamMedis = new List<RekamMedis>();
        private RekamMedisController controller;
        public frmDataRekamMedis()
        {
            InitializeComponent();
            controller = new RekamMedisController();
            InisialisasiListView();
            LoadDataRekamMedis();
        }

        private void InisialisasiListView()
        {
            lvwRekamMedis.View = View.Details;
            lvwRekamMedis.FullRowSelect = true;
            lvwRekamMedis.GridLines = true;

            lvwRekamMedis.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwRekamMedis.Columns.Add("ID Rekam Medis", 110, HorizontalAlignment.Center);
            lvwRekamMedis.Columns.Add("Nama Pasien", 120, HorizontalAlignment.Left);
            lvwRekamMedis.Columns.Add("Nama Dokter", 80, HorizontalAlignment.Center);
            lvwRekamMedis.Columns.Add("Diagnosis", 80, HorizontalAlignment.Left); ;
            lvwRekamMedis.Columns.Add("Tindakan", 80, HorizontalAlignment.Left); ;
            lvwRekamMedis.Columns.Add("Obat", 80, HorizontalAlignment.Left); ;
            lvwRekamMedis.Columns.Add("Ruangan Inap", 80, HorizontalAlignment.Left); ;
            lvwRekamMedis.Columns.Add("Tgl. Masuk", 80, HorizontalAlignment.Left); ;
            lvwRekamMedis.Columns.Add("Tgl. Keluar", 80, HorizontalAlignment.Left); ;
        }

        private void LoadDataRekamMedis()
        {
            lvwRekamMedis.Items.Clear();
            listOfRekamMedis = controller.ReadAll();


            foreach (var medis in listOfRekamMedis)
            {
                var noUrut = lvwRekamMedis.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());


                item.SubItems.Add(medis.id_rekam_medis.ToString());
                item.SubItems.Add(medis.nama_pasien);
                item.SubItems.Add(medis.nama_dokter.ToString());
                item.SubItems.Add(medis.diagnosis);
                item.SubItems.Add(medis.tindakan);
                item.SubItems.Add(medis.nama_obat.ToString());
                item.SubItems.Add(medis.nama_ruangan.ToString());
                item.SubItems.Add(medis.tgl_masuk);
                item.SubItems.Add(medis.tgl_keluar);


                lvwRekamMedis.Items.Add(item);


            }

        }

        private void OnCreateEventHandler(RekamMedis medis)
        {
            listOfRekamMedis.Add(medis);

            int noUrut = lvwRekamMedis.Items.Count + 1;

            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(medis.id_rekam_medis.ToString());
            item.SubItems.Add(medis.nama_pasien.ToString());
            item.SubItems.Add(medis.nama_dokter.ToString());
            item.SubItems.Add(medis.diagnosis);
            item.SubItems.Add(medis.tindakan);
            item.SubItems.Add(medis.nama_obat.ToString());
            item.SubItems.Add(medis.nama_ruangan.ToString());
            item.SubItems.Add(medis.tgl_masuk);
            item.SubItems.Add(medis.tgl_keluar);

            lvwRekamMedis.Items.Add(item);
            LoadDataRekamMedis();
        }

        private void OnUpdateEventHandler(RekamMedis medis)
        {
            int index = lvwRekamMedis.SelectedIndices[0];

            ListViewItem itemRow = lvwRekamMedis.Items[index];
            itemRow.SubItems[1].Text = medis.id_rekam_medis.ToString();
            itemRow.SubItems[2].Text = medis.nama_pasien.ToString();
            itemRow.SubItems[3].Text = medis.nama_dokter.ToString();
            itemRow.SubItems[4].Text = medis.diagnosis;
            itemRow.SubItems[5].Text = medis.tindakan;
            itemRow.SubItems[6].Text = medis.nama_obat.ToString();
            itemRow.SubItems[7].Text = medis.nama_ruangan.ToString();
            itemRow.SubItems[8].Text = medis.tgl_masuk;
            itemRow.SubItems[9].Text = medis.tgl_keluar;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            frmEntryDataRekamMedis frmEntry = new frmEntryDataRekamMedis("Tambah Data Rekam Medis", controller);

            frmEntry.OnCreate += OnCreateEventHandler;

            frmEntry.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwRekamMedis.SelectedItems.Count > 0)
            {
                RekamMedis medis = listOfRekamMedis[lvwRekamMedis.SelectedIndices[0]];

                frmEntryDataRekamMedis frmEntry = new frmEntryDataRekamMedis("Edit Data Rekam Medis", medis, controller);

                frmEntry.OnUpdate += OnUpdateEventHandler;

                frmEntry.ShowDialog();
            }
            else
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwRekamMedis.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data rekam medis ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    RekamMedis medis = listOfRekamMedis[lvwRekamMedis.SelectedIndices[0]];

                    var result = controller.Delete(medis);
                    if (result > 0) LoadDataRekamMedis();
                }
            }
            else 
            {
                MessageBox.Show("Data ruangan inap belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lvwRekamMedis.Items.Clear();
            listOfRekamMedis = controller.ReadByNama(txtRekam.Text);


            foreach (var medis in listOfRekamMedis)
            {
                var noUrut = lvwRekamMedis.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());

                item.SubItems.Add(medis.id_rekam_medis.ToString());
                item.SubItems.Add(medis.nama_pasien.ToString());
                item.SubItems.Add(medis.nama_dokter.ToString());
                item.SubItems.Add(medis.diagnosis);
                item.SubItems.Add(medis.tindakan);
                item.SubItems.Add(medis.nama_obat.ToString());
                item.SubItems.Add(medis.nama_ruangan.ToString());
                item.SubItems.Add(medis.tgl_masuk);
                item.SubItems.Add(medis.tgl_keluar);


                lvwRekamMedis.Items.Add(item);


            }
        }
    }
}