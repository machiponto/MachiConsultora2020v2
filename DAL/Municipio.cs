//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Municipio
    {
        public Municipio()
        {
            this.LocalidadBarrio = new HashSet<LocalidadBarrio>();
        }
    
        public int Id_Municipio { get; set; }
        public string NombreMunicipio { get; set; }
        public bool Activo { get; set; }
        public int Id_Provincia { get; set; }
    
        public virtual ICollection<LocalidadBarrio> LocalidadBarrio { get; set; }
        public virtual Provincia Provincia { get; set; }
    }
}
