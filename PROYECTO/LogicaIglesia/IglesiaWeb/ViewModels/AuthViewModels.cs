using System.ComponentModel.DataAnnotations;

namespace SistemaParroquial.ViewModels
{
    /// <summary>
    /// ViewModel para el formulario de inicio de sesión
    /// </summary>
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// ViewModel para registro de usuario
    /// </summary>
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Tipo de Usuario")]
        public string TipoUsuario { get; set; } // "Laico" o "Sacerdote"

        [Display(Name = "Laico")]
        public int? IdLaico { get; set; }

        [Display(Name = "Sacerdote")]
        public int? IdSacerdote { get; set; }
    }
}
