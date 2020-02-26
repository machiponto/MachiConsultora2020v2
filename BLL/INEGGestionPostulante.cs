using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI;

namespace BLL
{
    public interface INEGGestionPostulante
    {
     
        List<ClsBusqueda> obtenerBusquedas();
        List<ClsPuestos> obtenerPuestos();

        List<ClsBusqueda> CandidatosporBusqueda(string pValor);
        List<ClsBusqueda> buscarPostulantesID(int pValor);

        //Busqueda
        //   List<CategoriaServicio> obtenerCategoriasDeServicio();
        //List<BI.ClsServicio> obtenerCategoriasDeServiciosFiltrados(int pCategoria);


    }
}
