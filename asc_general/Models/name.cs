//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace asc_general.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class name
    {
        public int id { get; set; }
        public string name1 { get; set; }
        public Nullable<int> lettrs_id { get; set; }
        public string decription { get; set; }
        public Nullable<int> type { get; set; }
    
        public virtual lettr lettr { get; set; }
    }
}
