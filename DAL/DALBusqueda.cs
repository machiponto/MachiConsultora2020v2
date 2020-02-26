using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI;
using SL.Bitacora;
using SL.Excepciones;

namespace DAL
{
    public class DALBusqueda
    {
        MachiConsultoraVFEntities contexto = new MachiConsultoraVFEntities();

        public List<ClsBusqueda> obtenerBusquedas()
        {

            List<ClsBusqueda> listadoBusqueda = new List<ClsBusqueda>();
            ClsBusqueda oBusqueda;

            try
            {

                //CONSULTA TRAIGO TODOS LOS EVENTOS DE LA TABLA BUSQUEDA
                var eventosBusaqueda = from d in contexto.Busqueda
                                      orderby (d.Id_Busqueda) descending
                                      select d;

                IEnumerator<Busqueda> enu = eventosBusaqueda.GetEnumerator();
                while (enu.MoveNext())
                {
                    oBusqueda = new ClsBusqueda();
                    oBusqueda.Id_Busqueda = enu.Current.Id_Busqueda;
                    oBusqueda.FechaPublicacion = enu.Current.FechaPublicacion;
                    oBusqueda.Id_Puesto = enu.Current.Id_Puesto;
                    oBusqueda.Descripcion = enu.Current.Descripcion;
                    oBusqueda.Referencia = enu.Current.Referencia;

                    listadoBusqueda.Add(oBusqueda);
                }
       
        
    }
            catch (Exception ex)
            {

                throw ex;
            }

            return listadoBusqueda;
        }

        public void altaBusqueda(ClsBusqueda oBusqueda)
        {
            Busqueda oTblBusqueda;
            try
            {
                oTblBusqueda = new Busqueda();
                oTblBusqueda.FechaPublicacion = oBusqueda.FechaPublicacion;
                oTblBusqueda.Id_Busqueda = oBusqueda.Id_Busqueda;
                oTblBusqueda.Id_Puesto = oBusqueda.Id_Puesto;
                oTblBusqueda.Descripcion = oBusqueda.Descripcion;
                oTblBusqueda.Referencia = oBusqueda.Referencia;
                oTblBusqueda.Activa = true;

                contexto.Busqueda.Add(oTblBusqueda);
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }
        }


        public List<ClsBusqueda> buscarBusquedas(string pValor)
        {
            List<ClsBusqueda> listadoBusqueda = new List<ClsBusqueda>();
            ClsBusqueda oBusqueda;

            try
            {

                foreach (Busqueda _busqueda in contexto.Busqueda)
                
                {
                    if (_busqueda.Referencia == pValor)
                {
                    oBusqueda = new ClsBusqueda();
                    oBusqueda.Id_Busqueda = _busqueda.Id_Busqueda;
                    oBusqueda.FechaPublicacion = _busqueda.FechaPublicacion;
                    oBusqueda.Id_Puesto = _busqueda.Id_Puesto;
                    oBusqueda.Descripcion = _busqueda.Descripcion;
                    oBusqueda.Referencia = _busqueda.Referencia;

                    listadoBusqueda.Add(oBusqueda);
                }
                }

            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }

            return listadoBusqueda;
        }

        public List<ClsBusqueda> CandidatosporBusqueda(string pValor)
        {
            List<ClsBusqueda> listadoBusqueda = new List<ClsBusqueda>();
            ClsBusqueda oBusqueda;

            try
            {

                foreach (Busqueda _busqueda in contexto.Busqueda)

                {
                    if (_busqueda.Referencia == pValor)
                    {
                        oBusqueda = new ClsBusqueda();
                        oBusqueda.Id_Busqueda = _busqueda.Id_Busqueda;
                        oBusqueda.FechaPublicacion = _busqueda.FechaPublicacion;
                        oBusqueda.Id_Puesto = _busqueda.Id_Puesto;
                        oBusqueda.Descripcion = _busqueda.Descripcion;
                        oBusqueda.Referencia = _busqueda.Referencia;

                        listadoBusqueda.Add(oBusqueda);
                    }
                }

            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }

            return listadoBusqueda;
        }

        public List<ClsBusqueda> buscarPostulantesID(int pValor)
        {
            List<ClsBusqueda> listadoBusqueda = new List<ClsBusqueda>();
            ClsBusqueda oBusqueda;

            try
            {

                foreach (Busqueda _busqueda in contexto.Busqueda)

                {
                    if (_busqueda.Id_Busqueda == pValor)
                    {
                        oBusqueda = new ClsBusqueda();
                        oBusqueda.Id_Busqueda = _busqueda.Id_Busqueda;
                        oBusqueda.FechaPublicacion = _busqueda.FechaPublicacion;
                        oBusqueda.Id_Puesto = _busqueda.Id_Puesto;
                        oBusqueda.Descripcion = _busqueda.Descripcion;
                        oBusqueda.Referencia = _busqueda.Referencia;

                        listadoBusqueda.Add(oBusqueda);
                    }
                }

            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }

            return listadoBusqueda;
        }

        //public List<ClsPostulante> BuscarporID(int pValor)
        //{
        //    List<ClsPostulante> listadoPostilante = new List<ClsPostulante>();
        //    ClsPostulante oPostulante;
        //    try
        //    {
        //        foreach (UsuarioBusqueda _busqueda in contexto.UsuarioBusqueda)

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        
    }
}
