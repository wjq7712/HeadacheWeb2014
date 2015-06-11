using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeadacheCDSSWeb.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace HeadacheCDSSWeb.Controllers
{
    public class ViewPatRecordController : Controller
    {
        //
        // GET: /ViewPatRecord/
        HeadacheModelContainer context = new HeadacheModelContainer();
        VisitDataOperation visitop = new VisitDataOperation();
        [OutputCache(Location=System.Web.UI.OutputCacheLocation.None)]
        public ActionResult Index(string ID)
        {
            string userName = HttpContext.Request.Cookies["username"].Value.ToString();
            this.ViewBag.UserName = userName;
            this.TempData["PatID"] = ID;
            this.ViewBag.patId = ID;
            List<VisitRecord> Lvisit = visitop.GetVistRecord(ID);
            if (Lvisit.Count != 0)
            {
                this.TempData["recordID"] = Lvisit.First().Id;
                this.ViewBag.recordId = Lvisit.First().Id;
            }
            return View(Lvisit);
        }
        public ActionResult ViewVisitRecordDetail(List<string> PostID)
        {
            try
            {
                string PatID = PostID[0];
                string VisitID = PostID[1];
                this.TempData["recordID"] = VisitID.ToString();
                ReportData Rdata = visitop.ViewDetail(PatID, VisitID);
                System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                string sJSON = oSerializer.Serialize(Rdata);
                return Json(sJSON, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception e)
            {
                return null;
            }
           
        }
        public ActionResult GoToDiagnosis(string ID)
        {
            return RedirectToAction("Index", "Diagnosis", new { ID = ID });
        }
        public ActionResult SendAdvice(string id,string strAdvice)
        {
            VisitDataOperation dataOperation = new VisitDataOperation();
            var correctPatient=from p in context.PatBasicInforSet.ToList() where p.Id==id select p;
            if (correctPatient != null)
            {
                string clientID = correctPatient.First().PushClientId;
                if (clientID != null)
                {
                    bool saveResult = dataOperation.SaveAdvice(id, strAdvice);
                    if (saveResult == true)
                    {
                        Push pushAdvice = new Push();
                        string pushResult = pushAdvice.PushAdvice(strAdvice, clientID);
                        PushReturn pushReturnInfo = JsonConvert.DeserializeObject<PushReturn>(pushResult);
                        if (pushReturnInfo.result == "ok")
                        {
                            return this.Json(new { OK = true, Message = id });
                        }
                        else
                        {
                            return this.Json(new { OK = true, Message = pushReturnInfo.result });
                        }
                    }
                    else
                    {
                        return this.Json(new { OK = false, Message = "保存失败" });
                    }
                }
                else
                {
                    return this.Json(new { OK = false, Message = "该用户尚未使用移动端" });
                }

            }
            else { return this.Json(new { OK = false, Message = "没有找到对应的病人" }); }
            }
        public ActionResult HistoryAdvice(string PatID)
        {
            List<DocSuggestionSet> adviceList=new List<DocSuggestionSet> ();
            var advice = from p in context.DocSuggestionSet.ToList() where p.PatBasicInforId == PatID select p;
            if (advice != null)
            {
                foreach (DocSuggestionSet docS in advice)
                {
                    if (docS.Suggestion != "")
                    { adviceList.Add(docS); }
                }
            }
            return PartialView("AdviceList", adviceList);
        }
        public ActionResult DeleteRecord(string ID)
        {
            string PatID = ID;
            string RecordID = this.TempData["recordID"].ToString();
            try
            {
                visitop.DeleteRecord(PatID, RecordID);
            }
            catch (Exception e)
            {
                return this.Json(new { OK = false, Message = "删除失败" });
            }

            return this.Json(new { OK = true, Message = RecordID });
        }
        public ActionResult ViewDiary()
        {
            string jsonStr = Request.Params["postjson"];
            QueryCondition obj = JsonConvert.DeserializeObject<QueryCondition>(jsonStr);
            List<DiaryDateNum> nData = new List<DiaryDateNum>();    
            nData= visitop.GetDiaryNumericData(obj.PID, obj.StartDate, obj.EndDate, obj.query1);//图1头痛时长程度数
            List<DiaryDataPoint> qData = visitop.GetDiaryQualitativeData(obj.PID, obj.StartDate, obj.EndDate, obj.query2);//图2头痛性质数据
            DiaryDataPoint seperatesignal = new DiaryDataPoint();
            List<DiaryDataPoint> ChineseData = visitop.explanable(obj.query2, qData);
            seperatesignal.data = 0;
            seperatesignal.kind = "0";
            qData.Add(seperatesignal);
            for (int i = 0; i < nData.Count;i++ )
            {
                DiaryDataPoint nqdata = new DiaryDataPoint(); 
                nqdata.data = nData[i].headacheNum;
                nqdata.kind = nData[i].headacheDate;
                qData.Add(nqdata);
            }
            string sJSON = JsonHelper.JsonSerializer(qData);
            return this.Json(sJSON);
        }
        public ActionResult ViewDiaryReport(string PatID)
        {
           // return PartialView("DiaryReportView");
            var pid = PatID;  
            DiaryDataReport ddr = new DiaryDataReport();
            var diary = from s in context.HeadacheDiarySet.ToList() where (s.PatBasicInforId == pid) select s;
            var lastdiaryDate = DateTime.Now.Date;
            var firstdiaryDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddMonths(-3);//3个月前
            var threeMonthData = from p in diary.ToList() where (p.StartTime < lastdiaryDate && p.StartTime > firstdiaryDate) select p; //3个月的头痛数据
            var recordCount = threeMonthData.Count();
            var headFrequency = 0;
            if (recordCount != 0)
            {
                headFrequency = 90 / recordCount;
            }
            List<DiaryDateNum> nData = new List<DiaryDateNum>();
           
            nData = visitop.GetDiaryNumericData(pid, firstdiaryDate, lastdiaryDate, "头痛程度");//头痛程度数据，返回的是数组，需要对数组数据求均值[5,5,9]
            double averageDegree = 0;
            if (nData.Count() != 0)
            {
                double sum = 0;
                for (int i = 0; i < nData.Count; i++)
                {
                    sum += nData[i].headacheNum;
                }
                 averageDegree = sum / nData.Count();
            }
            else { averageDegree = 0; }

            nData = visitop.GetDiaryNumericData(pid, firstdiaryDate, lastdiaryDate, "头痛时长");
            double averageTime = 0;
            if (nData.Count() != 0)
            {
                double sum = 0;
                for (int i = 0; i < nData.Count; i++)
                {
                    sum += nData[i].headacheNum;
                }
                averageTime = sum / nData.Count();
            }
            else { averageTime = 0; }

            var  days = Math.Floor(averageTime / 24);
            var hours = Math.Floor(averageTime);
            var minutes = (averageTime-hours)*60;

            List<DiaryDataPoint> typeData = visitop.GetDiaryQualitativeData(pid, firstdiaryDate, lastdiaryDate, "头痛性质");//图2中国头痛性质数据[3,紧张型]
            string str1 = visitop.explan("头痛性质", typeData);
             List<DiaryDataPoint> accompData = visitop.GetDiaryQualitativeData(pid, firstdiaryDate, lastdiaryDate, "伴随症状");
            string str2 = visitop.explan("伴随症状", accompData);
            List<DiaryDataPoint> placeData = visitop.GetDiaryQualitativeData(pid, firstdiaryDate, lastdiaryDate, "头痛部位");
            string str3 = visitop.explan( "头痛部位",placeData);
            List<DiaryDataPoint> prodromeData = visitop.GetDiaryQualitativeData(pid, firstdiaryDate, lastdiaryDate, "头痛先兆");
            string str4 = visitop.explan("头痛先兆",prodromeData);
            List<DiaryDataPoint> prcipData = visitop.GetDiaryQualitativeData(pid, firstdiaryDate, lastdiaryDate, "诱发因素");
            string str5 = visitop.explan("诱发因素",prcipData);
            List<DiaryDataPoint> mitigatData = visitop.GetDiaryQualitativeData(pid, firstdiaryDate, lastdiaryDate, "缓解因素");
            string str6 = visitop.explan("缓解因素",mitigatData);
             List<DiaryDataPoint> aroundeye = visitop.GetDiaryQualitativeData(pid, firstdiaryDate, lastdiaryDate, "眼眶周围");
            string str7 = visitop.explan("眼眶周围", aroundeye);
            List<DiaryDataPoint> IfActivityAggravate = visitop.GetDiaryQualitativeData(pid, firstdiaryDate, lastdiaryDate, "运动加剧");
            string str8 = visitop.explan("运动加剧", IfActivityAggravate);
            //List<DiaryDataPoint> AidDiagnosis = visitop.GetDiaryQualitativeData(pid, firstdiaryDate, lastdiaryDate, "诊断结论");
            //string str9 = visitop.explan("诊断结论", AidDiagnosis);



            ddr.HDRdata = firstdiaryDate.ToShortDateString() + "--" + lastdiaryDate.ToShortDateString();
            ddr.HDRdegree = "平均值" + averageDegree.ToString("0.0");
            ddr.HDRfrequence = "平均值：" + headFrequency.ToString("0.0") + "天一次";
            ddr.HDRtype = str1; ;
            ddr.HDRplace = str3;
            ddr.HDRprodrome = str4;
            ddr.HDRacompanion = str2;
            ddr.HDRprecipitatingFactor = str5;
            ddr.HDRmitigatingFactors = str6;
            ddr.HDRtimes = recordCount.ToString();
            //ddr.AidDiagnosis = str9;
            if (days == 0)
            {
                if (hours == 0)
                { ddr.AverageTime = minutes.ToString() + "分钟"; }
                else { ddr.AverageTime = hours.ToString() + "小时" + minutes.ToString("0") + "分钟"; }
            }
            else { ddr.AverageTime =days.ToString()+"天"+ hours.ToString() + "小时" + minutes.ToString("0") + "分钟"; }
           
            ddr.IfActivityAggravate = str8;
            ddr.IfAroundEye = str7;
            return Json(ddr, JsonRequestBehavior.AllowGet);
          // string sJSON = JsonHelper.JsonSerializer(ddr);
          //  return this.Json(sJSON);
        }
        public ActionResult ContinueDiagnosis(string ID)
        {
            string identity = ID + "%";
            identity = identity + this.TempData["recordID"].ToString();
            return RedirectToAction("ContinueVisit", "Diagnosis", new { identity = identity });
        }

        public ActionResult returnSearch(string UserName) {
            try
            {
                var Users = from s in context.RegionalCenterAccountSet.ToList() select s;
                var user = Users.Where(s => s.UserName == UserName).FirstOrDefault();
                if (user != null)
                {
                    return this.Json(new { OK = true, Message = "region" });
                }
                else
                {
                    return this.Json(new { OK = true, Message = "doctor" });
                }
            }
            catch (System.Exception ex)
            {
                return this.Json(new { OK = false, Message = ex.Message });
            }
        }
        public class QueryCondition{
           public string PID;
           public DateTime StartDate;
           public DateTime EndDate;
           public string query1;
           public string query2;
        }
        public class PushReturn
        {
            public string taskId { get; set; }
            public string result { get; set; }
            public string status { get; set; }

        }
    }
}
