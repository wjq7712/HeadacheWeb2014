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
    }
}