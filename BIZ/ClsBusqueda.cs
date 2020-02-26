using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace BI
{
    public class ClsBusqueda
    {
        //constructor
        //public ClsBusqueda()
        //{
        //    this.listabusquedas = new List<ClsBusqueda>();
        //}
        public int Id_Busqueda { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int Id_Puesto { get; set; }
        public string Descripcion { get; set; }
        public string Referencia { get; set; }
        public int activa { get; set; }

        public int idUsuario { get; set; }
        // public List<ClsBusqueda> listabusquedas { get; set; }
    }

}

