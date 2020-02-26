using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BI
{
    public class CategoriaServicio
    {

        public int idCategoria { get; set; }
        public string nombre { get; set; }

    }
}