using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaParroquial.Models
{
    /// <summary>
    /// Modelo que representa un Usuario del sistema
    /// </summary>
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [StringLength(150, ErrorMessage = "El email no puede exceder 150 caracteres")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(255)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña Hash")]
        public string PasswordHash { get; set; }

        [Display(Name = "Laico Asociado")]
        public int? IdLaico { get; set; }

        [Display(Name = "Sacerdote Asociado")]
        public int? IdSacerdote { get; set; }

        // Propiedades calculadas
        [NotMapped]
        [Display(Name = "Tipo de Usuario")]
        public string TipoUsuario
        {
            get
            {
                if (IdSacerdote.HasValue) return "Sacerdote";
                if (IdLaico.HasValue) return "Laico";
                return "Sin asignar";
            }
        }

        // Propiedades de navegación
        [ForeignKey("IdLaico")]
        public virtual Laico Laico { get; set; }

        [ForeignKey("IdSacerdote")]
        public virtual Sacerdote Sacerdote { get; set; }

        public virtual ICollection<UsuarioRolSistema> Roles { get; set; }

        public Usuario()
        {
            Roles = new HashSet<UsuarioRolSistema>();
        }
    }
}
