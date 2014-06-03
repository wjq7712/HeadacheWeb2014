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
        VisitDataOperation visitop = new VisitDataOperation();
        [OutputCache(Location=System.Web.UI.OutputCacheLocation.None)]
        public ActionResult Index(string ID)
        {
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
            List<int> nData = new List<int>();    
            nData= visitop.GetDiaryNumericData(obj.PID, obj.StartDate, obj.EndDate, obj.query1);
            List<DiaryDataPoint> qData = visitop.GetDiaryQualitativeData(obj.PID, obj.StartDate, obj.EndDate, obj.query2);
            for (int i = 0; i < nData.Count;i++ )
            {
                DiaryDataPoint nqdata = new DiaryDataPoint();
                nqdata.data = nData[i].ToString();
                nqdata.kind = i.ToString();
                qData.Add(nqdata);
            }
            string sJSON = JsonHelper.JsonSerializer(qData);
            return this.Json(sJSON);
        }
        public ActionResult ViewDiaryReport()
        {
            return PartialView("DiaryReportView");
        }
        public ActionResult ContinueDiagnosis(string ID)
        {
            string identity = ID + "%";
            identity = identity + this.TempData["recordID"].ToString();
            return RedirectToAction("ContinueVisit", "Diagnosis", new { identity = identity });
        }
        public class QueryCondition{
           public string PID;
           public DateTime StartDate;
           public DateTime EndDate;
           public string query1;
           public string query2;
        }
    }
}
