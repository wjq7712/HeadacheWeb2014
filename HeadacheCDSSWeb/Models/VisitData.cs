using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeadacheCDSSWeb.Models
{
    public class VisitData
    {
        public List<HeadacheFamilyMember> HFamilyMember { get; set; }
        public List<OtherFamilyDisease> OFamilyDisease { get; set; }
        public Lifestyle lifestyle { get; set; }
        public List<PreviousDrug> PDrug { get; set; }
        public List<PreviousExam> PExam { get; set; }
      
        public string Similarfamily{get;set;}
        public VisitRecord visitrecord { get; set; }
        public PrimaryHeadacheOverView PHeadacheOverview { get; set; }
        public List<MedicationAdvice> MAdvice{get;set;}
        public GADQuestionaire GADquestionaire{get;set;}
        public SleepStatus Sleepstatus { get; set; }
        public DisabilityEvaluation Disabilityevaluation { get; set; }
        public PHQuestionaire PHquestionaire{get;set;}
    }
}