using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeadacheCDSSWeb.Models;
using System.Text.RegularExpressions;
using HeadacheCDSSWeb.Filters;
namespace HeadacheCDSSWeb.Controllers
{
    public class EnterPatInforController : Controller
    {
        //
        // GET: /EnterPatientInfor/
 
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(PatBasicInfor pat)
        {

            PatOperation pto = new PatOperation();

            string PID = Request.Form["门诊号"];
            if (string.IsNullOrEmpty(pat.Name) || string.IsNullOrEmpty(pat.Sex) || string.IsNullOrEmpty(pat.Age) || string.IsNullOrEmpty(pat.Phone))
            {
                ModelState.AddModelError("", "带*的输入项不能为空");
            }
            else
            {
                Regex reg = new Regex("^[0-9]+$");
                Match ma1 = reg.Match(pat.Age); //在指定的输入字符串中搜索 Regex 构造函数中指定的正则表达式的第一个匹配项。//
                Match ma2 = reg.Match(pat.Phone);
                if (ma1.Success && ma2.Success)
                {
                }
                else
                {
                    ModelState.AddModelError("", "手机和年龄必须为数字");
                }
            }
            if (ModelState.IsValid)
            {
                string user;
                user = HttpContext.Request.Cookies["username"].Value.ToString();
                pto.InsertPat(pat, PID, user);
                return RedirectToAction("Index", "Diagnosis", new { ID = pat.Id });
            }
            else
            {
                return View();
            }
        }
        public ActionResult ViewRecord(string ID)
        {
            return RedirectToAction("Index", "ViewPatRecord", new { ID = ID });
        }
        public ActionResult Query()
        {

            string patname = Request["name"];
            string patsex = Request["sex"];
            string date = Request["date"];
            string diagnosisresult = Request["diagnosis"];
            string user = HttpContext.Request.Cookies["username"].Value.ToString();
            var diaResult="";
            if (diagnosisresult!= "")
            {  //没整理完整，测试添加
                if (diagnosisresult == "很可能的偏头痛")
                { diaResult = "偏头痛:很可能的偏头痛"; }
                else if (diagnosisresult == "先兆性偏头痛")
                { diaResult = "偏头痛:先兆性偏头痛"; }
                else if (diagnosisresult == "无先兆性偏头痛")
                { diaResult = "偏头痛:无先兆性偏头痛"; }
                else if (diagnosisresult == "慢性偏头痛")
                { diaResult = "偏头痛:慢性偏头痛"; }

                else if (diagnosisresult == "很可能的紧张型头痛")
                { diaResult = "紧张型头痛:很可能的紧张型头痛"; }
                else if (diagnosisresult == "慢性紧张型头痛")
                { diaResult = "紧张型头痛:慢性紧张型头痛"; }
                else if (diagnosisresult == "偶尔发作性紧张型头痛")
                { diaResult = "紧张型头痛:偶尔发作性紧张型头痛"; }
                else if (diagnosisresult == "频繁阵发性紧张型头痛")
                { diaResult = "紧张型头痛:频繁阵发性紧张型头痛"; }

                else if (diagnosisresult == "丛集性头痛")
                { diaResult = "丛集性头痛和其他原发性三叉神经痛:丛集性头痛"; }
                else if (diagnosisresult == "很可能的丛集性头痛")
                { diaResult = "丛集性头痛和其他原发性三叉神经痛:很可能的丛集性头痛"; }
                else if (diagnosisresult == "阵发性偏侧头痛")
                { diaResult = "丛集性头痛和其他原发性三叉神经痛:阵发性偏侧头痛"; }
                else if (diagnosisresult == "很可能的阵发性偏侧头痛")
                { diaResult = "丛集性头痛和其他原发性三叉神经痛:很可能的阵发性偏侧头痛"; }
                else if (diagnosisresult == "SUNCT")
                { diaResult = "丛集性头痛和其他原发性三叉神经痛:SUNCT"; }
                else if (diagnosisresult == "很可能的SUNCT")
                { diaResult = "丛集性头痛和其他原发性三叉神经痛:很可能的SUNCT"; }

                else if (diagnosisresult == "新发每日持续性头痛")
                { diaResult = "慢性每日头痛:新发每日持续性头痛"; }
                else if (diagnosisresult == "药物滥用引起的头痛")
                { diaResult = "慢性每日头痛:药物滥用引起的头痛"; }

                else { diaResult = diagnosisresult; }
            }
            List<string> query = new List<string>();
            query.Add(patname);
            query.Add(patsex);
            query.Add(date);
            query.Add(diaResult);
            query.Add(user);
            VisitDataOperation visitop = new VisitDataOperation();
            List<PatBasicInfor> pts = visitop.GetPatforDoc(query);
            return PartialView("PatList", pts);
        }

      
        PatOperation PO = new PatOperation();
        public ActionResult DeletePatient(string ID){
            string PatID = ID;
           try
             {
                 PO.DeletePat(PatID);
            }
            catch (Exception e)
            {
                return this.Json(new { OK = false, Message = "删除失败" });
            }

            return this.Json(new { OK = true, Message = "删除成功" });
        }
    }
}
