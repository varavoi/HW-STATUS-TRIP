using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace WFORMS_HW
{
    public partial class Form1 : Form
    {
        private bool datetime = false;
        List<Color> clr;
        private string[] ru = new string[]
            {"Изменение цвета формы", "Изменение цвета", "Время", "Язык" };

        private string[] en = new string[]
            {"Form color", "Color", "Time", "Language"};
        public Form1()
        {
            InitializeComponent();
            
            ColorIntitialize(out clr);
            panel1.BackColor = SystemColors.Control;

        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(this.GetType());

            resources.ApplyResources(this, "$this");
            foreach (Control c in this.Controls)
            {
                resources.ApplyResources(c, c.Name);
            }
            label4.Text = en[0];
            изменениеЦветаToolStripMenuItem.Text = en[1];
            TIMEToolStripMenuItem.Text = en[2];
            языкToolStripMenuItem.Text = en[3];

        }

        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");

            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(this.GetType());

            resources.ApplyResources(this, "$this");
            foreach (Control c in this.Controls)
            {
                resources.ApplyResources(c, c.Name);
            }
            label4.Text = ru[0];
            изменениеЦветаToolStripMenuItem.Text = ru[1];
            TIMEToolStripMenuItem.Text = ru[2];
            языкToolStripMenuItem.Text = ru[3];
        }
        private void ColorIntitialize(out List<Color> clr1)
        {
            clr1 = new List<Color>();
            clr1.Add(Color.Red); clr1.Add(Color.Yellow); clr1.Add(Color.Green); clr1.Add(Color.Black);
            clr1.Add(Color.Blue); clr1.Add(Color.Pink); clr1.Add(Color.Green); clr1.Add(Color.Gray);
            clr1.Add(Color.Purple); clr1.Add(Color.Brown); clr1.Add(Color.Chocolate); clr1.Add(Color.Brown);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TTtoolStripMenuItem1.Text = DateTime.Now.ToString("dddd");
            VVtoolStripMenuItem1.Text = DateTime.Now.ToString("hh:mm:ss");
            VREMYA.Text = DateTime.Now.ToString("dd'-'MM'-'yyyy");
            panel1.Visible = false;
            Timer timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        //таймер
       
        private void timer_Tick(object sender, EventArgs e)
        {
            if (datetime)
            {
                VREMYA.Text = DateTime.Now.ToString("hh:mm");
               datetime = false;
            }
            else
            {
                VREMYA.Text = DateTime.Now.ToString("dd'-'MM'-'yyyy");
                datetime = true;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // this.BackColor = collColor[trackBar1.Value];
            //this.BackColor = Color.Green;
            //this.BackColor = clr[trackBar1.Value];

            this.BackColor = clr[trackBar1.Value];

        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {

            this.BackColor = clr[trackBar2.Value];
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {

            this.BackColor = clr[trackBar3.Value];
        }

        private void изменениеЦветаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
    }
}
