namespace AdminsitrasiRumahSakit.Views.Data_Rekam_Medis
{
    partial class frmEntryDataRekamMedis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTittle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNamaPasien = new System.Windows.Forms.ComboBox();
            this.cmbNamaDokter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtxDiagnosis = new System.Windows.Forms.RichTextBox();
            this.cmbObat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNamaRuangan = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpMasuk = new System.Windows.Forms.DateTimePicker();
            this.dtpKeluar = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnSelesai = new System.Windows.Forms.Button();
            this.cmbTindakan = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIDRM = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTittle
            // 
            this.lblTittle.AutoSize = true;
            this.lblTittle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTittle.Location = new System.Drawing.Point(71, 38);
            this.lblTittle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTittle.Name = "lblTittle";
            this.lblTittle.Size = new System.Drawing.Size(322, 32);
            this.lblTittle.TabIndex = 76;
            this.lblTittle.Text = "Tambah Data Rekam Medis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 159);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 77;
            this.label1.Text = "Nama Pasien";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbNamaPasien
            // 
            this.cmbNamaPasien.FormattingEnabled = true;
            this.cmbNamaPasien.Location = new System.Drawing.Point(46, 178);
            this.cmbNamaPasien.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbNamaPasien.Name = "cmbNamaPasien";
            this.cmbNamaPasien.Size = new System.Drawing.Size(174, 23);
            this.cmbNamaPasien.TabIndex = 78;
            this.cmbNamaPasien.SelectedIndexChanged += new System.EventHandler(this.cmbNamaPasien_SelectedIndexChanged);
            // 
            // cmbNamaDokter
            // 
            this.cmbNamaDokter.FormattingEnabled = true;
            this.cmbNamaDokter.Location = new System.Drawing.Point(244, 178);
            this.cmbNamaDokter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbNamaDokter.Name = "cmbNamaDokter";
            this.cmbNamaDokter.Size = new System.Drawing.Size(173, 23);
            this.cmbNamaDokter.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 211);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 81;
            this.label2.Text = "Diagnosis";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // rtxDiagnosis
            // 
            this.rtxDiagnosis.Location = new System.Drawing.Point(46, 230);
            this.rtxDiagnosis.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtxDiagnosis.Name = "rtxDiagnosis";
            this.rtxDiagnosis.Size = new System.Drawing.Size(372, 76);
            this.rtxDiagnosis.TabIndex = 82;
            this.rtxDiagnosis.Text = "";
            // 
            // cmbObat
            // 
            this.cmbObat.FormattingEnabled = true;
            this.cmbObat.Location = new System.Drawing.Point(47, 388);
            this.cmbObat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbObat.Name = "cmbObat";
            this.cmbObat.Size = new System.Drawing.Size(370, 23);
            this.cmbObat.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 369);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 83;
            this.label3.Text = "Obat";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmbNamaRuangan
            // 
            this.cmbNamaRuangan.FormattingEnabled = true;
            this.cmbNamaRuangan.Location = new System.Drawing.Point(47, 444);
            this.cmbNamaRuangan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbNamaRuangan.Name = "cmbNamaRuangan";
            this.cmbNamaRuangan.Size = new System.Drawing.Size(370, 23);
            this.cmbNamaRuangan.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 426);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 85;
            this.label4.Text = "Nama Ruangan";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 482);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 87;
            this.label5.Text = "Tgl. Masuk";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // dtpMasuk
            // 
            this.dtpMasuk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMasuk.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMasuk.Location = new System.Drawing.Point(46, 502);
            this.dtpMasuk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpMasuk.Name = "dtpMasuk";
            this.dtpMasuk.Size = new System.Drawing.Size(174, 23);
            this.dtpMasuk.TabIndex = 88;
            this.dtpMasuk.ValueChanged += new System.EventHandler(this.dtpMasuk_ValueChanged);
            // 
            // dtpKeluar
            // 
            this.dtpKeluar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpKeluar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpKeluar.Location = new System.Drawing.Point(243, 502);
            this.dtpKeluar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpKeluar.Name = "dtpKeluar";
            this.dtpKeluar.Size = new System.Drawing.Size(174, 23);
            this.dtpKeluar.TabIndex = 90;
            this.dtpKeluar.ValueChanged += new System.EventHandler(this.dtpKeluar_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(241, 482);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 89;
            this.label6.Text = "Tgl. Keluar";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Location = new System.Drawing.Point(229, 550);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(88, 27);
            this.btnSimpan.TabIndex = 91;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnSelesai
            // 
            this.btnSelesai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelesai.Location = new System.Drawing.Point(330, 550);
            this.btnSelesai.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSelesai.Name = "btnSelesai";
            this.btnSelesai.Size = new System.Drawing.Size(88, 27);
            this.btnSelesai.TabIndex = 92;
            this.btnSelesai.Text = "Selesai";
            this.btnSelesai.UseVisualStyleBackColor = true;
            this.btnSelesai.Click += new System.EventHandler(this.btnSelesai_Click);
            // 
            // cmbTindakan
            // 
            this.cmbTindakan.FormattingEnabled = true;
            this.cmbTindakan.Items.AddRange(new object[] {
            "Rawat Inap",
            "Rawat Jalan",
            "Operasi"});
            this.cmbTindakan.Location = new System.Drawing.Point(48, 331);
            this.cmbTindakan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbTindakan.Name = "cmbTindakan";
            this.cmbTindakan.Size = new System.Drawing.Size(370, 23);
            this.cmbTindakan.TabIndex = 94;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(42, 313);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 93;
            this.label7.Text = "Tindakan";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(241, 159);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 15);
            this.label8.TabIndex = 95;
            this.label8.Text = "Nama Dokter";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(43, 104);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 15);
            this.label9.TabIndex = 96;
            this.label9.Text = "ID Rekam Medis";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtIDRM
            // 
            this.txtIDRM.Location = new System.Drawing.Point(44, 127);
            this.txtIDRM.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIDRM.Name = "txtIDRM";
            this.txtIDRM.ReadOnly = true;
            this.txtIDRM.Size = new System.Drawing.Size(374, 23);
            this.txtIDRM.TabIndex = 97;
            // 
            // frmEntryDataRekamMedis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 606);
            this.Controls.Add(this.txtIDRM);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbTindakan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSelesai);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.dtpKeluar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpMasuk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbNamaRuangan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbObat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtxDiagnosis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbNamaDokter);
            this.Controls.Add(this.cmbNamaPasien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTittle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmEntryDataRekamMedis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEntryDataRekamMedis";
            this.Load += new System.EventHandler(this.frmEntryDataRekamMedis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTittle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNamaPasien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtxDiagnosis;
        private System.Windows.Forms.ComboBox cmbObat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNamaRuangan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpMasuk;
        private System.Windows.Forms.DateTimePicker dtpKeluar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnSelesai;
        private System.Windows.Forms.ComboBox cmbTindakan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbNamaDokter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIDRM;
    }
}