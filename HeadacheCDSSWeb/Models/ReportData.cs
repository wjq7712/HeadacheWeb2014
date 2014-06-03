using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeadacheCDSSWeb.Models
{
    public class ReportData
    {
         public ReportData()
        {
            this.Hfamilymember = new List<string>();
            this.Ofamilydisease = new List<string>();
            this.previousdrug = new List<PDrug>();
            this.previousexam = new List<Exam>();
            this.headacheplace = new List<string>();
            this.precipitatingfactor = new List<Factor>();
            this.mitigatingfactors = new List<string>();
            this.headacheaccompany = new List<string>();
            this.headacheprodrome = new List<string>();
            this.medicationadvice = new List<HMedicine>();
            this.headacheoverview = new HeadacheOverview();
            this.patlifestyle = new lifestyle();
            this.sleepconditon = new sleepstatus();
            this.disablityevaluation = new Disabilityevaluation();
            this.phquestionaire = new PHQ();
            this.gdaquestionaire = new GADQ();
            this.secondaryheadachesymptom = new List<string>();
            this.premonitorsymptom = new List<string>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public string Education { get; set; }
        public string Job { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Identity { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public bool SimilarFamily { get; set; }
        public List<string> Hfamilymember;
        public List<string> Ofamilydisease;
        public List<PDrug>previousdrug{get;set;}
        public List<Exam>previousexam{get;set;}
        public List<string> secondaryheadachesymptom { get;set; }

        public string OutpatientID { get; set; }
        public string ChiefComplaint { get; set; }
        public System.DateTime VisitDate { get; set; }
        public string PatBasicInforId { get; set; }
        public string CDSSDiagnosis1 { get; set; }
        public string CDSSDiagnosis2 { get; set; }
        public string CDSSDiagnosis3 { get; set; }
        public string DiagnosisResult1 { get; set; }
        public string DiagnosisResult2 { get; set; }
        public string DiagnosisResult3 { get; set; }
        public string Prescription { get; set; }
        public string PreviousDiagnosis { get; set; }
        public string PrescriptionNote { get; set; }
        public List<string> headacheplace{get;set;}
        public List<Factor> precipitatingfactor{get;set;}
        public List<string> mitigatingfactors{get;set;}
        public List<string> headacheaccompany{get;set;}
        public List<string> headacheprodrome{get;set;}
        public List<string> premonitorsymptom{get;set;}
        public List<HMedicine> medicationadvice{get;set;}
        public HeadacheOverview headacheoverview{get;set;}
        public lifestyle  patlifestyle{get;set;}
        public sleepstatus sleepconditon{get;set;}
        public PHQ phquestionaire{get;set;}
        public GADQ gdaquestionaire { get; set; }
        public Disabilityevaluation disablityevaluation{get;set;}
    }
   public class HMedicine
    {
        public string DrugApplication { get; set; }
        public string DrugCategory { get; set; }
        public string DrugName { get; set; }
        public string DrugDose { get; set; }
        public string DrugDoseUnit { get; set; }
    }
   public class PDrug{
        public string DrugCategory { get; set; }
        public string DrugName { get; set; }
        public string DayAmoutnPerM { get; set; }
        public string MonthTotalAmount { get; set; }
     }
   public class Exam
    {
        public string ExamName { get; set; }
        public string Result { get; set; }
        public string Date { get; set; }
    }
    public class HeadacheOverview
    {
        public string HeadacheType { get; set; }
        public string HeadacheDegree { get; set; }
        public string HeadcheTime { get; set; }
        public string HeacheTimeUnit { get; set; }
       
        public string FrequencyPerMonth { get; set; }
        public string OnsetFixedPeriod { get; set; }
       
        public DateTime OnsetDate { get; set; }
        public string OnsetAmount { get; set; }
        public string DailyAggravation { get; set; }
        public string FirstOnsetContinue { get; set; }
    }
    public class Factor{
        public string FName;
        public string FDetail;
    }
    public class lifestyle
    {
        public Nullable<bool> SmokeState { get; set; }
        public string SmokeYear { get; set; }
        public Nullable<bool> DrinkState { get; set; }
        public string DrinkYear { get; set; }
        public string TeaPerDay { get; set; }
        public string CoffePerDay { get; set; }
        public Nullable<bool> ExerciseOften { get; set; }
        
    }
    public class sleepstatus
    {
        public string TimePerDay { get; set; }
        public string DifficultFallingAsleep { get; set; }
        public string Dreaminess { get; set; }
        public string FestlessSleep { get; set; }
        public string SleepyDayTime { get; set; }
    }
    public class PHQ{
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
        public string Q4 { get; set; }
        public string Q5 { get; set; }
        public string Q6 { get; set; }
        public string Q7 { get; set; }
        public string Q8 { get; set; }
        public string Q9 { get; set; }
        public string TotalScore { get; set; }
    }
    public class GADQ{
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
        public string Q4 { get; set; }
        public string Q5 { get; set; }
        public string Q6 { get; set; }
        public string Q7 { get; set; }
        public string TotalScore { get; set; }
    }
    public class Disabilityevaluation{
        public string HeadacheDays { get; set; }
        public string OutOfWorkDays { get; set; }
        public string AffectWorkDays { get; set; }
        public string OutOfHouseWorkDays { get; set; }
        public string AffectHouseWorkDays { get; set; }
        public string MissActivityDays { get; set; }

    }
}