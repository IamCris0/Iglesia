using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaParroquial.Models
{
    /// <summary>
    /// Modelo que representa una Capilla (Chapel) en el sistema
    /// </summary>
    [Table("Capilla")]
    public class Capilla
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCapilla { get; set; }

        [Required(ErrorMessage = "El nombre de la capilla es obligatorio")]
        [StringLength(150, ErrorMessage = "El nombre no puede exceder 150 caracteres")]
        [Display(Name = "Nombre de la Capilla")]
        public string Nombre { get; set; }

        [StringLength(200, ErrorMessage = "La dirección no puede exceder 200 caracteres")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una parroquia")]
        [Display(Name = "Parroquia")]
        public int IdParroquia { get; set; }

        [Display(Name = "Coordinador")]
        public int? IdLaicoCoordinador { get; set; }

        // Propiedades de navegación
        [ForeignKey("IdParroquia")]
        public virtual Parroquia Parroquia { get; set; }

        [ForeignKey("IdLaicoCoordinador")]
        public virtual Laico Coordinador { get; set; }

        public virtual ICollection<Misa> Misas { get; set; }
        public virtual ICollection<EventoCapilla> Eventos { get; set; }
        public virtual ICollection<HorarioMisa> HorariosMisa { get; set; }

        public Capilla()
        {
            Misas = new HashSet<Misa>();
            Eventos = new HashSet<EventoCapilla>();
            HorariosMisa = new HashSet<HorarioMisa>();
        }
    }
}
