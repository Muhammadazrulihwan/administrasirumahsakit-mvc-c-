using AdminsitrasiRumahSakit.Controller;
using AdminsitrasiRumahSakit.Model.Entity;
using AdminsitrasiRumahSakit.Views.Data_Pasien;
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
    public partial class frmDataRuangInap : Form
    {
        private List<RuanganInap> listOfRuanganInap = new List<RuanganInap>();
        private RuanganInapController controller;
        public frmDataRuangInap()
        {
            InitializeComponent();
            controller = new RuanganInapController();
            InisialisasiListView();
            LoadDataRuanganInap();
        }

        private void InisialisasiListView()
        {
            lvwRuangInap.View = View.Details;
            lvwRuangInap.FullRowSelect = true;
            lvwRuangInap.GridLines = true;

            lvwRuangInap.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwRuangInap.Columns.Add("Nama Ruangan", 120, HorizontalAlignment.Left);
            lvwRuangInap.Columns.Add("Tipe", 80, HorizontalAlignment.Center);
            lvwRuangInap.Columns.Add("Harga", 80, HorizontalAlignment.Left);;
        }

        private void LoadDataRuanganInap()
        {
            lvwRuangInap.Items.Clear();

            listOfRuanganInap = controller.ReadAll();

            foreach (var kamar in listOfRuanganInap)
            {
                var noUrut = lvwRuangInap.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(kamar.nama);
                item.SubItems.Add(kamar.tipe);
                item.SubItems.Add(kamar.harga.ToString());

                // tampilkan data mhs ke listview
                lvwRuangInap.Items.Add(item);
            }
        }

        private void OnCreateEventHandler(RuanganInap kamar)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            listOfRuanganInap.Add(kamar);

            int noUrut = lvwRuangInap.Items.Count + 1;

            // tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(kamar.nama);
            item.SubItems.Add(kamar.tipe);
            item.SubItems.Add(kamar.harga.ToString());

            lvwRuangInap.Items.Add(item);
            LoadDataRuanganInap();
        }

        // method event handler untuk merespon event OnUpdate,
        private void OnUpdateEventHandler(RuanganInap kamar)
        {
            // ambil index data mhs yang edit
            int index = lvwRuangInap.SelectedIndices[0];

            // update informasi mhs di listview
            ListViewItem itemRow = lvwRuangInap.Items[index];
            itemRow.SubItems[1].Text = kamar.nama;
            itemRow.SubItems[2].Text = kamar.tipe;
            itemRow.SubItems[3].Text = kamar.harga.ToString();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            frmEntryDataRuangInap frmEntry = new frmEntryDataRuangInap("Tambah Data Ruangan Inap", controller);

            frmEntry.OnCreate += OnCreateEventHandler;

            frmEntry.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwRuangInap.SelectedItems.Count > 0)
            {
                RuanganInap kamar = listOfRuanganInap[lvwRuangInap.SelectedIndices[0]];

                frmEntryDataRuangInap frmEntry = new frmEntryDataRuangInap("Edit Data Ruangan Inap", kamar, controller);

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
            if (lvwRuangInap.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data ruangan inap ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    RuanganInap kamar = listOfRuanganInap[lvwRuangInap.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = controller.Delete(kamar);
                    if (result > 0) LoadDataRuanganInap();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data ruangan inap belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lvwRuangInap.Items.Clear();

            listOfRuanganInap = controller.ReadByNama(txtRuang.Text);

            foreach (var kamar in listOfRuanganInap)
            {
                var noUrut = lvwRuangInap.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(kamar.nama);
                item.SubItems.Add(kamar.tipe);
                item.SubItems.Add(kamar.harga.ToString());

                // tampilkan data mhs ke listview
                lvwRuangInap.Items.Add(item);
            }
        }
    }
}
