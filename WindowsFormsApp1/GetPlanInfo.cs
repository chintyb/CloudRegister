using System;

namespace WindowsFormsApp1
{
    [Serializable]
    public class GetPlanInfo
    {
        public GetPlanInfoResponseApplist[] appList { get; set; }

        public GetPlanInfoResponsePlanlist[] planList { get; set; }
    }
}
