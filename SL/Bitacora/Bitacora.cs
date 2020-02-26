using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SL.Bitacora
{
    public class Bitacora
    {

        public int idBitacora { get; set; }
        public string modulo { get; set; }
        public string tipo { get; set; }
        public DateTime fecha { get; set; }
        public string detalle { get; set; }

    }
}
