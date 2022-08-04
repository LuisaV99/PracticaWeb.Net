using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPractica.Models
{
    public class RegistroUsuarios
    {
        [Required(ErrorMessage="Nombre requerido")]
        [Display (Name ="Nombre del usuario")]
        [DataType(DataType.Text)]
        
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Documento requerido")]
        [Display(Name = "No. Documento")]
        [DataType(DataType.Text)]

        public string Documento { get; set; }

        [Required(ErrorMessage = "Email requerido")]

        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(15,ErrorMessage ="La {0} debe estar entre al menos {2} caracteres de longitud",MinimumLength =5)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]

        public string Password { get; set; }

        [Required(ErrorMessage = "La confarmacion de contraseña es requerida")]
        [StringLength(15, ErrorMessage = "La contraseña y la confirmacion no coinciden")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]

        public string ConfirPassword { get; set; }
    }
}
