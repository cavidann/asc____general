
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
    
public partial class food
{

    public int id { get; set; }

    public string name { get; set; }

    public Nullable<int> category_id { get; set; }

    public string text { get; set; }

    public string photo { get; set; }



    public virtual food_categories food_categories { get; set; }

}

}
