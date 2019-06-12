namespace Proyecto_Final_Web_II.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class proyecto_ARTC : DbContext
    {
        public proyecto_ARTC()
            : base("name=proyecto_ARTC")
        {
        }

        public virtual DbSet<Control> Control { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Reservorio> Reservorio { get; set; }
        public virtual DbSet<Sensor> Sensor { get; set; }
        public virtual DbSet<Servo> Servo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Control>()
                .Property(e => e.servo_control)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Control>()
                .Property(e => e.estado_control)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.cod_per)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.nomb_per)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.apel_per)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.edad_per)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.dni_per)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.sexo_per)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.cel_per)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.estado_per)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Persona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reservorio>()
                .Property(e => e.cant_agua_reser)
                .IsUnicode(false);

            modelBuilder.Entity<Reservorio>()
                .Property(e => e.dist_llenado_reser)
                .IsUnicode(false);

            modelBuilder.Entity<Reservorio>()
                .Property(e => e.estado_reservorio)
                .IsUnicode(false);

            modelBuilder.Entity<Reservorio>()
                .HasMany(e => e.Control)
                .WithRequired(e => e.Reservorio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sensor>()
                .Property(e => e.nomb_sensor)
                .IsUnicode(false);

            modelBuilder.Entity<Sensor>()
                .Property(e => e.rango_med_sensor)
                .IsUnicode(false);

            modelBuilder.Entity<Sensor>()
                .Property(e => e.estado_sensor)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sensor>()
                .HasMany(e => e.Reservorio)
                .WithRequired(e => e.Sensor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Servo>()
                .Property(e => e.nomb_servo)
                .IsUnicode(false);

            modelBuilder.Entity<Servo>()
                .Property(e => e.torque_servo)
                .IsUnicode(false);

            modelBuilder.Entity<Servo>()
                .Property(e => e.dimens_servo)
                .IsUnicode(false);

            modelBuilder.Entity<Servo>()
                .Property(e => e.voltaje_servo)
                .IsUnicode(false);

            modelBuilder.Entity<Servo>()
                .Property(e => e.vel_mov_servo)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Servo>()
                .Property(e => e.peso_servo)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Servo>()
                .Property(e => e.estado_servo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Servo>()
                .HasMany(e => e.Control)
                .WithRequired(e => e.Servo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nomb_usu)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.pas_usu)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nivel_usu)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.foto_usu)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.estado_usu)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Control)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
