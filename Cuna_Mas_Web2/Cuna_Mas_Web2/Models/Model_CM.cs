namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model_CM : DbContext
    {
        public Model_CM()
            : base("name=Model_CM")
        {
        }

        public virtual DbSet<DatosMedicos> DatosMedicos { get; set; }
        public virtual DbSet<DatosQR> DatosQR { get; set; }
        public virtual DbSet<Madre> Madre { get; set; }
        public virtual DbSet<MetodoAprendizaje> MetodoAprendizaje { get; set; }
        public virtual DbSet<Ninio> Ninio { get; set; }
        public virtual DbSet<Observacion> Observacion { get; set; }
        public virtual DbSet<Padre> Padre { get; set; }
        public virtual DbSet<Racion> Racion { get; set; }
        public virtual DbSet<Ranking> Ranking { get; set; }
        public virtual DbSet<Reunion> Reunion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatosMedicos>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<DatosMedicos>()
                .Property(e => e.altura)
                .HasPrecision(5, 2);

            modelBuilder.Entity<DatosMedicos>()
                .Property(e => e.peso)
                .HasPrecision(5, 2);

            modelBuilder.Entity<DatosMedicos>()
                .Property(e => e.indice_nutricion)
                .IsUnicode(false);

            modelBuilder.Entity<DatosQR>()
                .Property(e => e.qr)
                .IsUnicode(false);

            modelBuilder.Entity<Madre>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Madre>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Madre>()
                .Property(e => e.edad)
                .IsUnicode(false);

            modelBuilder.Entity<Madre>()
                .Property(e => e.obserbaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Madre>()
                .Property(e => e.comite)
                .IsUnicode(false);

            modelBuilder.Entity<Madre>()
                .HasMany(e => e.Ninio)
                .WithRequired(e => e.Madre)
                .HasForeignKey(e => e.fk_id_cuidadora)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Madre>()
                .HasMany(e => e.Observacion)
                .WithRequired(e => e.Madre)
                .HasForeignKey(e => e.fk_id_madre_cuidadora)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Madre>()
                .HasMany(e => e.Padre)
                .WithRequired(e => e.Madre)
                .HasForeignKey(e => e.fk_id_madre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Madre>()
                .HasMany(e => e.Ranking)
                .WithRequired(e => e.Madre)
                .HasForeignKey(e => e.fk_id_madre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Madre>()
                .HasMany(e => e.Reunion)
                .WithRequired(e => e.Madre)
                .HasForeignKey(e => e.id_madre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MetodoAprendizaje>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<MetodoAprendizaje>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<MetodoAprendizaje>()
                .Property(e => e.rango_edad)
                .IsUnicode(false);

            modelBuilder.Entity<MetodoAprendizaje>()
                .Property(e => e.procedimiento)
                .IsUnicode(false);

            modelBuilder.Entity<MetodoAprendizaje>()
                .HasMany(e => e.Ninio)
                .WithOptional(e => e.MetodoAprendizaje)
                .HasForeignKey(e => e.fk_id_metodo);

            modelBuilder.Entity<Ninio>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Ninio>()
                .HasMany(e => e.DatosMedicos)
                .WithRequired(e => e.Ninio)
                .HasForeignKey(e => e.fk_id_ninio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ninio>()
                .HasMany(e => e.Racion)
                .WithRequired(e => e.Ninio)
                .HasForeignKey(e => e.fk_id_ninio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Observacion>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Observacion>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Padre>()
                .Property(e => e.nombrePadre)
                .IsUnicode(false);

            modelBuilder.Entity<Padre>()
                .Property(e => e.nombreMadre)
                .IsUnicode(false);

            modelBuilder.Entity<Padre>()
                .Property(e => e.apoderado)
                .IsUnicode(false);

            modelBuilder.Entity<Padre>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Padre>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Padre>()
                .HasMany(e => e.Ninio)
                .WithRequired(e => e.Padre)
                .HasForeignKey(e => e.fk_id_padre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Racion>()
                .Property(e => e.desayuno)
                .IsUnicode(false);

            modelBuilder.Entity<Racion>()
                .Property(e => e.refrigerio)
                .IsUnicode(false);

            modelBuilder.Entity<Racion>()
                .Property(e => e.almuerzo)
                .IsUnicode(false);

            modelBuilder.Entity<Racion>()
                .Property(e => e.postre)
                .IsUnicode(false);

            modelBuilder.Entity<Racion>()
                .HasMany(e => e.DatosQR)
                .WithRequired(e => e.Racion)
                .HasForeignKey(e => e.fk_id_racion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reunion>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Reunion>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Reunion>()
                .Property(e => e.importancia)
                .IsUnicode(false);

            modelBuilder.Entity<Reunion>()
                .Property(e => e.fecha)
                .IsUnicode(false);

            modelBuilder.Entity<Reunion>()
                .HasMany(e => e.Padre)
                .WithOptional(e => e.Reunion)
                .HasForeignKey(e => e.fk_id_reunion);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuario1)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.imagen)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Madre)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.fk_id_usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Padre)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.fk_id_usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
