using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPractica.Models
{
    public class LoginUsuarios
    {
    [Required(ErrorMessage ="Email requerido")]
    [EmailAddress]

    public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        [Display(Name ="Contraseña")]

        public string Password { get; set; }


        [Display(Name = "¿Recordar datos?")]

        public bool Rememberme { get; set; }
    }
}
