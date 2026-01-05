using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaParroquial.Models
{
    /// <summary>
    /// Modelo Parroquia
    /// </summary>
    [Table("Parroquia")]
    public class Parroquia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdParroquia { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [StringLength(200)]
        [Display(Name = "Zona")]
        public string Zona { get; set; }

        public virtual ICollection<Capilla> Capillas { get; set; }
    }

    /// <summary>
    /// Modelo Sacerdote
    /// </summary>
    [Table("Sacerdote")]
    public class Sacerdote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSacerdote { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [StringLength(150)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [StringLength(150)]
        [Display(Name = "Apodo")]
        public string Apodo { get; set; }

        [NotMapped]
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto => $"{Nombres} {Apellidos}".Trim();

        public virtual ICollection<Misa> Misas { get; set; }
    }

    /// <summary>
    /// Modelo EventoCapilla
    /// </summary>
    [Table("EventoCapilla")]
    public class EventoCapilla
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEventoCapilla { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Nombre del Evento")]
        public string Nombre { get; set; }

        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Fecha de Inicio")]
        [DataType(DataType.DateTime)]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha de Fin")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaFin { get; set; }

        [Required]
        [Display(Name = "Capilla")]
        public int IdCapilla { get; set; }

        [StringLength(10)]
        [Display(Name = "Estado")]
        public string Activo { get; set; }

        [ForeignKey("IdCapilla")]
        public virtual Capilla Capilla { get; set; }
    }

    /// <summary>
    /// Modelo HorarioMisa
    /// </summary>
    [Table("HorarioMisa")]
    public class HorarioMisa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHorarioMisa { get; set; }

        [Required]
        public int IdCapilla { get; set; }

        [Required]
        [Display(Name = "Día de la Semana")]
        [Range(0, 6, ErrorMessage = "Día debe estar entre 0 (Domingo) y 6 (Sábado)")]
        public int DiaSemana { get; set; }

        [Required]
        [Display(Name = "Hora")]
        [DataType(DataType.Time)]
        public TimeSpan Hora { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Estado")]
        public string Activo { get; set; }

        [NotMapped]
        [Display(Name = "Día")]
        public string NombreDia => ObtenerNombreDia(DiaSemana);

        [ForeignKey("IdCapilla")]
        public virtual Capilla Capilla { get; set; }

        private string ObtenerNombreDia(int dia)
        {
            string[] dias = { "Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" };
            return dias[dia];
        }
    }

    /// <summary>
    /// Modelo SolicitudSacramental
    /// </summary>
    [Table("SolicitudSacramental")]
    public class SolicitudSacramental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSolicitudSacramental { get; set; }

        [Required]
        public int IdLaico { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Sacramento")]
        public string Sacramento { get; set; }

        [Display(Name = "Fecha Solicitada")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaSolicitada { get; set; }

        [Display(Name = "Fecha Final")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaFinal { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [StringLength(300)]
        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }

        [ForeignKey("IdLaico")]
        public virtual Laico Laico { get; set; }
    }

    /// <summary>
    /// Modelo SolicitudAyuda
    /// </summary>
    [Table("SolicitudAyuda")]
    public class SolicitudAyuda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSolicitudAyuda { get; set; }

        [Required]
        public int IdLaico { get; set; }

        [Required]
        public int IdParroquia { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Monto Solicitado")]
        public decimal MontoSolicitado { get; set; }

        [StringLength(600)]
        [Display(Name = "Motivo")]
        public string Motivo { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [ForeignKey("IdLaico")]
        public virtual Laico Laico { get; set; }

        [ForeignKey("IdParroquia")]
        public virtual Parroquia Parroquia { get; set; }
    }

    /// <summary>
    /// Modelo LaicoFormacion
    /// </summary>
    [Table("LaicoFormacion")]
    public class LaicoFormacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLaicoFormacion { get; set; }

        [Required]
        public int IdLaico { get; set; }

        [Required]
        public int IdFormacion { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required]
        [Display(Name = "Fecha Inicio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha Fin")]
        [DataType(DataType.Date)]
        public DateTime? FechaFin { get; set; }

        [ForeignKey("IdLaico")]
        public virtual Laico Laico { get; set; }
    }

    /// <summary>
    /// Modelo MiembroCEB
    /// </summary>
    [Table("MiembroCEB")]
    public class MiembroCEB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMiembroCEB { get; set; }

        [Required]
        public int IdLaico { get; set; }

        [Required]
        public int IdCEB { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        [Required]
        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.DateTime)]
        public DateTime FechaIngreso { get; set; }

        [ForeignKey("IdLaico")]
        public virtual Laico Laico { get; set; }
    }

    /// <summary>
    /// Modelo RolSistema
    /// </summary>
    [Table("RolSistema")]
    public class RolSistema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRolSistema { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [StringLength(200)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public virtual ICollection<UsuarioRolSistema> UsuariosRoles { get; set; }
    }

    /// <summary>
    /// Modelo UsuarioRolSistema
    /// </summary>
    [Table("UsuarioRolSistema")]
    public class UsuarioRolSistema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuarioRolSistema { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public int IdRolSistema { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("IdRolSistema")]
        public virtual RolSistema RolSistema { get; set; }
    }
}
