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

namespace AdminsitrasiRumahSakit
{
    public partial class Registrasi : Form
    {
        public Registrasi()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // no borders
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e) // you can safely omit this method if you want
        {
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, Top);
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, Left);
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, Right);
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, Bottom);
        }

        private const int
                HTLEFT = 10,
                HTRIGHT = 11,
                HTTOP = 12,
                HTTOPLEFT = 13,
                HTTOPRIGHT = 14,
                HTBOTTOM = 15,
                HTBOTTOMLEFT = 16,
                HTBOTTOMRIGHT = 17;

        const int border = 10;
        const int Caption = 100;

        Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, border); } }
        Rectangle Left { get { return new Rectangle(0, 0, border, this.ClientSize.Height); } }
        Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - border, this.ClientSize.Width, border); } }
        Rectangle Right { get { return new Rectangle(this.ClientSize.Width - border, 0, border, this.ClientSize.Height); } }

        Rectangle TopLeft { get { return new Rectangle(0, 0, border, border); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - border, 0, border, border); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - border, border, border); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - border, this.ClientSize.Height - border, border, border); } }

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == 0x84) // WM_NCHITTEST
            {
                Point pos = new Point(message.LParam.ToInt32());
                pos = this.PointToClient(pos);
                var cursor = this.PointToClient(Cursor.Position);

                if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
                if (pos.Y < Caption)
                {
                    message.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
            }
        }

        private SQLiteConnection GetOpenConnection()
        {
            SQLiteConnection conn = null;
            try
            {
                string dbName = @"D:\amikom\Semester 3\Pemrograman Lanjut\uas\DBase\rumah-sakit-no-foreignkey.db";
                string connectionString = string.Format("Data Source = {0}; FailIfMissing = True; Version=3; Journal Mode=Off; Pooling=True; Max Pool Size=100;", dbName);

                conn = new SQLiteConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }

        private void btnRegistrasi_Click(object sender, EventArgs e)
        {
            var result = 0;
            if(txtUsername1.Texts == "" || txtPassword1.Texts == "") {
                MessageBox.Show("Username atau password masih kosong, registrasi gagal!");
                txtUsername1.ClearText();
                txtPassword1.ClearText();
                txtUsername1.Focus();
            } else if(txtUsername1.Texts == "" && txtPassword1.Texts == "") {
                MessageBox.Show("Username atau password masih kosong, registrasi gagal!");
                txtUsername1.ClearText();
                txtPassword1.ClearText();
                txtUsername1.Focus();
            } else {
                SQLiteConnection conn = GetOpenConnection();
                var sql = @"insert into administrasi (username, password) values (@username, @password)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                try
                {
                    cmd.Parameters.AddWithValue("@username", txtUsername1.Texts);
                    cmd.Parameters.AddWithValue("@password", txtPassword1.Texts);
                    result = cmd.ExecuteNonQuery(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                }

                if (result > 0)
                {
                    MessageBox.Show("Registrasi berhasil, Silahkan Login!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername1.ClearText();
                    txtPassword1.ClearText();
                    txtUsername1.Focus();
                }
                else
                    MessageBox.Show("Registrasi gagal!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conn.Dispose();
            }
        }

        private void lblClearFields_Click(object sender, EventArgs e)
        {
            txtUsername1.ClearText();
            txtPassword1.ClearText();
            txtUsername1.Focus();
        }

        private void lbllogin_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }
        private RJTextBox myTextBox = new RJTextBox();
        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword1.PasswordChar = !checkBoxShowPass.Checked;
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegitrasi1_Click(object sender, EventArgs e)
        {
            var result = 0;
            if (txtUsername1.Texts == "" || txtPassword1.Texts == "")
            {
                MessageBox.Show("Username atau password masih kosong, registrasi gagal!");
                txtUsername1.ClearText();
                txtPassword1.ClearText();
                txtUsername1.Focus();
            }
            else if (txtUsername1.Texts == "" && txtPassword1.Texts == "")
            {
                MessageBox.Show("Username atau password masih kosong, registrasi gagal!");
                txtUsername1.ClearText();
                txtPassword1.ClearText();
                txtUsername1.Focus();
            }
            else
            {
                SQLiteConnection conn = GetOpenConnection();
                var sql = @"insert into administrasi (username, password) values (@username, @password)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                try
                {
                    cmd.Parameters.AddWithValue("@username", txtUsername1.Texts);
                    cmd.Parameters.AddWithValue("@password", txtPassword1.Texts);
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                }

                if (result > 0)
                {
                    MessageBox.Show("Registrasi berhasil, Silahkan Login!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername1.ClearText();
                    txtPassword1.ClearText();
                    txtUsername1.Focus();
                }
                else
                    MessageBox.Show("Registrasi gagal!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.Dispose();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
