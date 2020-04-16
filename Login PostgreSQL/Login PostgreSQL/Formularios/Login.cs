using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Login_PostgreSQL
{


    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private NpgsqlConnection con;
        string constring = String.Format("Server=127.0.0.1;" +
            "Port=5432;" +
            "Database=DB1;" +
            "User Id=postgres;" +
            "Password=postgres;");

        private NpgsqlCommand cmd;
        private string sql = null;

        

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {          
                con.Open();
                cmd = new NpgsqlCommand(@"select * from u_login(:_username,:_password)", con);

                cmd.Parameters.AddWithValue("_username", TxtUserName.Text);
                cmd.Parameters.AddWithValue("_password", TxtPassword.Text);

                int result = (int)cmd.ExecuteScalar();

                con.Close();

                if(result == 1)
                    {
                    this.Hide();
                    new PanelDeControl(TxtUserName.Text).Show(); 
                    }
                    else
                        {
                        MessageBox.Show("Usuario o contraseña incorrecto");
                        return;
                        }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Cierra el form
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new NpgsqlConnection(constring);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
           switch(e.Button)
            {
                case MouseButtons.Left:                  
                    break;
                case MouseButtons.Right:
                    break;

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    Application.Exit();
                    break;
                case MouseButtons.Right:                  
                    break;
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    this.WindowState = FormWindowState.Minimized;
                    break;
                case MouseButtons.Right:
                    break;

            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\Utopic\source\repos\Login PostgreSQL\Login PostgreSQL\img\cruz2.png");
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\Utopic\source\repos\Login PostgreSQL\Login PostgreSQL\img\cruz.png");
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
