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
    
    public partial class paradero
    {
        public paradero()
        {
            this.esta_en = new HashSet<esta_en>();
            this.recorrido_paradero = new HashSet<recorrido_paradero>();
        }
    
        public int Id { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<esta_en> esta_en { get; set; }
        public virtual ICollection<recorrido_paradero> recorrido_paradero { get; set; }
    }
}
