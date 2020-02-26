using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BI
{
    public class ClsModulo
    {
           //constructor
        public ClsModulo()
        {
            this.listamodulos = new List<ClsModulo>();
        }
        public int Id_Modulo { get; set; }
        public string moduloDescripcion { get; set; }
        public string fijo { get; set; }
        public bool activo { get; set; }

        public List<ClsModulo> listamodulos { get; set; }
    }

    }
