using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BI
{
    public class ClsServicio
    {
        //constructor
        public ClsServicio()
        {
            this.listaServicios = new List<ClsServicio>();
        }
        public int Id_Servicio { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }


        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }
        public bool Activo { get; set; }

        public List<ClsServicio> listaServicios { get; set; }
    }
}

