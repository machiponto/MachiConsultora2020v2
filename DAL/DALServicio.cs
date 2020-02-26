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
    public class DALServicio
    {
        MachiConsultoraVFEntities contexto = new MachiConsultoraVFEntities();

        public List<ClsServicio> obtenerServicios()
        {

            List<ClsServicio> listadoServiciosBD = new List<ClsServicio>();
            List<ClsServicio> listadoServiciosTotales = new List<ClsServicio>();
            ClsServicio oServicio;

            try
            {
                //CONSULTA TRAIGO TODOS LOS SERVICIOS
                var items = from d in contexto.Servicio
                            select d;

                IEnumerator<Servicio> enu = items.GetEnumerator();
                while (enu.MoveNext())
                {
                    oServicio = new ClsServicio();
                    oServicio.Id_Servicio = enu.Current.Id_Servicio;
                    oServicio.Nombre = enu.Current.Nombre;
                    oServicio.Descripcion = enu.Current.Descripcion;
                    oServicio.Precio = enu.Current.Precio;
                    oServicio.Imagen = enu.Current.Imagen;
                    oServicio.Activo = enu.Current.Activo;


                    var _prodServ = contexto.CategoriaServicio.First(m => m.Id_CategoriaServicio == enu.Current.Id_CategoriaServicio);
                    oServicio.Id_Servicio = _prodServ.Id_CategoriaServicio;

                    oServicio.Nombre = _prodServ.Nombre;

                    listadoServiciosBD.Add(oServicio);

                }

            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }

            return listadoServiciosBD;

        }

        public List<BI.CategoriaServicio> obtenerCategoriasDeServicio()
        {
            List<BI.CategoriaServicio> listadoCategorias = new List<BI.CategoriaServicio>();
            BI.CategoriaServicio oCategoriaServicio;

            try
            {

                foreach (CategoriaServicio oTblCategoriaServicio in contexto.CategoriaServicio)
                {

                    oCategoriaServicio = new BI.CategoriaServicio();
                    oCategoriaServicio.idCategoria = oTblCategoriaServicio.Id_CategoriaServicio;
                    oCategoriaServicio.nombre = oTblCategoriaServicio.Nombre;
                    listadoCategorias.Add(oCategoriaServicio);
                }
            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }

            return listadoCategorias;
        }

    }
}
