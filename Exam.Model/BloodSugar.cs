//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exam.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BloodSugar
    {
        public System.Guid ID { get; set; }
        public Nullable<double> BloodSugar1 { get; set; }
        public Nullable<System.Guid> ClientID { get; set; }
        public Nullable<System.DateTime> ExamDate { get; set; }
        public Nullable<int> Meal { get; set; }
        public string ExamRet { get; set; }
    }
}
