using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI;
using SL.Excepciones;
using SL.Bitacora;

namespace DAL
{
    public class DALCategoriaServicio
    {
        MachiConsultoraVFEntities contexto = new MachiConsultoraVFEntities();

        public CategoriaServicio obtenerServicioPorId(int pIdCategoriaServicio)
        {
            CategoriaServicio oCategoriaServicio = new CategoriaServicio();

            try
            {
                var _catServ = contexto.CategoriaServicio.First(m => m.Id_CategoriaServicio == pIdCategoriaServicio);

                oCategoriaServicio.Id_CategoriaServicio = _catServ.Id_CategoriaServicio;
                oCategoriaServicio.Nombre = _catServ.Nombre;

            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }

            return oCategoriaServicio;
        }
    }
}
