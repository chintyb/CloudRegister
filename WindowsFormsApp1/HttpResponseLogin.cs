using System;

namespace WindowsFormsApp1
{
    [Serializable]
    public class HttpResponseLogin
    {
        public string msg { get; set; }
        public bool success { get; set; }
        //public T data { get; set; }
    }
}
