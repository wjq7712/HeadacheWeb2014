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

            List<string> query = new List<string>();
            query.Add(patname);
            query.Add(patsex);
            query.Add(date);
            query.Add(diagnosisresult);
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
