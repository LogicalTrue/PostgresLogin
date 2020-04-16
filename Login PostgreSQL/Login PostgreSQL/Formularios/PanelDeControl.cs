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
using FontAwesome.Sharp;

namespace Login_PostgreSQL
{
    public partial class PanelDeControl : Form
    {

        private IconButton CurrentBtn;
        private Panel LeftBorderBtn;
        private Form CurrentChildForm;

        public PanelDeControl(string username)
        {
            InitializeComponent();
            Lbluser.Text = Lbluser.Text + username;
            //Solo en caso de necesitar la variable para otros controles y mensajes si se almacena.
            LeftBorderBtn = new Panel();
            LeftBorderBtn.Size = new Size(5, 50);
            PanelMenu.Controls.Add(LeftBorderBtn);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
        }



        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                       
                CurrentBtn = (IconButton)senderBtn;
                CurrentBtn.BackColor = Color.FromArgb(170, 170, 170);
                CurrentBtn.ForeColor = color;
                CurrentBtn.TextAlign = ContentAlignment.MiddleCenter;
                CurrentBtn.IconColor = color;
                CurrentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                CurrentBtn.ImageAlign = ContentAlignment.MiddleRight;


                LeftBorderBtn.BackColor = color;
                LeftBorderBtn.Location = new Point(0, CurrentBtn.Location.Y);
                LeftBorderBtn.Visible = true;
                LeftBorderBtn.BringToFront();

            }

        }

        private void DisableButton()
        {
            if (CurrentBtn != null)
            {
                
                CurrentBtn.BackColor = Color.FromArgb(0, 139, 139);
                CurrentBtn.ForeColor = Color.Black;
                CurrentBtn.TextAlign = ContentAlignment.MiddleCenter;
                Btn1.IconColor = Color.YellowGreen;
                Btn2.IconColor = Color.DarkOrange;
                Btn3.IconColor = Color.Red;
                Btn4.IconColor = Color.Tomato;   
                CurrentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                CurrentBtn.ImageAlign = ContentAlignment.MiddleRight;

            }

        }

        private struct RGBColors
            {
            public static Color color1 = Color.Red;
            public static Color color2 = Color.Blue;
            public static Color color3 = Color.GreenYellow;
            public static Color color4 = Color.BurlyWood;
            }

        private void OpenChildForm(Form ChildForm)
        {
            if (CurrentChildForm != null)
            {
                CurrentChildForm.Close();
            }

            CurrentChildForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            PrincipalPanel.Controls.Add(ChildForm);
            PrincipalPanel.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();


        }

        private void PanelDeControl_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\Utopic\source\repos\Login PostgreSQL\Login PostgreSQL\img\cruz2.png");
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\Utopic\source\repos\Login PostgreSQL\Login PostgreSQL\img\cruz.png");
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            DisableButton();
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new Estadisticas());

        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            DisableButton();
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new Productos());

        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            DisableButton();
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new Configuracion());
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
