using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.Web.Script.Serialization;

namespace WarframeAlertsV4
{
    public class WarframeTimer
    {
        public Timer timer1 = new Timer();
        public delegate void WarframeDel(string data);
        public event WarframeDel WarframeData;
        protected void OnWarframeData(string data)
        {
            if (WarframeData != null)
            {
                WarframeData(data);
            }
        }
        public void StartTimer(int interval)
        {
            OnWarframeData("Tick");
            if (timer1.Enabled)
                timer1.Stop();
            timer1.Interval = interval;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            OnWarframeData("Tick");
        }
    }
}
