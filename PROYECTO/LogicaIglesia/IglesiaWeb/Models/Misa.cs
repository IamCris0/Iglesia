using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaParroquial.Models
{
    /// <summary>
    /// Modelo que representa una Misa (Mass) en el sistema
    /// </summary>
    [Table("Misa")]
    public class Misa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMisa { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una capilla")]
        [Display(Name = "Capilla")]
        public int IdCapilla { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        [Display(Name = "Fecha y Hora")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Monto Recaudado")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, 999999.99, ErrorMessage = "El monto debe ser positivo")]
        public decimal? MontoRecaudado { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Estado { get; set; } // Programada, Realizada, Cancelada

        [Display(Name = "Sacerdote")]
        public int? IdSacerdote { get; set; }

        [Display(Name = "Solicitud Sacramental")]
        public int? IdSolicitudSacramental { get; set; }

        // Propiedades calculadas
        [NotMapped]
        [Display(Name = "Estado de Recaudación")]
        public string EstadoRecaudacion => MontoRecaudado.HasValue && MontoRecaudado.Value > 0 
            ? "Registrado" 
            : "Pendiente";

        // Propiedades de navegación
        [ForeignKey("IdCapilla")]
        public virtual Capilla Capilla { get; set; }

        [ForeignKey("IdSacerdote")]
        public virtual Sacerdote Sacerdote { get; set; }

        [ForeignKey("IdSolicitudSacramental")]
        public virtual SolicitudSacramental SolicitudSacramental { get; set; }

        public Misa()
        {
            Estado = "Programada";
            Fecha = DateTime.Now;
        }
    }

    /// <summary>
    /// Estados posibles para una Misa
    /// </summary>
    public static class EstadoMisa
    {
        public const string Programada = "Programada";
        public const string Realizada = "Realizada";
        public const string Cancelada = "Cancelada";
    }
}
