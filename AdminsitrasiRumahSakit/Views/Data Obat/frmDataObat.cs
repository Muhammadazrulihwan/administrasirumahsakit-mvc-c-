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

namespace AdminsitrasiRumahSakit.Views.Data_Obat
{
    public partial class frmDataObat : Form
    {
        private List<Obat> listOfObat = new List<Obat>();
        private ObatController controller;

        public frmDataObat()
        {
            InitializeComponent();
            controller = new ObatController();
            InisialisasiListView();
            LoadDataObat();
        }

        private void InisialisasiListView()
        {
            lvwObat.View = View.Details;
            lvwObat.FullRowSelect = true;
            lvwObat.GridLines = true;

            lvwObat.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwObat.Columns.Add("Nama Obat", 120, HorizontalAlignment.Center);
            lvwObat.Columns.Add("Stok", 80, HorizontalAlignment.Left);
            lvwObat.Columns.Add("Harga", 80, HorizontalAlignment.Center);
        }

        private void LoadDataObat()
        {
            lvwObat.Items.Clear();
            listOfObat = controller.ReadAll();

            foreach (var obat in listOfObat)
            {
                var noUrut = lvwObat.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(obat.nama_obat);
                item.SubItems.Add(obat.stok.ToString());
                item.SubItems.Add(obat.harga.ToString());

                lvwObat.Items.Add(item);
            }
        }

        private void OnCreateEventHandler(Obat obat)
        {
            listOfObat.Add(obat);

            int noUrut = lvwObat.Items.Count + 1;

            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(obat.nama_obat);
            item.SubItems.Add(obat.stok.ToString());
            item.SubItems.Add(obat.harga.ToString());

            lvwObat.Items.Add(item);
            LoadDataObat();
        }

        private void OnUpdateEventHandler(Obat obat)
        {
            int index = lvwObat.SelectedIndices[0];

            ListViewItem itemRow = lvwObat.Items[index];
            itemRow.SubItems[1].Text = obat.nama_obat;
            itemRow.SubItems[2].Text = obat.stok.ToString();
            itemRow.SubItems[3].Text = obat.harga.ToString();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            frmEntryObat frmEntry = new frmEntryObat("Tambah Data Obat", controller);

            frmEntry.OnCreate += OnCreateEventHandler;

            frmEntry.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwObat.SelectedItems.Count > 0)
            {
                Obat obat = listOfObat[lvwObat.SelectedIndices[0]];

                frmEntryObat frmEntry = new frmEntryObat("Edit Data Obat", obat, controller);

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
            if (lvwObat.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data Obat ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    Obat obat = listOfObat[lvwObat.SelectedIndices[0]];

                    var result = controller.Delete(obat);
                    if (result > 0) LoadDataObat();
                }
            }
            else
            {
                MessageBox.Show("Data obat belum dipilih !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            lvwObat.Items.Clear();
            listOfObat = controller.ReadByNama(txtNama.Text);

            foreach (var obat in listOfObat)
            {
                var noUrut = lvwObat.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(obat.nama_obat);
                item.SubItems.Add(obat.stok.ToString());
                item.SubItems.Add(obat.harga.ToString());

                lvwObat.Items.Add(item);
            }
        }
    }
}
