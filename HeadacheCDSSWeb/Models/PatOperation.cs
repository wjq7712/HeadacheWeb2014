using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
using System.Diagnostics;
namespace HeadacheCDSSWeb.Models
{
    public class PatOperation
    {
       HeadacheModelContainer context = new HeadacheModelContainer();
       
        public bool InsertPat(PatBasicInfor pat, string PID, string User)
        {

            try
            {
                pat.Id = System.Guid.NewGuid().ToString().Replace("-", "");
                Lifestyle lstyle = new Lifestyle();
                lstyle.PatBasicInfor=pat;
                pat.Lifestyle = lstyle;
                var users = from s in context.DoctorAccountSet.ToList() select s;
                DoctorAccount user = users.Where(s => s.UserName == User).FirstOrDefault();
                user.PatBasicInfor.Add(pat);

                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //2014530
        public bool DeletePat(string PatID)
        {
            try
            {
                var patient = from p in context.PatBasicInforSet.ToList()
                              where (p.Id == PatID)
                              select p;
                PatBasicInfor ptfor = patient.First();
                VisitDataOperation visitop = new VisitDataOperation();
                //删除viewrecord
                if (ptfor.VisitRecord != null)
                {
                    var vr = from v in context.VisitRecordSet.ToList()
                             where (v.PatBasicInforId == PatID)
                             select v;
                    foreach (var R in vr)
                    {
                       string RecordID = R.Id.ToString();
                       visitop.DeleteRecord(PatID, RecordID);
                    }
                }
                //头痛日志
                //if (ptfor.HeadacheDiary != null)
                //{ 
                //   while(ptfor.HeadacheDiary.)
                //}
                //删除患有头痛家族成员
                while (ptfor.HeadacheFamilyMember.Count!=0)
                {
                    context.HeadacheFamilyMemberSet.Remove(ptfor.HeadacheFamilyMember.First());     
                }
                while (ptfor.Lifestyle != null)
                {
                    context.LifestyleSet.Remove(ptfor.Lifestyle);//是不是一对一的删不了？
                }
                while (ptfor.OtherFamilyDisease.Count != 0)
                {
                    context.OtherFamilyDiseaseSet.Remove(ptfor.OtherFamilyDisease.First());
                }
                while (ptfor.PreviousDrug.Count != 0)
                {
                    context.PreviousDrugSet.Remove(ptfor.PreviousDrug.First());  
                }
                while (ptfor.PreviousExam.Count!=0)
                {
                    context.PreviousExamSet.Remove(ptfor.PreviousExam.First());
                }

                context.PatBasicInforSet.Remove(ptfor);
                context.SaveChanges();
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }
    }
}