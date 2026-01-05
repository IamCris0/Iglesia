using Microsoft.EntityFrameworkCore;
using SistemaParroquial.Models;

namespace SistemaParroquial.Data
{
    /// <summary>
    /// Contexto de base de datos para el Sistema Parroquial
    /// </summary>
    public class SistemaParroquialContext : DbContext
    {
        public SistemaParroquialContext(DbContextOptions<SistemaParroquialContext> options)
            : base(options)
        {
        }

        // DbSets principales
        public DbSet<Capilla> Capillas { get; set; }
        public DbSet<Laico> Laicos { get; set; }
        public DbSet<Misa> Misas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<EventoCapilla> EventosCapilla { get; set; }

        // DbSets auxiliares
        public DbSet<Parroquia> Parroquias { get; set; }
        public DbSet<Sacerdote> Sacerdotes { get; set; }
        public DbSet<HorarioMisa> HorariosMisa { get; set; }
        public DbSet<SolicitudSacramental> SolicitudesSacramentales { get; set; }
        public DbSet<SolicitudAyuda> SolicitudesAyuda { get; set; }
        public DbSet<LaicoFormacion> LaicosFormacion { get; set; }
        public DbSet<MiembroCEB> MiembrosCEB { get; set; }
        public DbSet<RolSistema> RolesSistema { get; set; }
        public DbSet<UsuarioRolSistema> UsuariosRolesSistema { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Capilla
            modelBuilder.Entity<Capilla>(entity =>
            {
                entity.HasKey(e => e.IdCapilla);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Direccion).HasMaxLength(200);

                entity.HasOne(e => e.Parroquia)
                    .WithMany(p => p.Capillas)
                    .HasForeignKey(e => e.IdParroquia)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Coordinador)
                    .WithMany()
                    .HasForeignKey(e => e.IdLaicoCoordinador)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configuración de Laico
            modelBuilder.Entity<Laico>(entity =>
            {
                entity.HasKey(e => e.IdLaico);
                entity.Property(e => e.Nombres).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Apellidos).HasMaxLength(150);
                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.HasOne(e => e.Capilla)
                    .WithMany()
                    .HasForeignKey(e => e.IdCapilla)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configuración de Misa
            modelBuilder.Entity<Misa>(entity =>
            {
                entity.HasKey(e => e.IdMisa);
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(20);
                entity.Property(e => e.MontoRecaudado).HasColumnType("decimal(10, 2)");

                entity.HasOne(e => e.Capilla)
                    .WithMany(c => c.Misas)
                    .HasForeignKey(e => e.IdCapilla)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Sacerdote)
                    .WithMany(s => s.Misas)
                    .HasForeignKey(e => e.IdSacerdote)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.SolicitudSacramental)
                    .WithMany()
                    .HasForeignKey(e => e.IdSolicitudSacramental)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configuración de Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);

                entity.HasIndex(e => e.Email).IsUnique();

                entity.HasOne(e => e.Laico)
                    .WithMany()
                    .HasForeignKey(e => e.IdLaico)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.Sacerdote)
                    .WithMany()
                    .HasForeignKey(e => e.IdSacerdote)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configuración de EventoCapilla
            modelBuilder.Entity<EventoCapilla>(entity =>
            {
                entity.HasKey(e => e.IdEventoCapilla);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.Activo).HasMaxLength(10);

                entity.HasOne(e => e.Capilla)
                    .WithMany(c => c.Eventos)
                    .HasForeignKey(e => e.IdCapilla)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de HorarioMisa
            modelBuilder.Entity<HorarioMisa>(entity =>
            {
                entity.HasKey(e => e.IdHorarioMisa);
                entity.Property(e => e.Activo).IsRequired().HasMaxLength(10);

                entity.HasOne(e => e.Capilla)
                    .WithMany(c => c.HorariosMisa)
                    .HasForeignKey(e => e.IdCapilla)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de SolicitudSacramental
            modelBuilder.Entity<SolicitudSacramental>(entity =>
            {
                entity.HasKey(e => e.IdSolicitudSacramental);
                entity.Property(e => e.Sacramento).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(30);

                entity.HasOne(e => e.Laico)
                    .WithMany(l => l.SolicitudesSacramentales)
                    .HasForeignKey(e => e.IdLaico)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de SolicitudAyuda
            modelBuilder.Entity<SolicitudAyuda>(entity =>
            {
                entity.HasKey(e => e.IdSolicitudAyuda);
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(30);
                entity.Property(e => e.MontoSolicitado).HasColumnType("decimal(10, 2)");

                entity.HasOne(e => e.Laico)
                    .WithMany(l => l.SolicitudesAyuda)
                    .HasForeignKey(e => e.IdLaico)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Parroquia)
                    .WithMany()
                    .HasForeignKey(e => e.IdParroquia)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de UsuarioRolSistema
            modelBuilder.Entity<UsuarioRolSistema>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioRolSistema);

                entity.HasOne(e => e.Usuario)
                    .WithMany(u => u.Roles)
                    .HasForeignKey(e => e.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.RolSistema)
                    .WithMany(r => r.UsuariosRoles)
                    .HasForeignKey(e => e.IdRolSistema)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración de LaicoFormacion
            modelBuilder.Entity<LaicoFormacion>(entity =>
            {
                entity.HasKey(e => e.IdLaicoFormacion);
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(20);

                entity.HasOne(e => e.Laico)
                    .WithMany(l => l.Formaciones)
                    .HasForeignKey(e => e.IdLaico)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de MiembroCEB
            modelBuilder.Entity<MiembroCEB>(entity =>
            {
                entity.HasKey(e => e.IdMiembroCEB);

                entity.HasOne(e => e.Laico)
                    .WithMany(l => l.MembresiaCEB)
                    .HasForeignKey(e => e.IdLaico)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
