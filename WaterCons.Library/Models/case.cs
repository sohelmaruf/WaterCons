//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WaterCons.Library.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class @case
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public @case()
        {
            this.advertisementcases = new HashSet<advertisementcas>();
            this.campaigncases = new HashSet<campaigncas>();
            this.casecontacts = new HashSet<casecontact>();
            this.educationalvisitcases = new HashSet<educationalvisitcas>();
            this.events = new HashSet<@event>();
            this.interventions = new HashSet<intervention>();
            this.irrigationalcases = new HashSet<irrigationalcas>();
            this.surveyareas = new HashSet<surveyarea>();
            this.surveycases = new HashSet<surveycas>();
            this.violationcases = new HashSet<violationcas>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public int PhaseID { get; set; }
        public Nullable<int> ApplicantID { get; set; }
        public Nullable<int> OwnerID { get; set; }
        public Nullable<int> OwnerOrgID { get; set; }
        public Nullable<int> PropertyID { get; set; }
        public Nullable<int> AccountID { get; set; }
        public Nullable<int> InspectorID { get; set; }
        public string OriginalCaseNumber { get; set; }
        public string ApplicationNumber { get; set; }
        public string OwnOrRent { get; set; }
        public Nullable<bool> AwareOfProgram { get; set; }
        public Nullable<int> WaterUsage { get; set; }
        public Nullable<int> StepID { get; set; }
        public Nullable<System.DateTime> StepDate { get; set; }
        public Nullable<System.DateTime> StepDateNext { get; set; }
        public string FundingType { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Referral { get; set; }
        public Nullable<bool> ReceiptsAttached { get; set; }
        public Nullable<bool> BillsAttached { get; set; }
        public Nullable<bool> ApplicationProvided { get; set; }
        public Nullable<bool> ApplicationRequired { get; set; }
        public string ApplicationReturnedReason { get; set; }
        public string RejectionReason { get; set; }
        public Nullable<bool> PotentialReturn { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public Nullable<bool> WalkAway { get; set; }
        public string WalkAwayReason { get; set; }
        public Nullable<bool> OtherProgramInterest { get; set; }
        public Nullable<bool> FurtherAssistanceNeeded { get; set; }
        public string Comments { get; set; }
        public string Recommendations { get; set; }
        public string CaseNumber { get; set; }
        public string SSNOrID { get; set; }
        public string CreditCard { get; set; }
        public Nullable<bool> RebateCheckSSNOrID { get; set; }
        public Nullable<bool> RebateCheckBill { get; set; }
        public Nullable<bool> RebateCheckReceipt { get; set; }
        public Nullable<bool> InspectionRequired { get; set; }
        public Nullable<bool> Inspected { get; set; }
        public string InspectionPassFail { get; set; }
        public Nullable<System.DateTime> InspectionDate { get; set; }
        public Nullable<System.DateTime> CertificationDate { get; set; }
        public Nullable<bool> Verified { get; set; }
        public string VerificationMethod { get; set; }
        public Nullable<System.DateTime> VerificationDate { get; set; }
        public string OtherInspectorName { get; set; }
        public string Document { get; set; }
        public Nullable<bool> SurveySent { get; set; }
        public Nullable<bool> SurveyCompleted { get; set; }
        public string OTUWNum { get; set; }
        public string BatchID { get; set; }
        public Nullable<bool> ROCCertified { get; set; }
        public Nullable<System.DateTime> ROCCertifiedDate { get; set; }
        public Nullable<System.DateTime> DocDate { get; set; }
        public Nullable<int> DocNum { get; set; }
        public Nullable<int> YearBuilt { get; set; }
        public Nullable<int> BathTot { get; set; }
        public Nullable<bool> RCCase { get; set; }
        public string RCStatus { get; set; }
        public Nullable<int> AssignedProjectID { get; set; }
        public Nullable<decimal> RCTotalWaterSavings { get; set; }
        public string Responsible { get; set; }
        public string WDOGreenCreditMultiplier { get; set; }
        public string WDOTotalOffsetRequired { get; set; }
        public string RejectReasons { get; set; }
        public Nullable<bool> CreditAssigned { get; set; }
        public string EscrowNumber { get; set; }
        public string UnitNumber { get; set; }
        public string CompanyName { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string Photo4 { get; set; }
        public string Photo5 { get; set; }
        public string Photo6 { get; set; }
        public string Photo7 { get; set; }
        public string Photo8 { get; set; }
        public string RUSInspector { get; set; }
        public string RUSEscrowAgent { get; set; }
        public string RUSRealtor { get; set; }
        public string RUSOther { get; set; }
        public string CAPType { get; set; }
        public string HowDidYouHear { get; set; }
        public string ReasonforParticipation { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int ModBy { get; set; }
        public System.DateTime ModDate { get; set; }
    
        public virtual account account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<advertisementcas> advertisementcases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<campaigncas> campaigncases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<casecontact> casecontacts { get; set; }
        public virtual client client { get; set; }
        public virtual phase phase { get; set; }
        public virtual person person { get; set; }
        public virtual person person1 { get; set; }
        public virtual person person2 { get; set; }
        public virtual organization organization { get; set; }
        public virtual property property { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<educationalvisitcas> educationalvisitcases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<@event> events { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<intervention> interventions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<irrigationalcas> irrigationalcases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<surveyarea> surveyareas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<surveycas> surveycases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<violationcas> violationcases { get; set; }
    }
}