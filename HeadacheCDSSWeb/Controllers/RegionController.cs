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
        public ActionResult Query()
        {
            string patname = Request["name"];
            string patsex = Request["sex"];
            string date = Request["date"];
            string diagnosisresult = Request["diagnosis"];
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
            List<PatinfoForRe> patlistforre = new List<PatinfoForRe>();
            RegionViewData visitdata = new RegionViewData();
            var allpats = from s in DataContainer.PatBasicInforSet.ToList() select s;
            List<string> query = new List<string>();
            query.Add(patname);
            query.Add(patsex);
            query.Add(date);
            query.Add(diagnosisresult);
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
            return PartialView("PatlistForRe", patlistforre);   
        }
    }
}
