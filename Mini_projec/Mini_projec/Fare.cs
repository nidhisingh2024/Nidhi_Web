//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mini_projec
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fare
    {
        public int SerialNo { get; set; }
        public Nullable<decimal> Train_No { get; set; }
        public Nullable<int> C1_AC { get; set; }
        public Nullable<int> C2_AC { get; set; }
        public Nullable<int> SL { get; set; }
    
        public virtual TrainDetail TrainDetail { get; set; }
    }
}
