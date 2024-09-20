using System;

namespace WindowsFormsApp1
{
    [Serializable]
    public class NBDeviceInfo
    {
        public string batchNo { get; set; }

        public string deviceCode { get; set; }

        public string imei { get; set; }

        public string imsi { get; set; }

        public string simId { get; set; }

        public string protocol { get; set; }

        public string commMode { get; set; }

        public string returnCode { get; set; }

        public string returnMsg { get; set; }

        public string Result { get; set; }

        public string planId { get; set; }

        public string targetAppId { get; set; }
    }
}
