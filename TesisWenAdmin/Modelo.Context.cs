﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TesisbdEntities : DbContext
    {
        public TesisbdEntities()
            : base("name=TesisbdEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<bus> bus { get; set; }
        public DbSet<chofer> chofer { get; set; }
        public DbSet<ciudad> ciudad { get; set; }
        public DbSet<empresa> empresa { get; set; }
        public DbSet<esta_en> esta_en { get; set; }
        public DbSet<hace> hace { get; set; }
        public DbSet<notificación> notificación { get; set; }
        public DbSet<paradero> paradero { get; set; }
        public DbSet<pasajero> pasajero { get; set; }
        public DbSet<recorrido> recorrido { get; set; }
        public DbSet<recorrido_paradero> recorrido_paradero { get; set; }
        public DbSet<tipopasaje> tipopasaje { get; set; }
        public DbSet<tipopasaje_recorrido> tipopasaje_recorrido { get; set; }
        public DbSet<usuario> usuario { get; set; }
    }
}
