using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeadacheCDSSWeb.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.IO;
namespace HeadacheCDSSWeb.Controllers
{
    public class DiagnosisController : Controller
    {
        //
        // GET: /Diagnosis/
        VisitDataOperation vr = new VisitDataOperation();
     
        public ActionResult Index(string ID)
        {
            this.TempData["PatID"] = ID;
            ReportData RData = vr.ViewDetail(ID, "");
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string sJSON = JsonHelper.JsonSerializer(RData);
            ViewData["data"] = sJSON;
            return View();
        }
        public ActionResult ContinueVisit(string identity)
        {
            string[] IDs = identity.Split(new Char[] { '%','?' });
            this.TempData["PatID"] = IDs[0];
            this.TempData["ContinueVisitID"] = IDs[1];
           ReportData  RData= vr.ViewDetail(IDs[0], IDs[1]);
           System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
           string sJSON = JsonHelper.JsonSerializer(RData);
           ViewData["data"] = sJSON;
           return View();
          //  return View(RData);
        }
        [HttpPost]
        public JsonResult Save()
        {
            
            string jsonStr = Request.Params["postjson"];
            string PatID = this.TempData["PatID"].ToString();
            bool res;

            try
            {
                VisitData obj = JsonConvert.DeserializeObject<VisitData>(jsonStr);//反序列化成指定对象  
                 res=vr.SaveRecord(PatID, obj);
                  
                
            }
            catch (Exception e)
            {
                return this.Json(new { OK = false, Message = "保存失败" });
            }
            //加一个判断，返回的是true or false,现在是return false还是保存成功的
            if (res == false)
            {
                return this.Json(new { OK = false, Message = "保存失败" });
            }
            return this.Json(new { OK = true, Message ="保存成功" });
        }
        [HttpPost]
        public JsonResult Update()
        {

            string jsonStr = Request.Params["postjson"];
            string PatID = this.TempData["PatID"].ToString();

            try
            {
                VisitData obj = JsonConvert.DeserializeObject<VisitData>(jsonStr);
                if (this.TempData["ContinueVisitID"] != null)
                {
                    string VisitID = this.TempData["ContinueVisitID"].ToString();
                    vr.UpdateRecord(PatID, VisitID, obj);
                }
            }
            catch (Exception e)            {
                return this.Json(new { OK = false, Message = "保存失败" });
            }
           
            return this.Json(new { OK = true, Message = "保存成功" });
        }
        [HttpPost]
        public JsonResult CDSSdiagnosis()
        {
            string strResult = null;
            string drugResult = null;
            try{
                string jsonStr = Request.Params["postjson"];
                VisitData obj = JsonConvert.DeserializeObject<VisitData>(jsonStr);//jsonStr.FromJsonTo<VisitData>();
                HeadacheDiagnosis HDiagnosis = new HeadacheDiagnosis();
                strResult = HDiagnosis.GetDiagnosis(obj);
                drugResult = HDiagnosis.DrugInfor(obj);
            }
            catch (Exception e)
            {
                return this.Json(new { OK = false, Message = e.Message + "推理出错" });
            }
            //strResult = "123";
            if (!strResult.Contains("必填项"))
            {
                if (drugResult == "")
                {
                    if (strResult.Length < 20)
                        strResult = "\n" + "                          " + strResult;
                    return this.Json(new { OK = true, Message = strResult });
                }
                else
                {
                    return this.Json(new { OK = false, Message = drugResult });
                }
            }
            else
            {
                return this.Json(new { OK = false, Message = strResult });
            }
            
         }
        public ActionResult GetHPlace()
        {
            return PartialView("PatHeadachePlace");
        }

        public ActionResult Push()
        {
            return View();
        }
    }
}
