using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Timer
{
    public partial class Form1 : Form
    {
        int i;
        bool show = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            i = 0;
            lblWelcome.Left = -250;
            lblfoater.Left = 700;
            lblLeft.Top = 0; lblLeft.Left = 0;
            lblMid.Top = 200; lblMid.Left = 300;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i == 100)
                timer1.Enabled = false;
            else
            {
                i++; //i+2  i+5 .....
                lblCount.Text = i.ToString() + "%"; //.ToString for convert to string 
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (show) //if (show == true) this equal if (show) so by defult while !show = false
            {
                lblLoading.Visible = show; //true
                lblLoading.BackColor = Color.Red;
                lblLoading.ForeColor = Color.White;
                show = false;
            }
            else
            {
                lblLoading.Visible = show; //false
                lblLoading.BackColor = Color.FromArgb(0,255,0);
                show = true;
            }
            /*  lblLoading.Visible = show;    we can use this only
                show = !show;                 without if statement  */
            if (i == 100)
            {
                lblLoading.Visible = true;
                lblLoading.Text = "Complete";
            }
            while (i == 100)
            {
                progressBar1.Step = i;
                break;
            }
        }
        private void progressBar1_Click(object sender, EventArgs e) {}
        private void Time_Tick(object sender, EventArgs e)
        {
            DateTime time = new DateTime();
            time = DateTime.Now;
            lblClock.Text = time.ToLongTimeString().ToString();
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            bool inside = ClientRectangle.IntersectsWith(lblLeft.Bounds);
            if (lblWelcome.Left > 700 && lblfoater.Left < -600)
            {
                lblWelcome.Left = -250;
                lblfoater.Left = 600;
            }
            else
            {
                lblWelcome.Left += 1;
                lblfoater.Left -= 1;
            }
            if(!inside)
            {
                lblLeft.Top = 0;
            }
            lblLeft.Top += 1;
           /* if (lblLeft.Left > 800&& lblLeft.Top>550)
            {
                lblLeft.Left = -50;
                lblLeft.Top = -50;
            }
            else
            {
                lblLeft.Left += 1;
            }*/
        }
        private void lblfoater_Click(object sender, EventArgs e) {}
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (lblMid.Top > 350 && lblMid.Left > 350) 
            {
                lblMid.Top = 0;
                lblMid.Left = 0;
            }
            else
            {
                lblMid.Top += 3;
                lblMid.Left += 3;
            }
        }
        private void timSplash_Tick(object sender, EventArgs e)
        {
            this.Hide();
            splash ob = new splash();
            ob.Show();
            timSplash.Enabled = false;
        }
        private void timProgress_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
        }
        private void lblLeft_Click(object sender, EventArgs e) {}
    }
}