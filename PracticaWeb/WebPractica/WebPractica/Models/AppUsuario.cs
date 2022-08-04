using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPractica.Models
{
    public class AppUsuario:IdentityUser
    {
        public string Documento { get; set; }

        public string Nombre { get; set; }
    }
}
