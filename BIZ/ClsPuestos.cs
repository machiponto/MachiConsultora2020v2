using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BI
{
    public class ClsPuestos
    {
        //constructor
        public ClsPuestos()
        {
            this.listaPuestos = new List<ClsPuestos>();
        }
        public int Id_Puesto { get; set; }
        public string DescripcionPuesto { get; set; }
        public string Activo { get; set; }
                     
        public List<ClsPuestos> listaPuestos { get; set; }
    }
}
