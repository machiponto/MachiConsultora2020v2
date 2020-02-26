using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BI
{
    public class ClsDatosPersonales
    {
    
        //constructor
        public ClsDatosPersonales()
        {
            this.listaDatosPersonales = new List<ClsDatosPersonales>();
        }

        public int Id_DatosPersonales {get; set;}
        public string ApellidoPostulante {get; set;}
        public string ApellidoMaterno {get; set;}
        public string NombrePostulante {get; set;}
        public string Sexo {get; set;}
        public DateTime FechaNacimiento {get; set;}
        public string Direccion {get; set;}
        public string Numero {get; set;}
        public string Piso {get; set;}
        public string Dto {get; set;}
        public string CodPostal {get; set;}
        public string email {get; set;}
        public int CantidadHijos {get; set;}
        public string Observaciones { get; set; }

        public List<ClsDatosPersonales> listaDatosPersonales { get; set; }

    }
}
