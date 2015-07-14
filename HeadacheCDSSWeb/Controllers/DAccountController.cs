using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeadacheCDSSWeb.Models;
namespace HeadacheCDSSWeb.Controllers
{
    public class DAccountController : Controller
    {
        //
        // GET: /DAccount/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]       
        public ActionResult Index(DoctorAccount dacount,RegionalCenterAccount reaccount,NationalCenterAccount naccount)
        {
            UserOperation UOpertation = new UserOperation();
            List<DoctorAccount> SelectedDocs = new List<DoctorAccount>();
            List<string> result = new List<string>();
            result = UOpertation.userType(dacount);
            var type = result[0];
            var userID = result[1];
            if (type!="") {
                HttpCookie cookie = new HttpCookie("username", reaccount.UserName);
                HttpCookie cookieID = new HttpCookie("userID", userID);
                HttpCookie cookieType = new HttpCookie("userType", type);
                Response.Cookies.Add(cookie);
                Response.Cookies.Add(cookieID);
                Response.Cookies.Add(cookieType);
                if (type == "administrator"){
                    return RedirectToAction("Index", "Nation");
                }
                if (type == "hospital"){
                    return RedirectToAction("Index", "Region");
                }
                if (type == "doctor")
                {
                    return RedirectToAction("Index", "EnterPatInfor");
                }
                else { return View(); }
            }else
                {
                    ViewBag.message = "用户名或密码错误";
                    return View();
                }
        }
     
    }
}
