namespace DBMarvelContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContextMarvelVirtual : DbContext
    {
        public ContextMarvelVirtual()
            : base("name=ContextMarvelVirtual")
        {
        }

        public virtual DbSet<Inventarios> Inventarios { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Sucursales> Sucursales { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventarios>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Inventarios>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Inventarios>()
                .HasMany(e => e.Productos)
                .WithRequired(e => e.Inventarios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Sucursales>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Sucursales>()
                .Property(e => e.Ubicacion)
                .IsUnicode(false);

            modelBuilder.Entity<Sucursales>()
                .Property(e => e.Telefonos)
                .IsUnicode(false);

            modelBuilder.Entity<Sucursales>()
                .HasMany(e => e.Inventarios)
                .WithRequired(e => e.Sucursales)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.ApellidoParterno)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.ApellidoMaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Inventarios)
                .WithOptional(e => e.Usuarios)
                .HasForeignKey(e => e.IdUsuarioAlta);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Productos)
                .WithOptional(e => e.Usuarios)
                .HasForeignKey(e => e.IdUsuarioAlta);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Sucursales)
                .WithOptional(e => e.Usuarios)
                .HasForeignKey(e => e.IdUsuarioAlta);
        }
    }
}
