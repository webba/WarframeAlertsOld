using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WarframeAlertsV4
{
    public partial class Form1 : Form
    {
        private bool AllAlerts = false;
        private WarframeTimer war = new WarframeTimer();
        private int interval = 60000;
        public Form1()
        {
            InitializeComponent();
            war.WarframeData += new WarframeTimer.WarframeDel(Handler1);
            war.StartTimer(interval);
        }
        void Handler1(string s)
        {
            if (s == "Tick")
            {
                string text = WarframeAlertsTwitter.FetchCurrentAlerts(AllAlerts);
                if (text != "")
                {
                    notifyIcon1.BalloonTipText = "Location \tTime Left\tRewards\n" + text;
                    notifyIcon1.ShowBalloonTip(1000);
                }
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Resize += Form1_Resize;
        }
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            AllAlerts = checkBox1.Checked;
            war.StartTimer(interval);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            interval = (int)numericUpDown1.Value*60000;
            war.StartTimer(interval);
        }

        private void checkNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = WarframeAlertsTwitter.FetchCurrentAlerts(true);
            if (text != "")
            {
                notifyIcon1.BalloonTipText = "Location \tTime Left\tRewards\n" + text;
                notifyIcon1.ShowBalloonTip(1000);
            }
        }
    }
}