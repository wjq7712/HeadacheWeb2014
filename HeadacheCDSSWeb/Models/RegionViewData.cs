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
        public List<tableData> GetPatforView(List<PatBasicInfor> Patlist)
        {
            List<tableData> dataset = new List<tableData>();
            var count=Patlist.Count;
            for (int i = 0; i < count; i++)
            {
                tableData rd = new tableData();
                rd.Name =Patlist[i].Name;
                rd.Sex = Patlist[i].Sex;
                rd.Age = Patlist[i].Age;
                rd.ListID = Convert.ToString(i+1);
                rd.PatBasicInforId = Patlist[i].Id;
                var record = from p in container.VisitRecordSet.ToList()
                             where (p.PatBasicInfor.Id == Patlist[i].Id)
                             select p;
                var num = record.Count();

                if (num != 0)
                {
                    VisitRecord vt = record.First();
                    rd.Date = vt.VisitDate.ToString("yyyy-MM-dd");
                    if (vt.DiagnosisResult1 != null || vt.DiagnosisResult2 != null || vt.DiagnosisResult3 != null)
                    {
                        if(vt.DiagnosisResult1.Contains("慢性每日头痛")){
                        var style = vt.DiagnosisResult1.Split(new Char[] { ':'});
                        if (style.Length > 1)
                        {
                            rd.HeadacheStyle = style[1];
                        }
                        else { 
                          rd.HeadacheStyle = vt.DiagnosisResult1 + vt.DiagnosisResult2 + vt.DiagnosisResult3;
                        }
                            }else{
                        rd.HeadacheStyle = vt.DiagnosisResult1 + vt.DiagnosisResult2 + vt.DiagnosisResult3;}
                    }
                }
                dataset.Add(rd);
            }
            return dataset;
        }
        public tableData GetPatinfo(PatBasicInfor pat)
        {
            tableData rd = new tableData();
            rd.Name =pat.Name;
            rd.Sex =pat.Sex;
            rd.Age =pat.Age;
            //rd.ListID = Convert.ToString(i + 1);
            rd.PatBasicInforId =pat.Id;
            var record = from p in container.VisitRecordSet.ToList()
                            where (p.PatBasicInfor.Id ==pat.Id)
                            select p;
            var num = record.Count();

            if (num != 0)
            {
                VisitRecord vt = record.First();
                rd.Date = vt.VisitDate.ToString("yyyy-MM-dd");
                if (vt.DiagnosisResult1 != null || vt.DiagnosisResult2 != null || vt.DiagnosisResult3 != null)
                {
                    if (vt.DiagnosisResult1.Contains("慢性每日头痛"))
                    {
                        var style = vt.DiagnosisResult1.Split(new Char[] { ':' });
                        if (style.Length > 1)
                        {
                            rd.HeadacheStyle = style[1];
                        }
                        else
                        {
                            rd.HeadacheStyle = vt.DiagnosisResult1 + vt.DiagnosisResult2 + vt.DiagnosisResult3;
                        }
                    }
                    else
                    {
                        rd.HeadacheStyle = vt.DiagnosisResult1 + vt.DiagnosisResult2 + vt.DiagnosisResult3;
                    }
                }
            }
        return rd;
        }
    }
}