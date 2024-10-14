using System.IO.Ports;
using System.Windows.Forms;
using System;

namespace WindowsFormsApp1
{
    public partial class PortSelect : Form
    {
        private string portName;

        public string BardRate {  get; set; }
        public string Parity { get; set; }
        public string DataBits { get; set; }
        public string StopBits { get; set; }

        public PortSelect()
        {
            InitializeComponent();
        }

        private void selectPort(object sender, EventArgs e)
        {
            if (comboxPortsList.SelectedIndex == -1)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                portName = comboxPortsList.SelectedItem.ToString();
                BardRate = baudRate.SelectedItem.ToString();
                Parity = parity.SelectedItem.ToString();
                DataBits = dataBits.SelectedItem.ToString();
                StopBits = stopBits.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
            }
            Close();
        }

        private void PortSelect_Load(object sender, EventArgs e)
        {
            foreach (string s in SerialPort.GetPortNames())
            {
                comboxPortsList.Items.Add(s);
            }
        }


        public string getPortName()
        {
            return portName;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
