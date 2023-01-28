using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Carpenter_v1
{
    public partial class onboard : Form
    {

        private int progresValue = 0;
        private void controlProgress()
        {
            progresValue += 100 ;
            if (progresValue <= progressBar1.Maximum)
            {
                progressBar1.Value = progresValue;
            }
            else
            {
                progressBar1.Value = progressBar1.Maximum;
                progresValue = 0;
                changeState();
                timer1.Stop();
            }
        }

        private void changeState()
        {
            label2.Text = "Well Done!";
            this.Text = "Ready";
            progressBar1.Visible = false;
            button1.BackColor = ColorTranslator.FromHtml("#FF01D328");
            button1.Visible = true;
        }

       
        public onboard()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            controlProgress();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            main_page mp = new main_page();
            mp.ShowDialog();
        }

        private void onboard_Load(object sender, EventArgs e)
        {

        }
    }
}
