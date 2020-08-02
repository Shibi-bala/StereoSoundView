using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SoundView
{
    public partial class Form1 : Form
    {
        MMDevice device = null;

        public Form1()
        {
            InitializeComponent();
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            device = devices.ToArray()[0];
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(device != null)
            {
                var val = (int)(((device.AudioMeterInformation.PeakValues[0]- device.AudioMeterInformation.PeakValues[1]) * 50)+50);
                if (val < 35)
                {
                    panel2.BackColor = Color.Green;
                } else
                {
                    panel2.BackColor = SystemColors.Control;
                }

                if (val > 65)
                {
                    panel1.BackColor = Color.Green;
                }
                else
                {
                    panel1.BackColor = SystemColors.Control;
                }
            }
        }
    }
}
