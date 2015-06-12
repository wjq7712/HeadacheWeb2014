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
                //var age = pat.Age;
                //var realbirsyear =int.Parse(System.DateTime.Now.ToString("yyyy"))-age;
                //pat.Birsyear = realbirsyear;
                Lifestyle lstyle = new Lifestyle();
                lstyle.PatBasicInfor = pat;
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

                if (ptfor.VisitRecord.Count != 0)
                {
                    var vr = from v in context.VisitRecordSet.ToList() where (v.PatBasicInforId == PatID)select v;
                    foreach (var r in vr)
                    {
                        //不能调用 VisitDataOperation的删除就诊记录方法，因为两次savechange 操作会让删除病人时报“存储区更新、插入或删除语句影响到了意外的行数(0)。实体在加载后可能被修改或删除。刷新 ObjectStateManager 项。”错误
                         /* var recordId = r.Id.ToString();
                        visitop.DeleteRecord(PatID, recordId);
                        */
                        if (r.PrimaryHeadachaOverView != null)
                        {
                            while (r.PrimaryHeadachaOverView.HeadachePlace.Count != 0)
                            {
                                context.HeadachePlaceSet.Remove(r.PrimaryHeadachaOverView.HeadachePlace.First());
                            }
                            while (r.PrimaryHeadachaOverView.HeadacheAccompany.Count != 0)
                            {
                                context.HeadacheAccompanySet.Remove(r.PrimaryHeadachaOverView.HeadacheAccompany.First());
                            }
                            while (r.PrimaryHeadachaOverView.HeadacheProdrome.Count != 0)
                            {
                                context.HeadacheProdromeSet.Remove(r.PrimaryHeadachaOverView.HeadacheProdrome.First());
                            }
                            while (r.PrimaryHeadachaOverView.PrecipitatingFactor.Count != 0)
                            {
                                context.PrecipitatingFactorSet.Remove(r.PrimaryHeadachaOverView.PrecipitatingFactor.First());
                            }
                            while (r.PrimaryHeadachaOverView.MitigatingFactors.Count != 0)
                            {
                                context.MitigatingFactorsSet.Remove(r.PrimaryHeadachaOverView.MitigatingFactors.First());
                            }
                            while (r.PrimaryHeadachaOverView.PremonitorySymptom.Count != 0)
                            {
                                context.PremonitorySymptom集.Remove(r.PrimaryHeadachaOverView.PremonitorySymptom.First());
                            }
                            context.PrimaryHeadacheOverViewSet.Remove(r.PrimaryHeadachaOverView);
                        }


                        while (r.MedicationAdvice.Count != 0)
                        {
                            context.MedicationAdviceSet.Remove(r.MedicationAdvice.FirstOrDefault());
                        }

                        while (r.SecondaryHeadacheSymptom.Count != 0)
                        {
                            context.SecondaryHeadacheSymptomSet.Remove(r.SecondaryHeadacheSymptom.FirstOrDefault());
                        }
                        //add 2013/7/23
                        if (r.GADQuestionaire != null)
                        {
                            context.GADQuestionaireSet.Remove(r.GADQuestionaire);
                        }
                        if (r.GADQuestionaire != null)
                        {
                            context.GADQuestionaireSet.Remove(r.GADQuestionaire);
                        }
                        if (r.PHQuestionaire != null)
                        {
                            context.PHQuestionaireSet.Remove(r.PHQuestionaire);
                        }
                        if (r.SleepStatus != null)
                        {
                            context.SleepStatusSet.Remove(r.SleepStatus);
                        }
                        if (r.DisabilityEvaluation != null)
                        {
                            context.DisabilityEvaluationSet.Remove(r.DisabilityEvaluation);
                        }
                        // visitrecord 内容删除
                        context.VisitRecordSet.Remove(r);
                    }
                    
                }
                
                //头痛日志
                while (ptfor.HeadacheDiary.Count() != 0)
                {
                    context.HeadacheDiarySet.Remove(ptfor.HeadacheDiary.First());
                }
                //删除患有头痛家族成员
                
                while (ptfor.HeadacheFamilyMember.Count != 0)
                {
                    context.HeadacheFamilyMemberSet.Remove(ptfor.HeadacheFamilyMember.First());
                }
                while (ptfor.Lifestyle != null)
                {
                    context.LifestyleSet.Remove(ptfor.Lifestyle);//是不是一对一的删不了？
                    //context.Entry(ptfor.Lifestyle).State = System.Data.EntityState.Deleted;
                }
                while (ptfor.OtherFamilyDisease.Count != 0)
                {
                    context.OtherFamilyDiseaseSet.Remove(ptfor.OtherFamilyDisease.First());
                }
                while (ptfor.PreviousDrug.Count != 0)
                {
                    context.PreviousDrugSet.Remove(ptfor.PreviousDrug.First());
                }
                while (ptfor.PreviousExam.Count != 0)
                {
                    context.PreviousExamSet.Remove(ptfor.PreviousExam.First());
                }
                //医生推送建议表
                while (ptfor.DocSuggestionSet.Count != 0) {
                    context.DocSuggestionSet.Remove(ptfor.DocSuggestionSet.First());
                }
                context.PatBasicInforSet.Remove(ptfor);
                //context.Entry(ptfor).State = System.Data.EntityState.Deleted;
                context.SaveChanges();
                
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                return false;
            }
        }
    }
}