using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminsitrasiRumahSakit.Model.Entity;
using AdminsitrasiRumahSakit.Controller;
using AdminsitrasiRumahSakit.Views.Data_Dokter;

namespace AdminsitrasiRumahSakit.Views
{
    public partial class frmDataDokter : Form
    {
        private List<Dokter> listOfDokter = new List<Dokter>();
        private DokterController controller;

        public frmDataDokter()
        {
            InitializeComponent();
            controller = new DokterController();
            InisialisasiListView();
            LoadDataDokter();
        }

        private void InisialisasiListView()
        {
            lvwDokter.View = View.Details;
            lvwDokter.FullRowSelect = true;
            lvwDokter.GridLines = true;

            lvwDokter.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwDokter.Columns.Add("Nama", 120, HorizontalAlignment.Center);
            lvwDokter.Columns.Add("Spesialis", 80, HorizontalAlignment.Left);
            lvwDokter.Columns.Add("No Telp", 80, HorizontalAlignment.Center);
            lvwDokter.Columns.Add("Alamat", 80, HorizontalAlignment.Center);
        }

        private void LoadDataDokter()
        {
            lvwDokter.Items.Clear();
            listOfDokter = controller.ReadAll();

            foreach (var dokter in listOfDokter)
            {
                var noUrut = lvwDokter.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(dokter.nama);
                item.SubItems.Add(dokter.spesialis);
                item.SubItems.Add(dokter.no_telp.ToString());
                item.SubItems.Add(dokter.alamat);

                lvwDokter.Items.Add(item);
            }
        }

        private void OnCreateEventHandler(Dokter dokter)
        {

            listOfDokter.Add(dokter);

            int noUrut = lvwDokter.Items.Count + 1;

            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(dokter.nama);
            item.SubItems.Add(dokter.spesialis);
            item.SubItems.Add(dokter.no_telp);  // Change to string
            item.SubItems.Add(dokter.alamat);

            lvwDokter.Items.Add(item);
            LoadDataDokter();
        }

    
        private void OnUpdateEventHandler(Dokter dokter)
        {
          
            int index = lvwDokter.SelectedIndices[0];

       
            ListViewItem itemRow = lvwDokter.Items[index];
            itemRow.SubItems[1].Text = dokter.nama;
            itemRow.SubItems[2].Text = dokter.spesialis;
            itemRow.SubItems[3].Text = dokter.no_telp.ToString();
            itemRow.SubItems[4].Text = dokter.alamat;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            frmEntryDokter frmEntry = new frmEntryDokter("Tambah Data Dokter", controller);

            frmEntry.OnCreate += OnCreateEventHandler;

            frmEntry.ShowDialog();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwDokter.SelectedItems.Count > 0)
            {
                Dokter dokter = listOfDokter[lvwDokter.SelectedIndices[0]];

                frmEntryDokter frmEntry = new frmEntryDokter("Edit Data Dokter", dokter, controller);

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
            if (lvwDokter.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data Dokter ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    Dokter dokter = listOfDokter[lvwDokter.SelectedIndices[0]];

                    var result = controller.Delete(dokter);
                    if (result > 0) LoadDataDokter();
                }
            }
            else 
            {
                MessageBox.Show("Data dokter belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            lvwDokter.Items.Clear();
            listOfDokter = controller.ReadByNama(txtNama.Text);

            foreach (var dokter in listOfDokter)
            {
                var noUrut = lvwDokter.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(dokter.nama);
                item.SubItems.Add(dokter.spesialis);
                item.SubItems.Add(dokter.no_telp.ToString());
                item.SubItems.Add(dokter.alamat);

                lvwDokter.Items.Add(item);
            }
        }
    }
}
