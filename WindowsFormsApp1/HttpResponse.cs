using System;

namespace WindowsFormsApp1
{
    [Serializable]
    public class HttpResponse<T>
    {
        public int returnCode { get; set; }

        public string returnMsg { get; set; }

        public T data { get; set; }
    }
}
