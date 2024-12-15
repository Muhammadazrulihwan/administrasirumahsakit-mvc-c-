using AdminsitrasiRumahSakit.Controller;
using AdminsitrasiRumahSakit.Model.Entity;
using AdminsitrasiRumahSakit.Views.Data_Dokter;
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
    public partial class frmDataPasien : Form
    {
        private List<Pasien> listOfPasien = new List<Pasien>();
        private PasienController controller;
        public frmDataPasien()
        {
            InitializeComponent();
            controller = new PasienController();
            InisialisasiListView();
            LoadDataPasien();
        }

        private void InisialisasiListView()
        {
            lvwDataPasien.View = View.Details;
            lvwDataPasien.FullRowSelect = true;
            lvwDataPasien.GridLines = true;

            lvwDataPasien.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwDataPasien.Columns.Add("Nama", 120, HorizontalAlignment.Left);
            lvwDataPasien.Columns.Add("Jenis Kelamin", 80, HorizontalAlignment.Center);
            lvwDataPasien.Columns.Add("Alamat", 80, HorizontalAlignment.Left);
            lvwDataPasien.Columns.Add("Tinggi Badan", 80, HorizontalAlignment.Center);
            lvwDataPasien.Columns.Add("Berat Badan", 80, HorizontalAlignment.Center);
            lvwDataPasien.Columns.Add("Tempat Lahir", 80, HorizontalAlignment.Center);
            lvwDataPasien.Columns.Add("Tanggal Lahir", 80, HorizontalAlignment.Center);
            lvwDataPasien.Columns.Add("Nomor Telepon", 100, HorizontalAlignment.Left);
        }

        private void LoadDataPasien()
        {
            lvwDataPasien.Items.Clear();

            listOfPasien = controller.ReadAll();

            foreach (var pasien in  listOfPasien)
            {
                var noUrut = lvwDataPasien.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(pasien.nama);
                item.SubItems.Add(pasien.jenis_kelamin);
                item.SubItems.Add(pasien.alamat);
                item.SubItems.Add(pasien.tinggi_badan.ToString());
                item.SubItems.Add(pasien.berat_badan.ToString());
                item.SubItems.Add(pasien.tempat_lahir);
                item.SubItems.Add(pasien.tanggal_lahir);
                item.SubItems.Add(pasien.no_telp);

                // tampilkan data mhs ke listview
                lvwDataPasien.Items.Add(item);
            }
        }


        private void OnCreateEventHandler(Pasien pasien)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            listOfPasien.Add(pasien);

            int noUrut = lvwDataPasien.Items.Count + 1;

            // tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(pasien.nama);
            item.SubItems.Add(pasien.jenis_kelamin);
            item.SubItems.Add(pasien.alamat);
            item.SubItems.Add(pasien.tinggi_badan.ToString());
            item.SubItems.Add(pasien.berat_badan.ToString());
            item.SubItems.Add(pasien.tempat_lahir);
            item.SubItems.Add(pasien.tanggal_lahir);
            item.SubItems.Add(pasien.no_telp);

            lvwDataPasien.Items.Add(item);
            LoadDataPasien();
        }

        // method event handler untuk merespon event OnUpdate,
        private void OnUpdateEventHandler(Pasien pasien)
        {
            // ambil index data mhs yang edit
            int index = lvwDataPasien.SelectedIndices[0];

            // update informasi mhs di listview
            ListViewItem itemRow = lvwDataPasien.Items[index];
            itemRow.SubItems[1].Text = pasien.nama;
            itemRow.SubItems[2].Text = pasien.jenis_kelamin;
            itemRow.SubItems[3].Text = pasien.alamat;
            itemRow.SubItems[4].Text = pasien.tinggi_badan.ToString();
            itemRow.SubItems[5].Text = pasien.berat_badan.ToString();
            itemRow.SubItems[6].Text = pasien.tempat_lahir;
            itemRow.SubItems[7].Text = pasien.tanggal_lahir;
            itemRow.SubItems[8].Text = pasien.no_telp;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            frmEntryPasien frmEntry = new frmEntryPasien("Tambah Data Pasien", controller);

            frmEntry.OnCreate += OnCreateEventHandler;

            frmEntry.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwDataPasien.SelectedItems.Count > 0)
            {
                Pasien pasien = listOfPasien[lvwDataPasien.SelectedIndices[0]];

                frmEntryPasien frmEntry = new frmEntryPasien("Edit Data Pasien", pasien, controller);

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
            if (lvwDataPasien.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data Pasien ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Pasien pasien = listOfPasien[lvwDataPasien.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = controller.Delete(pasien);
                    if (result > 0) LoadDataPasien();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data pasien belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lvwDataPasien.Items.Clear();

            listOfPasien = controller.ReadByNama(txtNama.Text);

            foreach (var pasien in listOfPasien)
            {
                var noUrut = lvwDataPasien.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(pasien.nama);
                item.SubItems.Add(pasien.jenis_kelamin);
                item.SubItems.Add(pasien.alamat);
                item.SubItems.Add(pasien.tinggi_badan.ToString());
                item.SubItems.Add(pasien.berat_badan.ToString());
                item.SubItems.Add(pasien.tempat_lahir);
                item.SubItems.Add(pasien.tanggal_lahir);
                item.SubItems.Add(pasien.no_telp);

                // tampilkan data mhs ke listview
                lvwDataPasien.Items.Add(item);
            }
        }
    }
}
