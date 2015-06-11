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
    public class RegionController : Controller
    {
        //
        // GET: /Region/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewRecord(string ID)
        {
            return RedirectToAction("Index", "ViewPatRecord", new { ID = ID });
        }
        public ActionResult Query(string name,string sex,string date,string diagnosis)
        {
            string user = HttpContext.Request.Cookies["username"].Value.ToString();

            //找到region账号对应的医生列表，最好是从DAccountControler里调用，未实现。
            HeadacheModelContainer DataContainer = new HeadacheModelContainer();
            List<DoctorAccount> Docs = new List<DoctorAccount>();
            List<DoctorAccount> SelectedDocs = new List<DoctorAccount>();
            List<DoctorAccount> Unormaldoc = new List<DoctorAccount>();
            var docs = from s in DataContainer.DoctorAccountSet.ToList() select s;
            var RUsers = from s in DataContainer.RegionalCenterAccountSet.ToList() select s;
            var Ruser = RUsers.Where(s => s.UserName == user).FirstOrDefault();
            foreach (DoctorAccount doc in docs)
            {
                if (doc.RegionalCenterAccountID == Ruser.ID)
                {
                    SelectedDocs.Add(doc);
                }
                else
                {
                    Unormaldoc.Add(doc);
                }

            }
            
            VisitDataOperation visitop = new VisitDataOperation();
            List<PatBasicInfor> Patlist = new List<PatBasicInfor>();
            List<tableData> patlistforre = new List<tableData>();
            RegionViewData visitdata = new RegionViewData();
            var diaResult = "";//database mapping
            if (diagnosis!= "")
            {  //没整理完整，测试添加
                if (diagnosis == "很可能的偏头痛")
                { diaResult = "偏头痛:很可能的偏头痛"; }
                else if (diagnosis == "先兆性偏头痛")
                { diaResult = "偏头痛:先兆性偏头痛"; }
                else if (diagnosis == "无先兆性偏头痛")
                { diaResult = "偏头痛:无先兆性偏头痛"; }
                else if (diagnosis == "慢性偏头痛")
                { diaResult = "偏头痛:慢性偏头痛"; }

                else if (diagnosis == "很可能的紧张型头痛")
                { diaResult = "紧张型头痛:很可能的紧张型头痛"; }
                else if (diagnosis == "慢性紧张型头痛")
                { diaResult = "紧张型头痛:慢性紧张型头痛"; }
                else if (diagnosis == "偶尔发作性紧张型头痛")
                { diaResult = "紧张型头痛:偶尔发作性紧张型头痛"; }
                else if (diagnosis == "频繁阵发性紧张型头痛")
                { diaResult = "紧张型头痛:频繁阵发性紧张型头痛"; }

                else if (diagnosis == "丛集性头痛和其他三叉自主神经痛")
                { diaResult = "丛集性头痛和其他原发性三叉神经痛:丛集性头痛"; }
                else if (diagnosis == "很可能的丛集性头痛")
                { diaResult = "丛集性头痛和其他原发性三叉神经痛:很可能的丛集性头痛"; }
                else if (diagnosis == "阵发性偏侧头痛")
                { diaResult = "丛集性头痛和其他原发性三叉神经痛:阵发性偏侧头痛"; }
                else if (diagnosis == "很可能的阵发性偏侧头痛")
                { diaResult = "丛集性头痛和其他原发性三叉神经痛:很可能的阵发性偏侧头痛"; }
                else if (diagnosis == "SUNCT")
                { diaResult = "丛集性头痛和其他原发性三叉神经痛:SUNCT"; }
                else if (diagnosis == "很可能的SUNCT")
                { diaResult = "丛集性头痛和其他原发性三叉神经痛:很可能的SUNCT"; }

                else if (diagnosis == "新发每日持续性头痛")
                { diaResult = "慢性每日头痛:新发每日持续性头痛"; }
                else if (diagnosis == "药物滥用引起的头痛")
                { diaResult = "慢性每日头痛:药物滥用引起的头痛"; }

                else { diaResult = diagnosis; }
            }

            var allpats = from s in DataContainer.PatBasicInforSet.ToList() select s;
            List<string> query = new List<string>();
            query.Add(name);
            query.Add(sex);
            query.Add(date);
            query.Add(diaResult);
            var docnum = SelectedDocs.Count;
            int i,j;
            for (i = 0; i < docnum; i++)
            {
                string docname = SelectedDocs[i].UserName;
                query.Add(docname);
                var pts= visitop.GetPatforDoc(query);
                query.Remove(docname);
                var patnum = pts.Count;
                for (j = 0; j < patnum; j++)
                {
                    var patID=pts[j].Id ;
                    var selectedpat = allpats.Where(s => s.Id == patID).FirstOrDefault();
                    Patlist.Add(selectedpat);
                }
            }
            patlistforre = visitdata.GetPatforView(Patlist);
           return Json(patlistforre, JsonRequestBehavior.AllowGet);   
           // return PartialView("PatlistForRe", patlistforre);
        }
    }
}
