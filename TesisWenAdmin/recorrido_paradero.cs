//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TesisWenAdmin
{
    using System;
    using System.Collections.Generic;
    
    public partial class recorrido_paradero
    {
        public int Recorrido_Id { get; set; }
        public int Paradero_Id { get; set; }
        public int Id { get; set; }
    
        public virtual paradero paradero { get; set; }
        public virtual recorrido recorrido { get; set; }
    }
}
