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
    
    public partial class ciudad
    {
        public ciudad()
        {
            this.recorrido = new HashSet<recorrido>();
            this.recorrido1 = new HashSet<recorrido>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<recorrido> recorrido { get; set; }
        public virtual ICollection<recorrido> recorrido1 { get; set; }
    }
}
