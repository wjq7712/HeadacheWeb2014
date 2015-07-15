using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
using System.Diagnostics;
namespace HeadacheCDSSWeb.Models
{
    public class UserOperation
    {
        HeadacheModelContainer DataContainer = new HeadacheModelContainer();
        public bool ValidateUser(String User, String Password)
        {
            try
            {
                var Users = from s in DataContainer.DoctorAccountSet.ToList() select s;
                var user = Users.Where(s => s.UserName == User && s.PassWord == Password).FirstOrDefault();
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                return false;
            }

        }
    
        public List<DoctorAccount> GetSelectedDocs(String User, String Password )
        {
            List<DoctorAccount> Docs = new List<DoctorAccount>();
            List<DoctorAccount> SelectedDocs = new List<DoctorAccount>();
            List<DoctorAccount> Unormaldoc = new List<DoctorAccount>();
            var docs = from s in DataContainer.DoctorAccountSet.ToList() select s;
            var RUsers = from s in DataContainer.RegionalCenterAccountSet.ToList() select s;
            var Ruser = RUsers.Where(s => s.UserName == User && s.PassWord == Password).FirstOrDefault();
            if (Ruser != null)
            {
                foreach ( DoctorAccount doc in docs)
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
            }
            return SelectedDocs;
        }

        public List<string> userType(DoctorAccount da) {
            List<string> result = new List<string>();
            var name = da.UserName;
            var type = "";
            var userID="";
            var users1 = from s in DataContainer.NationalCenterAccountSet.ToList() select s;
            var user1 = users1.Where(s => s.UserName == da.UserName && s.PassWord == da.PassWord).FirstOrDefault();
            var users2 = from s in DataContainer.RegionalCenterAccountSet.ToList() select s;
            var user2 = users2.Where(s => s.UserName == da.UserName && s.PassWord == da.PassWord).FirstOrDefault();
            var users3 = from s in DataContainer.DoctorAccountSet.ToList() select s;
            var user3 = users3.Where(s => s.UserName == da.UserName && s.PassWord == da.PassWord).FirstOrDefault();
            if (user1!=null) {
                type = "administrator";
                userID = user1.ID.ToString();
            }
            if (user2 != null)
            {
                type = "region";
                userID = user2.ID.ToString();
            }
            if (user3 != null)
            {
                type = "doctor";
                userID = user3.Id.ToString();
            }
            result.Add(type);
            result.Add(userID);
            return result;
        }
        public bool duplicaionName(string name) {
            var users1 = from s in DataContainer.NationalCenterAccountSet.ToList() select s;
            var user1 = users1.Where(s => s.UserName == name).FirstOrDefault();
            var users2 = from s in DataContainer.RegionalCenterAccountSet.ToList() select s;
            var user2 = users2.Where(s => s.UserName == name).FirstOrDefault();
            var users3 = from s in DataContainer.DoctorAccountSet.ToList() select s;
            var user3 = users3.Where(s => s.UserName == name).FirstOrDefault();
            if ((user1 == null) && (user2 == null) && (user3 == null))
            {
                return true;
            }
            else {   
                return false;
            }          
        }
        public List<userInfo> getRegionAccount(string userName)
        {
            List<userInfo> Regs = new List<userInfo>();           
            var regs = from s in DataContainer.RegionalCenterAccountSet.ToList() select s;
            var NUsers = from s in DataContainer.NationalCenterAccountSet.ToList() select s;
            var Nuser = NUsers.Where(s => s.UserName == userName).FirstOrDefault();
            if (Nuser != null)
            {
                foreach ( RegionalCenterAccount reg in regs)
                {
                    if (reg.NationalCenterAccountID ==Nuser.ID)
                    {
                        userInfo ui = new userInfo();
                        ui.id = reg.ID;
                        ui.userName = reg.UserName;
                        ui.passWord = reg.PassWord;
                        ui.chiefDoctor = reg.Region;
                        ui.userRole = "医院";
                        Regs.Add(ui);
                    }                    
                }
            }
            return Regs;
        }
        public List<userInfo> SelectedDocs(string userName)
        {
            List<userInfo> dataset = new List<userInfo>();
            var docs = from s in DataContainer.DoctorAccountSet.ToList() select s;
            var RUsers = from s in DataContainer.RegionalCenterAccountSet.ToList() select s;
            var Ruser = RUsers.Where(s => s.UserName == userName).FirstOrDefault();
            foreach (DoctorAccount doc in docs)
            {
                if (doc.RegionalCenterAccountID == Ruser.ID)
                {
                    userInfo ui = new userInfo();
                    ui.id = doc.Id;
                    ui.userName = doc.UserName;
                    ui.passWord = doc.PassWord;
                    ui.chiefDoctor = doc.ChiefDoctor;
                    ui.userRole ="医生";
                    dataset.Add(ui);
                }
            }
            return dataset;
        }
    }
}