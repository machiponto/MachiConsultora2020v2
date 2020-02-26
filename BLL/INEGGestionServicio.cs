using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI;

namespace BLL
{
    public interface INEGGestionServicio
    {
        List<BI.ClsServicio> obtenerServicios();
        List<ClsBusqueda> obtenerBusquedas();
        List<ClsBusqueda> buscarBusquedas(string pValor);
        List<ClsPuestos> obtenerPuestos();

        //Busqueda
        
        void altaBusqueda(ClsBusqueda oBusqueda);
        //   List<CategoriaServicio> obtenerCategoriasDeServicio();
        //List<BI.ClsServicio> obtenerCategoriasDeServiciosFiltrados(int pCategoria);

    }
}
