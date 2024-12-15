using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace AdminsitrasiRumahSakit
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // no borders
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e) // you can safely omit this method if you want
        {
            e.Graphics.FillRectangle(Brushes.White, Top);
            e.Graphics.FillRectangle(Brushes.White, Left);
            e.Graphics.FillRectangle(Brushes.White, Right);
            e.Graphics.FillRectangle(Brushes.White, Bottom);
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

        private void btnLogin1_Click(object sender, EventArgs e)
        {
            RJTextBox textbox = new RJTextBox();
            using (SQLiteConnection conn = GetOpenConnection())
            {
                string sql = "SELECT * FROM administrasi WHERE username = @username AND password = @password";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", txtUsername1.Texts);
                    cmd.Parameters.AddWithValue("@password", txtPassword1.Texts);

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        if (dtr.Read())
                        {
                            new Dashboard().Show();
                            this.Hide();
                        }
                        else if (txtUsername1.Texts == "" || txtPassword1.Texts == "")
                        {
                            MessageBox.Show("Username atau password masih kosong!");
                            txtUsername1.ClearText();
                            txtPassword1.ClearText();
                            txtUsername1.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Username atau password anda salah!");
                            txtUsername1.ClearText();
                            txtPassword1.ClearText();
                            txtUsername1.Focus();
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

            /*this.MaximizeBox = false;*/
        }
        private RJTextBox myTextBox = new RJTextBox();
        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword1.PasswordChar = !checkBoxShowPass.Checked;
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
             new Registrasi().Show();
            this.Hide();
        }
    }
}
