﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HSBC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UTTECEntities : DbContext
    {
        public UTTECEntities()
            : base("name=UTTECEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Calificacione> Calificaciones { get; set; }
        public virtual DbSet<Grado> Grados { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }
    }
}
