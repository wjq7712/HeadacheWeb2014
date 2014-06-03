using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Diagnostics;
using System.Data.Entity.Validation;

namespace HeadacheCDSSWeb.Models
{
    public class RegionViewData
    {
        HeadacheModelContainer container=new HeadacheModelContainer ();
        public List< PatinfoForRe> GetPatforView(List<PatBasicInfor> Patlist)
        {
            List <PatinfoForRe> patforre=new List<PatinfoForRe>();
            var count=Patlist.Count;
            for (int i = 0; i < count; i++)
            {
                PatinfoForRe pr = new PatinfoForRe();
                pr.Name = Patlist[i].Name;
                pr.Sex = Patlist[i].Sex;
                pr.Age = Patlist[i].Age;
                pr.ListID = Convert.ToString(i+1);
                pr.PatBasicInforId = Patlist[i].Id;
                var record = from p in container.VisitRecordSet.ToList()
                             where (p.PatBasicInfor.Id == Patlist[i].Id)
                             select p;
                var num = record.Count();

                if (num != 0)
                {
                    VisitRecord vt = record.First();
                    pr.Data = vt.VisitDate.ToShortDateString().ToString();
                    if (vt.DiagnosisResult1 != null || vt.DiagnosisResult2 != null || vt.DiagnosisResult3 != null)
                    {
                        pr.HeadacheStyle = vt.DiagnosisResult1 + vt.DiagnosisResult2 + vt.DiagnosisResult3;
                    }
                }
                patforre.Add(pr);
            }
            return patforre;
        }
    }
}