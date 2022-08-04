using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPractica.Models
{
    public class Registro
    {
        [Key]
        public int IdRegistro { get; set; }
        [DisplayName("Foto")]
        public Byte[] Imagen { get; set; }
        [DisplayName("Documento")]
        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Dato requerido")]
        public string Documento { get; set; }
        [DisplayName("Nombre")]
        [StringLength(30)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Dato requerido")]
        //[Column(TypeName = "varchar(30)")]
        public string Nombre { get; set; }
        [DisplayName("Apellidos")]
        [StringLength(30)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Dato requerido")]
        public string Apellidos { get; set; }
        [DisplayName("Fecha Nacimiento")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Fecha requerida")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        //[Column(TypeName ="DataTime")]
        public DateTime FechaNac { get; set; }
        [DisplayName("Dirección")]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Dato requerido")]
        public string Direccion { get; set; }
        [DisplayName("Celular")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Dato requerido")]
        public string Celular { get; set; }
        [DisplayName("Género")]
        [StringLength(1)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Dato requerido")]
        public string Genero { get; set; }
        [DisplayName("Deporte")]
        [StringLength(30)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Dato requerido")]
        public string Deporte { get; set; }
        [DisplayName("Trabaja")]
        [StringLength(2)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Dato requerido")]
        public string Trabaja { get; set; }
        [DisplayName("Salario")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Dato requerido")]
        public decimal Sueldo { get; set; }
        [DisplayName("Estado")]
        [StringLength(1)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Dato requerido")]
        public string Estado { get; set; }
    }
}

