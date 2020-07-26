using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundView
{
    public partial class Form1 : Form
    {
        bool start = false;

        public Form1()
        {
            InitializeComponent();
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            comboBox1.Items.AddRange(devices.ToArray());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null && start == true)
            {
                var device = (MMDevice)comboBox1.SelectedItem;
                progressBar1.Value = (int)(((device.AudioMeterInformation.PeakValues[0]- device.AudioMeterInformation.PeakValues[1]) * 50)+50);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            start = false;
        }
    }
}
