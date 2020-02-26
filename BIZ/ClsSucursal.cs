using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BI
{
    public class ClsSucursal
    {

        public int idSucursal { get; set; }

        public string direccion { get; set; }
        public string telefono { get; set; }
        public string fax { get; set; }

        public ClsEmpresa oEmpresa { get; set; }

    }
}
