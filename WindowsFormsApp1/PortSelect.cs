using System.IO.Ports;
using System.Windows.Forms;
using System;

namespace WindowsFormsApp1
{
    public partial class PortSelect : Form
    {
        private string portName;

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
    }
}
