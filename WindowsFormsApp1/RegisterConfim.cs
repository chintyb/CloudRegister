using System.Linq;
using System.Net;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public partial class RegisterConfirm : Form
    {
        private string meterName;
        private string IMEI;
        private string IMSI;
        private string ICCID;
        private static bool Offlinemode = true;
        private static string returnMsg;
        private static string batchNo = "";
        private static string selectedProtocalValue = "";
        private static string selectedCommModeValue = "";
        private static string selectedPlanValue = "";
        private static Dictionary<string, string> dicProtocal = new Dictionary<string, string>();
        private static Dictionary<string, string> dicCommMode = new Dictionary<string, string>();
        private static Dictionary<string, string> dicPlanId = new Dictionary<string, string>();

        public string Message { get { return returnMsg; } }
        public RegisterConfirm()
        {
            InitializeComponent();
            if (dicProtocal.Count == 0)
            {
                dicProtocal.Add("0", "NB表正泰协议");
                dicProtocal.Add("1", "NB表昆仑协议");
                dicProtocal.Add("2", "NB表港华协议");
                dicProtocal.Add("3", "NB表南昌协议");
                dicProtocal.Add("4", "NB表南京港华协议");
                dicProtocal.Add("5", "NB杭天工商业表协议");
                dicProtocal.Add("6", "NB杭天民用表协议");
                dicProtocal.Add("7", "NB宁波兴光协议");
                dicProtocal.Add("8", "NB华润协议");
                dicProtocal.Add("9", "NB港华超声波协议");
                dicProtocal.Add("11", "NB山东东营黄河协议");
                dicProtocal.Add("12", "NB常熟协议");
                dicProtocal.Add("20", "NB昆仑超声波协议");
                dicProtocal.Add("21", "商用NB流量计");
                dicProtocal.Add("22", "NB广安爱众协议");
                dicProtocal.Add("31", "NB表正泰协议-工商业表AES");
                dicProtocal.Add("32", "NB表正泰协议-民用表AES");
                dicProtocal.Add("70", "NB海南民生协议");
                dicProtocal.Add("71", "NB河南平顶山");
                dicProtocal.Add("72", "NB中久协议");
                dicProtocal.Add("73", "NB柯桥燃气协议");
                dicProtocal.Add("80", "阀门井HW");
                dicProtocal.Add("81", "井盖HW");
                dicProtocal.Add("82", "家用报警器HW");
                dicProtocal.Add("121", "NB青岛泰能协议");
            }
            foreach (string s in dicProtocal.Values)
            {
                comboBox1.Items.Add(s);
            }

            if (dicCommMode.Count == 0)
            {
                dicCommMode.Add("4", "NB-IOT(华为云)");
                dicCommMode.Add("5", "NB-IOT(电信云)");
                dicCommMode.Add("6", "NB-IOT(移动云)");
                dicCommMode.Add("7", "NB-IOT(电信云AEP插件模式)");
            }
            foreach (string s in dicCommMode.Values)
            {
                comboBox2.Items.Add(s);
            }

            if (dicPlanId.Count == 0)
            {
                HttpWebRequest httpWebRequest = NBIotHttp.CreateHttpWebRequestGet("http://10.5.7.226:8004/GIMS/mis/getBatchNoParam.do");
                HttpResponse<GetPlanInfo> res = NBIotHttp.ReadFromResponse<HttpResponse<GetPlanInfo>>(httpWebRequest);
                for (int i = 0; i < res.data.planList.Length; i++)
                {
                    dicPlanId.Add(res.data.planList[i].planId, res.data.planList[i].planName);
                }
            }
            foreach (string s in dicPlanId.Values)
            {
                comboBox3.Items.Add(s);
            }
        }

        public void Init(string strMeterName, string strIMEI, string strIMSI, string strICCID)
        {
            //batchNo = "";
            meterName = strMeterName;
            IMEI = strIMEI;
            IMSI = strIMSI;
            ICCID = strICCID;

            textBox1.Text = batchNo;
            textBox2.Text = meterName;
            textBox3.Text = IMEI;
            textBox4.Text = IMSI;
            textBox5.Text = ICCID;

            if (selectedProtocalValue.Length > 0) comboBox1.SelectedItem = selectedProtocalValue;
            if (selectedCommModeValue.Length > 0) comboBox2.SelectedItem = selectedCommModeValue;
            if (selectedPlanValue.Length > 0) comboBox3.SelectedItem = selectedPlanValue;
            if(Offlinemode)
            {
                Offline.Checked = true;
            }
            else
            {
                Online.Checked = true;
            }
        }

        private void Ok_click(object sender, EventArgs e)
        {
            batchNo = textBox1.Text;
            if (batchNo.Length < 8)
            {
                MessageBox.Show("The length of batchNo must long thna 8!");
                return;
            }

            selectedProtocalValue = comboBox1.SelectedItem.ToString();
            selectedCommModeValue = comboBox2.SelectedItem.ToString();
            selectedPlanValue = comboBox3.SelectedItem.ToString();
            //bool hasEquaValue = false;
            //foreach(string s in dicProtocal.Values)
            //{
            //    if (s == selectedProtocalValue) hasEquaValue = true;
            //}
            //if (!hasEquaValue)
            //{
            //    MessageBox.Show("protocal error!");
            //    return;
            //}
            //hasEquaValue = false;
            //foreach (string s in dicCommMode.Values)
            //{
            //    if (s == selectedCommModeValue) hasEquaValue = true;
            //}
            //if (!hasEquaValue)
            //{
            //    MessageBox.Show("commMode error!");
            //    return;
            //}
            //hasEquaValue = false;
            //foreach (string s in dicPlanId.Values)
            //{
            //    if (s == selectedPlanValue) hasEquaValue = true;
            //}
            //if (!hasEquaValue)
            //{
            //    MessageBox.Show("PlanId error!");
            //    return;
            //}
            //string key;
            string proto = "", mode = "", plan = "";
            foreach (string key in dicProtocal.Keys)
            {
                if (dicProtocal[key] == selectedProtocalValue) proto = key;
            }
            foreach (string key in dicCommMode.Keys)
            {
                if (dicCommMode[key] == selectedCommModeValue) mode = key;
            }
            foreach (string key in dicPlanId.Keys)
            {
                if (dicPlanId[key] == selectedPlanValue) plan = key;
            }
            //offline mode 
            if (Offlinemode)
            {
                //Append register plan function
                //web address http://10.5.7.226:8004/GIMS/checkuser.do
                //content-type:application/x-www-form-urlencoded
                //userno:"user name"
                //password:"password"
                //clientip:"ip or an empty string"
                //processorid:"/"
                HttpWebRequest webRequest = NBIotHttpOffline.CreateHttpWebRequestPost("http://10.5.7.226:8004/GIMS/checkuser.do");
                if (NBIotHttpOffline.Login(webRequest))
                {
                    //login success,begin upload
                    HttpWebRequest requestImport = NBIotHttpOffline.CreateHttpWebRequestPost("http://10.5.7.226:8004/GIMS/mis/importSingle.do");
                    requestImport.CookieContainer = NBIotHttpOffline.cookies;
                    Dictionary<string, string> device = new Dictionary<string, string>
                    {
                        {"deviceCode" , meterName },
                        {"imei" , IMEI },
                        {"imsi" , IMSI },
                        {"simId" , ICCID },
                        {"batchNo" , RegisterConfirm.batchNo },
                        {"protocol" , proto },
                        {"commMode" , mode },
                        {"createDate" , DateTime.Now.ToString() }
                    };
            
                    NBIotHttpOffline.WriteToRequest(requestImport, device);
                    HttpResponseImport httpImportResponse = NBIotHttp.ReadFromResponse<HttpResponseImport>(requestImport);
                    if(httpImportResponse.status == 0)
                    {
                        returnMsg = "register success!";
                    }
                    else
                    {
                        returnMsg = httpImportResponse.msg;
                    }

                    //Append register plan function
                    //web address http://10.5.7.226:8004/GIMS/mis/modifyDevice.do
                    //content-type:application/x-www-form-urlencoded
                    //operation = 1:delete =2:set plan
                    //deviceCode:meterNumber
                    //planId:The identifire of plan
                    HttpWebRequest planRequest = NBIotHttpOffline.CreateHttpWebRequestPost("http://10.5.7.226:8004/GIMS/mis/modifyDevice.do");
                    planRequest.CookieContainer = NBIotHttpOffline.cookies;
                    NBIotHttpOffline.WriteToRequest(planRequest, new Dictionary<string,string>
                    {
                        { "operation" , "2" },
                        { "deviceCode" , meterName },
                        { "planId" , plan }
                    });
                    HttpResponseModifyDevice httpResponseModifyDevice =  NBIotHttp.ReadFromResponse<HttpResponseModifyDevice>(planRequest);
                    if(httpResponseModifyDevice.status == 0)
                    {
                        returnMsg += $" plan is {plan}";
                    }
                }
                else
                {
                    returnMsg = "sign in mis failed!";
                }
                
                DialogResult = DialogResult.OK;
                return;
            }

            //online mode
            HttpWebRequest httpWebRequest = NBIotHttp.CreateHttpWebRequestPost("http://10.5.7.226:8004/GIMS/mis/singleIMEIData.do");
            NBIotHttp.WriteToRequest(httpWebRequest, new
            {
                deviceCode = meterName,
                imei = IMEI,
                imsi = IMSI,
                simId = ICCID,
                msg = "",
                batchNo = RegisterConfirm.batchNo,
                protocol = proto,
                commMode = mode,
                planId = plan,
                targetAppId = "no-targetAppId"
            });
            HttpResponse<NBDeviceInfo> httpResponse = NBIotHttp.ReadFromResponse<HttpResponse<NBDeviceInfo>>(httpWebRequest);

            if (httpResponse.returnCode == 0)
            {
                returnMsg = "register success!";
            }
            else
            {
                returnMsg = "register error,error is: " + httpResponse.returnMsg;
            }
            DialogResult = DialogResult.OK;

            //begin register to platform

        }

        private void Ok_protocalChange(object sender, EventArgs e)
        {
            selectedProtocalValue = comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedCommModeValue = comboBox2.SelectedItem.ToString();
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedPlanValue = comboBox3.SelectedItem.ToString();
        }

        private void Offline_CheckedChanged(object sender, EventArgs e)
        {
            if (Offline.Checked)
            {
                Offlinemode = true;
            }
        }

        private void Online_CheckedChanged(object sender, EventArgs e)
        {
            if (Online.Checked)
            {
                Offlinemode = false;
            }
        }
    }
}
