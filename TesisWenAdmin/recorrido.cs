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
    
    public partial class recorrido
    {
        public recorrido()
        {
            this.hace = new HashSet<hace>();
            this.recorrido_paradero = new HashSet<recorrido_paradero>();
            this.tipopasaje_recorrido = new HashSet<tipopasaje_recorrido>();
        }
    
        public int Id { get; set; }
        public Nullable<System.TimeSpan> HorarioOrigen { get; set; }
        public Nullable<System.TimeSpan> HorarioDestino { get; set; }
        public int Ciudad_Origen_Id { get; set; }
        public int Ciudad_Destino_Id { get; set; }
        public string Día { get; set; }
    
        public virtual ciudad ciudad { get; set; }
        public virtual ciudad ciudad1 { get; set; }
        public virtual ICollection<hace> hace { get; set; }
        public virtual ICollection<recorrido_paradero> recorrido_paradero { get; set; }
        public virtual ICollection<tipopasaje_recorrido> tipopasaje_recorrido { get; set; }
    }
}
