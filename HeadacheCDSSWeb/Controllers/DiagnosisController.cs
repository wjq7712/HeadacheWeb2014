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
            ViewData["id"] = ID;
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
           ViewData["id"] = IDs[0];
           ViewData["visitId"] = IDs[1];
           return View();
          //  return View(RData);
        }
        [HttpPost]
        public JsonResult Save()
        {            
            string jsonStr = Request.Params["postjson"];
             string VisitID = Request.Params["VisitId"];
            string PatID = this.TempData["PatID"].ToString();
            bool res;
            try
            {
                VisitData obj = JsonConvert.DeserializeObject<VisitData>(jsonStr);//反序列化成指定对象  
               //  res=vr.SaveRecord(PatID, obj);
                res = vr.UpdateRecord(PatID, VisitID, obj);
     
                
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
          //  string PatID = Request.Params["patId"];
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
            string completeResult = null;
            string drugResult = null;
            string cdssResult = null;
            string strSecond = null;
            string vid = null;
            string PatID = Request.Params["patId"];
            string visitID = Request.Params["visitId"];
            VisitData obj = new VisitData();
            HeadacheDiagnosis HDiagnosis = new HeadacheDiagnosis();

                string jsonStr = Request.Params["postjson"];
                obj = JsonConvert.DeserializeObject<VisitData>(jsonStr);//jsonStr.FromJsonTo<VisitData>();
                strSecond = HDiagnosis.secondaryScreen(obj);
                completeResult = HDiagnosis.completeTest(obj);
                drugResult = HDiagnosis.DrugInfor(obj);
                if (strSecond == "")//排除继发性
                {
                    if (!completeResult.Contains("必填项"))
                    {
                        if (drugResult == "")
                        {
                            //if (completeResult.Length < 20)
                            //    completeResult = "\n" + "                          " + completeResult;
                            if (visitID != null)
                            {
                                bool updateResult = vr.UpdateRecord(PatID, visitID, obj);
                                vid = visitID;
                            }
                            else
                            {
                                bool res = vr.SaveRecord(PatID, obj);//在点击下一步进行推理之前先判断数据完整性，再保存，最后推理（20140814），后面的保存按钮保存前面未存的辅助诊断结果和医嘱信息
                                vid = obj.visitrecord.Id.ToString();
                            }
                            try
                            {
                                cdssResult = HDiagnosis.GetDiagnosis(obj);
                                if (cdssResult.Length < 20)
                                {
                                    cdssResult = "\n" + "                          " + cdssResult;
                                }
                            }
                            catch (Exception e)
                            {
                                return this.Json(new { OK = false, Message = e.Message + "推理出错" });
                            }
                            return this.Json(new { OK = true, Message = cdssResult, VisitID = vid });
                        }
                        else
                        {
                            return this.Json(new { OK = false, Message = drugResult });
                        }
                    }
                    else
                    {
                        return this.Json(new { OK = false, Message = completeResult });
                    }
                }
                else 
                {
                    if (visitID != null)
                    {
                        bool updateResult = vr.UpdateRecord(PatID, visitID, obj);
                        vid = visitID;
                    }
                    else
                    {
                        bool res = vr.SaveRecord(PatID, obj);
                        vid = obj.visitrecord.Id.ToString();
                    }
                    return this.Json(new { OK = true, Message = strSecond, VisitID = vid }); 
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
