using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class PostulanteModel
    {
        //USUARIO

        public int idCliente { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string direccion { get; set; }

        [Required]
        public string telefono { get; set; }

        //USUARIO
        [Required]
        public string usuario { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }


    }
}