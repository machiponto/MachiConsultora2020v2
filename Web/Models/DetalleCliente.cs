using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class DetalleCliente
    {

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

        //public BI.Empleado oEmpleado { get; set; }

        //public List<BI.Pedido> listadoPedidos { get; set; }
    }
}