using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaParroquial.Models
{
    /// <summary>
    /// Modelo que representa un Laico (Layperson) en el sistema
    /// </summary>
    [Table("Laico")]
    public class Laico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLaico { get; set; }

        [Required(ErrorMessage = "Los nombres son obligatorios")]
        [StringLength(150, ErrorMessage = "Los nombres no pueden exceder 150 caracteres")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [StringLength(150, ErrorMessage = "Los apellidos no pueden exceder 150 caracteres")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [StringLength(50, ErrorMessage = "El teléfono no puede exceder 50 caracteres")]
        [Phone(ErrorMessage = "Formato de teléfono inválido")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Capilla")]
        public int? IdCapilla { get; set; }

        [Display(Name = "Estado")]
        public bool Activo { get; set; }

        // Propiedades calculadas
        [Display(Name = "Nombre Completo")]
        [NotMapped]
        public string NombreCompleto => $"{Nombres} {Apellidos}".Trim();

        // Propiedades de navegación
        [ForeignKey("IdCapilla")]
        public virtual Capilla Capilla { get; set; }

        public virtual ICollection<SolicitudSacramental> SolicitudesSacramentales { get; set; }
        public virtual ICollection<SolicitudAyuda> SolicitudesAyuda { get; set; }
        public virtual ICollection<LaicoFormacion> Formaciones { get; set; }
        public virtual ICollection<MiembroCEB> MembresiaCEB { get; set; }

        public Laico()
        {
            Activo = true;
            SolicitudesSacramentales = new HashSet<SolicitudSacramental>();
            SolicitudesAyuda = new HashSet<SolicitudAyuda>();
            Formaciones = new HashSet<LaicoFormacion>();
            MembresiaCEB = new HashSet<MiembroCEB>();
        }
    }
}
