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
    
    public partial class usuario
    {
        public usuario()
        {
            this.chofer = new HashSet<chofer>();
            this.esta_en = new HashSet<esta_en>();
            this.notificación = new HashSet<notificación>();
            this.pasajero = new HashSet<pasajero>();
        }
    
        public int Id { get; set; }
        public Nullable<double> Longitud { get; set; }
        public Nullable<double> Latitud { get; set; }
        public string Correo { get; set; }
    
        public virtual ICollection<chofer> chofer { get; set; }
        public virtual ICollection<esta_en> esta_en { get; set; }
        public virtual ICollection<notificación> notificación { get; set; }
        public virtual ICollection<pasajero> pasajero { get; set; }
    }
}
