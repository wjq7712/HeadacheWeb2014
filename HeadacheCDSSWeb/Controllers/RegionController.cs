using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeadacheCDSSWeb.Models;
using System.Text.RegularExpressions;
using HeadacheCDSSWeb.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Data.Entity.Validation;

namespace HeadacheCDSSWeb.Controllers
{
    public class RegionController : Controller
    {
        //
        // GET: /Region/
        HeadacheModelContainer DataContainer = new HeadacheModelContainer();
        public ActionResult Index(string ID)
        {
            var userName = HttpContext.Request.Cookies["userName"].Value.ToString();
            var userID = HttpContext.Request.Cookies["userID"].Value.ToString();
            ViewBag.userName = userName;
            ViewBag.userID = userID;
            return View();
        }
        [HttpPost]
        public ActionResult addNewAccount(string userRole,string userName,string realName,string Password)
        {
            try
            {
                UserOperation uoperation = new UserOperation();
                var username = HttpContext.Request.Cookies["username"].Value.ToString();
                var userId = HttpContext.Request.Cookies["userID"].Value.ToString();
                int userID = Convert.ToInt16(userId);
                var name = userName;
                var duplicate = uoperation.duplicaionName(name);
                if (duplicate)
                {
                    var type = userRole;
                    if (type == "医生账号")
                    {
                        DoctorAccount daccount = new DoctorAccount();
                        daccount.UserName = userName;
                        daccount.PassWord = Password;
                        daccount.Hospital = realName;
                        daccount.RegionalCenterAccountID = userID;
                        daccount.ChiefDoctor = realName;
                        RegionalCenterAccount rca = new RegionalCenterAccount();//制定region账号
                        DataContainer.DoctorAccountSet.Add(daccount);
                        DataContainer.SaveChanges();
                    }
                    return this.Json(new { OK = true, Message = "添加成功" });
                }
                else
                {
                     ViewBag.message ="添加失败，该用户名已存在";
                     return this.Json(new { OK = false, Message = "添加失败，此用户名已存在" });
                }
            }
              catch (DbEntityValidationException dbEx)
            {
                var str = dbEx.ToString();
                return this.Json(new { OK = false, Message = str });
            }
           
        }
        public ActionResult deleteAccount(string targetId)
        {
            try
            {
                var id = int.Parse(targetId);
                var users = from s in DataContainer.DoctorAccountSet.ToList() select s;
                var user = users.Where(s => s.Id == id).FirstOrDefault();
                DataContainer.DoctorAccountSet.Remove(user);
                DataContainer.SaveChanges();
                return this.Json(new { OK = true, Message = "删除成功" });
            }
            catch (DbEntityValidationException dbEx)
            {
                return this.Json(new { OK = false, Message = dbEx.ToString() });
            }
        }
        public ActionResult changeAccount(string targetId, string userRole, string userName, string realName, string Password)
        {
            try
            {
                var id = int.Parse(targetId);
                var userId = HttpContext.Request.Cookies["userID"].Value.ToString();
                int userID = Convert.ToInt16(userId);
                DoctorAccount daccount = new DoctorAccount();
                daccount.Id = id;
                daccount.UserName = userName;
                daccount.PassWord = Password;
                daccount.Hospital = realName;
                daccount.RegionalCenterAccountID = userID;
                daccount.ChiefDoctor = realName;
                DataContainer.DoctorAccountSet.Add(daccount);
                DataContainer.Entry(daccount).State = System.Data.EntityState.Modified;
                DataContainer.SaveChanges();
                return this.Json(new { OK = true, Message = "修改成功" });
            }
            catch (DbEntityValidationException dbEx)
            {
                return this.Json(new { OK = false, Message = dbEx.ToString() });
            }
            
        }
        public ActionResult ListUsers(string userName)
        {
            var user = HttpContext.Request.Cookies["username"].Value.ToString();
            UserOperation uo = new UserOperation();
            List<userInfo> SelectedDocs = uo.SelectedDocs(userName);
            return Json(SelectedDocs, JsonRequestBehavior.AllowGet);  
        }
        public ActionResult ViewRecord(string ID)
        {
            var userType = HttpContext.Request.Cookies["userType"].Value.ToString();
            return RedirectToAction("Index", "ViewPatRecord", new { ID = ID,userTye=userType });
        }
        public ActionResult Query(string name,string sex,string date,string diagnosis)
        {
            string user = HttpContext.Request.Cookies["username"].Value.ToString();
            //找到region账号对应的医生列表。     
            UserOperation uo = new UserOperation();
            List<userInfo> SelectedDocs = uo.SelectedDocs(user);
            VisitDataOperation visitop = new VisitDataOperation();
            List<PatBasicInfor> Patlist = new List<PatBasicInfor>();
            List<tableData> patlistforre = new List<tableData>();
            RegionViewData regionViewData = new RegionViewData();
           
            var allpats = from s in DataContainer.PatBasicInforSet.ToList() select s;
            var allvisitRecord= from s in DataContainer.VisitRecordSet.ToList() select s;
            var docnum = SelectedDocs.Count;

            List<int> docIDS=new List<int> ();
            foreach(userInfo doc in SelectedDocs){
               docIDS.Add(doc.id);
            }
            var patlist=allpats.Where(p => docIDS.Contains(p.DoctorAccountId)).ToList();
            var patinfoList = (from ps in patlist.Where(p =>(string.IsNullOrEmpty(name) ? true : p.Name == name) && (string.IsNullOrEmpty(sex) ? true : p.Sex == sex))
                              from r in DataContainer.VisitRecordSet.ToList().Where(r => (r.PatBasicInforId == ps.Id) && 
                             (string.IsNullOrEmpty(diagnosis) ? true : (r.DiagnosisResult1.Contains(diagnosis) || r.DiagnosisResult2.Contains(diagnosis) || r.DiagnosisResult3.Contains(diagnosis)))
                              && (string.IsNullOrEmpty(date) ? true : r.VisitDate.Date== DateTime.Parse(date)))
                              select new
                              {
                                  Name = ps.Name,
                                  Sex = ps.Sex,
                                  Age = ps.Age,
                                  Date=r.VisitDate,
                                  DiagnosisResult1 = r.DiagnosisResult1,
                                  DiagnosisResult2 = r.DiagnosisResult2,
                                  DiagnosisResult3 = r.DiagnosisResult3,
                                  PatBasicInforId=ps.Id
                              }).OrderByDescending(x=>x.Date).DistinctBy(x=>x.PatBasicInforId).ToList();
            int i = 1;
            foreach (var patient in patinfoList)
            {
                tableData td = new tableData();
                td.Name = patient.Name;
                td.Sex = patient.Sex;
                td.Age = patient.Age;
                td.ListID = i.ToString();
                td.Date = patient.Date.ToString("yyyy-MM-dd");
                td.PatBasicInforId = patient.PatBasicInforId;
                if (patient.DiagnosisResult1 != null || patient.DiagnosisResult2 != null || patient.DiagnosisResult3 != null)
                {
                    if (patient.DiagnosisResult1.Contains("慢性每日头痛"))
                    {
                        var style = patient.DiagnosisResult1.Split(new Char[] { ':' });
                        if (style.Length > 1)
                        {
                            td.HeadacheStyle = style[1];
                        }
                        else
                        {
                            td.HeadacheStyle = patient.DiagnosisResult1 + patient.DiagnosisResult2 + patient.DiagnosisResult3;
                        }
                    }
                    else
                    {
                        td.HeadacheStyle = patient.DiagnosisResult1 + patient.DiagnosisResult2 + patient.DiagnosisResult3;
                    }
                }
                i++;
                patlistforre.Add(td);
            }

          /* int i,j;
           List<string> query = new List<string>();
           query.Add(name);
           query.Add(sex);
           query.Add(date);
           query.Add(diagnosis);
            for (i = 0; i < docnum; i++)
            {
                string docname = SelectedDocs[i].userName;
                query.Add(docname);
                var pts= visitop.GetPatforDoc(query);
                query.Remove(docname);
                var patnum = pts.Count;
                
                for (j = 0; j < patnum; j++)
                {
                    var patID=pts[j].Id ;
                    var selectedpat = allpats.Where(s => s.Id == patID).FirstOrDefault();
                    List<string> patientIds = new List<string>();
                    Patlist.Add(selectedpat);
                }
            }
            patlistforre = regionViewData.GetPatforView(Patlist);*/
            return Json(patlistforre, JsonRequestBehavior.AllowGet);   
           // return PartialView("PatlistForRe", patlistforre);
        }
    }
}
