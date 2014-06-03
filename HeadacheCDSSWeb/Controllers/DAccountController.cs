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
        public ActionResult Index(DoctorAccount dacount,RegionalCenterAccount reaccount)
        {
            UserOperation UOpertation = new UserOperation();
            List<DoctorAccount> SelectedDocs = new List<DoctorAccount>();
            SelectedDocs = UOpertation.GetSelectedDocs(reaccount.UserName, reaccount.PassWord);
            bool docaccout = UOpertation.ValidateUser(dacount.UserName, dacount.PassWord);
            if (SelectedDocs != null && SelectedDocs.Count > 0)
            {
                HttpCookie cookie = new HttpCookie("username", reaccount.UserName);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Region");
            }else 
            if (docaccout)
            {
                HttpCookie cookie = new HttpCookie("username", dacount.UserName);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "EnterPatInfor");
            }          
                else
                {
                    ViewBag.message = "用户名或密码错误";
                    return View();
                }
        }
     
    }
}
