using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeadacheCDSSWeb.Models
{
    public class DiaryDataPoint
    {
        public string kind { get; set; }
        public double data { get; set; }
    }
    public class DiaryDataReport
    {
        public string HDRdata { get; set;}
        public string HDRfrequence{ get; set; }
        public string HDRdegree{ get; set; }
        public string HDRtype{ get; set; }
        public string HDRplace{ get; set; }
        public string HDRprodrome{ get; set; }
        public string HDRacompanion{ get; set; }
        public string HDRprecipitatingFactor{ get; set; }
        public string HDRmitigatingFactors{ get; set; }
        public string HDRtimes{ get; set; }
        public string AidDiagnosis {get;set;}
        public string IfActivityAggravate {get;set;}
        public string IfAroundEye { get; set; }
        public string AverageTime{get;set;}
    }
    public class DiaryDateNum
    {
        public string headacheDate { get; set; }
        public double headacheNum { get; set; }
    }
}