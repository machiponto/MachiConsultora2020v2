using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI;

namespace BLL
{
    public interface INEGGestionCV
    {
        List<BI.ClsDatosPersonales> obtenerDatosPersonales();
        //   List<CategoriaServicio> obtenerCategoriasDeServicio();
        //List<BI.ClsServicio> obtenerCategoriasDeServiciosFiltrados(int pCategoria);

    }
}
