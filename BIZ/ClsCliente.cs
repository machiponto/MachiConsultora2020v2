using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
    
namespace BI
{
    public class ClsCliente
    {

        //CLIENTE
        public int idCliente { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        [EmailAddress]
        public string mail { get; set; }

        [Required]
        public string direccion { get; set; }

        [Required]
        public string telefono { get; set; }

        public int idUsuario { get; set; }

    }
}

