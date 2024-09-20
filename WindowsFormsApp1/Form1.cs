using System.IO.Ports;
using System.Windows.Forms;
using System;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private static bool onenetDone;

        private string portName;
        private SerialPort serialPort;
        private System.Windows.Forms.Timer time;

        public delegate void SetStateText(string txt);
        public delegate void SendOnenetCommand();
        public delegate bool RegisterIOT(byte[] portData);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //let user select serialport
            PortSelect portSelect = new PortSelect();
            if (portSelect.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("no port selected,program will quit!", "Chint", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            portName = portSelect.getPortName();
            stateText.Text = "port: " + portName + " is opened";
            checkBox1.Checked = true;
            checkBox1.Text = portName + " opened";
            time = new System.Windows.Forms.Timer();
            time.Interval = 2000;
            time.Tick += Time_Tick;
            //if port was selected,then we can set options and open it!
            if (portName != null)
            {
                try
                {
                    serialPort = new SerialPort(portName, 4800, Parity.Even, 8, StopBits.One);
                    serialPort.DataReceived += DataReceived;
                    serialPort.Open();
                }
                catch (Exception err)
                {
                    //perhaps another program already opened it,so we must warning user ,and close the program
                    MessageBox.Show("sorry, " + err.Message + "program will close!");
                    Close();
                }
            }
            onenetDone = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort != null) serialPort.Close();
        }

        public void DataReceived(object sender, EventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            Thread.Sleep(500);
            int len = sp.BytesToRead;
            //if (len < 15) return; 
            byte[] byteData = new byte[len];
            sp.Read(byteData, 0, len);

            int index = 0;
            byte[] meaningfulData = new byte[0];
            for (int i = 0; i < len; i++)
            {
                //if (len - i < 15) break;
                if (byteData[i] == 0x68 && byteData[i + 1] == 0x30)
                {
                    //if data don't have 0x16 endbyte
                    int lastIndex = Array.LastIndexOf<byte>(byteData, 0x16);
                    if (lastIndex == -1) return;
                    index = i;
                    int length = lastIndex - i + 1;
                    meaningfulData = new byte[length];
                    Array.Copy(byteData, index, meaningfulData, 0, length);
                    break;
                }
            }
            //UnpackData(meaningfulData);
            AnalysisDataPack analysis = new AnalysisDataPack(meaningfulData);
            if (analysis.Analysis())
            {

                //recived usart open command,we must send onenet command to board
                //this is a new thread,can't access form thread UI
                //stateText.Text = "Recived port open of board command.";
                SetStateText tem = new SetStateText(UpdateStateTxt);
                SendOnenetCommand soc = new SendOnenetCommand(SendOnenet);
                RegisterIOT register = new RegisterIOT(RegisterIOTPlatform);
                if (analysis.GetD0D1() == 0x000B)
                {
                    //port open 5s command

                    BeginInvoke(tem, new object[] { "Recived port open of board command." });
                    //SerialPort sp = (SerialPort)sender;
                    //byte[] commandOnenet = new byte[] { 0x68, 0x30, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x31, 0x02, 0x27, 0x0C, 0xF7, 0x16 };
                    //write onenet command
                    //serialPort.Write(commandOnenet, 0, commandOnenet.Length);
                    //Invoke(soc);
                    SendOnenet();
                }
                else if (analysis.GetD0D1() == 0x270C && analysis.ControlNumber[0] == 0xB1)
                {
                    Invoke(tem, new object[] { "Recived onenet command of board." });
                    byte[] onenetData = new byte[meaningfulData.Length];
                    Array.Copy(meaningfulData, 0, onenetData, 0, onenetData.Length);
                    BeginInvoke(register, new object[] { onenetData });
                    //RegisterIOTPlatform(onenetData);
                }

            }
        }


        public void UpdateStateTxt(string txt)
        {
            this.stateText.Text = txt;
        }
        public void SendOnenet()
        {
            if (serialPort != null)
            {
                //Thread.Sleep(4000);
                byte[] commandOnenet = new byte[] { 0x68, 0x30, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x31, 0x02, 0x27, 0x0C, 0xF7, 0x16 };
                if (onenetDone) return;
                serialPort.Write(commandOnenet, 0, commandOnenet.Length);
            }
        }

        public bool RegisterIOTPlatform(byte[] portData)
        {
            //if check1box is cancel,return this function ,else program will crash for resend onenet command by a closed of serialport
            onenetDone = true;
            if (!checkBox1.Checked)
            {
                stateText.Text = "user close port,so cancel register!";
                return false;
            }
            string meterName, IMEI, IMSI, ICCID;
            if (portData.Length != 0)
            {
                AnalysisDataPack analysis = new AnalysisDataPack(portData);
                if (analysis.Analysis())
                {
                    byte[] name = new byte[32];
                    byte[] imei = new byte[32];
                    byte[] imsi = new byte[32];
                    byte[] iccid = new byte[25];
                    Array.Copy(analysis.DataField, 3, name, 0, 32);
                    Array.Copy(analysis.DataField, 3 + 32, imei, 0, 32);
                    Array.Copy(analysis.DataField, 3 + 32 + 32, imsi, 0, 32);
                    Array.Copy(analysis.DataField, 3 + 32 + 32 + 32, iccid, 0, 25);
                    meterName = ConvertUtil.NameBytesToString(name);
                    IMEI = ConvertUtil.IMEIBytesToString(imei);
                    IMSI = ConvertUtil.IMSIBytesToString(imsi);
                    ICCID = ConvertUtil.ICCIDBytesToString(iccid);
                    //start register use httprequest
                    if (IMEI == "" || IMSI == "" || ICCID == "")
                    {
                        //if imei empty ,send get onenet again
                        stateText.Text = "Mssing data,send a onenet command again.";
                        onenetDone = false;
                        serialPort.DiscardInBuffer();
                        if (!time.Enabled)
                        {
                            time.Enabled = true;
                            time.Start();
                        }
                        return false;
                    }
                    else if (IMSI.Length < 15)
                    {
                        MessageBox.Show("Need reboot circuit board!", "Firmware bug");
                        stateText.Text = "Please reboot circuit board, and try again.";
                        if (time.Enabled) { time.Stop(); }
                        onenetDone = false;
                        return false;
                    }
                    //got onenet parameter,stop time first time,else time will continue send command
                    if (time.Enabled)
                    {
                        time.Enabled = false;
                        time.Stop();
                    }
                    //stateText.Text = meterName + "\n" + IMEI + "\n" + IMSI + "\n" + ICCID;
                    stateText.Text = "Please check upload infomation.";
                    RegisterConfirm form = new RegisterConfirm();
                    form.Init(meterName, IMEI, IMSI, ICCID);
                    if (form.ShowDialog() != DialogResult.OK)
                    {
                        stateText.Text = "cancel register " + meterName;
                    }
                    else
                    {
                        stateText.Text = form.Message;
                    }
                    onenetDone = false;

                    //discard buffer,if not may be application crash
                    serialPort.DiscardInBuffer();
                    serialPort.Close();
                    checkBox1.Checked = false;
                    checkBox1.Text = portName + " closed";
                }
            }
            return false;
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            //time.Stop();
            stateText.Text = "sending!";
            //SendOnenet();
            byte[] commandOnenet = new byte[] { 0x68, 0x30, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x31, 0x02, 0x27, 0x0C, 0xF7, 0x16 };

            serialPort.Write(commandOnenet, 0, commandOnenet.Length);
            //throw new NotImplementedException();
        }

        public bool UnpackData(byte[] data)
        {
            return false;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();
                    checkBox1.Text = portName + " opened";
                    stateText.Text = "port: " + portName + " is opened";
                }
            }
            else
            {
                if (time.Enabled)
                {
                    time.Stop();
                }
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                serialPort.Close();
                checkBox1.Text = portName + " closed";
                stateText.Text = "port: " + portName + " is closed";
            }
        }

    }
}
