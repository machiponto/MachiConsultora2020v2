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
    public class DALBitacora
    {

        MachiConsultoraVFEntities contexto = new MachiConsultoraVFEntities();

        public void registrarEvento(SL.Bitacora.Bitacora oBitacora)
        {

            try
            {
                Bitacora oTblBitacora = new Bitacora();

                oTblBitacora.Modulo = oBitacora.modulo;
                oTblBitacora.Tipo = oBitacora.tipo;
                oTblBitacora.Fecha = oBitacora.fecha;
                oTblBitacora.Detalle = oBitacora.detalle;
                contexto.Bitacora.Add(oTblBitacora);

                contexto.SaveChanges();

            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }

        }

        public List<SL.Bitacora.Bitacora> obtenerEventos()
        {

            List<SL.Bitacora.Bitacora> listadoEventos = new List<SL.Bitacora.Bitacora>();
            SL.Bitacora.Bitacora oBitacora;

            try
            {

                //CONSULTA TRAIGO TODOS LOS EVENTOS DE LA TABLA BITACORA
                var eventosBitacora = from d in contexto.Bitacora
                                      orderby (d.idBitacora) descending
                                      select d;

                IEnumerator<Bitacora> enu = eventosBitacora.GetEnumerator();
                while (enu.MoveNext())
                {
                    oBitacora = new SL.Bitacora.Bitacora();
                    oBitacora.idBitacora = enu.Current.idBitacora;
                    oBitacora.modulo = enu.Current.Modulo;
                    oBitacora.tipo = enu.Current.Tipo;
                    oBitacora.fecha = enu.Current.Fecha;
                    oBitacora.detalle = enu.Current.Detalle;

                    listadoEventos.Add(oBitacora);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listadoEventos;
        }

        public List<SL.Bitacora.Bitacora> obtenerEventosFiltrados(string pValor)
        {

            List<SL.Bitacora.Bitacora> listadoEventos = new List<SL.Bitacora.Bitacora>();
            SL.Bitacora.Bitacora oBitacora;
            int pValorNumerico = 0;


            bool bandera = int.TryParse(pValor, out pValorNumerico);

            try
            {

                if (bandera == true)
                {

                    var eventosBitacora = contexto.SPBuscarEventosBitacora(pValorNumerico, pValor, pValor, pValor);

                    IEnumerator<SPBuscarEventosBitacora_Result> enu = eventosBitacora.GetEnumerator();
                    while (enu.MoveNext())
                    {
                        oBitacora = new SL.Bitacora.Bitacora();
                        oBitacora.idBitacora = enu.Current.idBitacora;
                        oBitacora.modulo = enu.Current.Modulo;
                        oBitacora.tipo = enu.Current.Tipo;
                        oBitacora.fecha = enu.Current.Fecha;
                        oBitacora.detalle = enu.Current.Detalle;

                        listadoEventos.Add(oBitacora);
                    }

                }
                else
                {

                    var eventosBitacora = contexto.SPBuscarEventosBitacora(pValorNumerico, pValor, pValor, pValor);

                    IEnumerator<SPBuscarEventosBitacora_Result> enu = eventosBitacora.GetEnumerator();
                    while (enu.MoveNext())
                    {
                        oBitacora = new SL.Bitacora.Bitacora();
                        oBitacora.idBitacora = enu.Current.idBitacora;
                        oBitacora.modulo = enu.Current.Modulo;
                        oBitacora.tipo = enu.Current.Tipo;
                        oBitacora.fecha = enu.Current.Fecha;
                        oBitacora.detalle = enu.Current.Detalle;

                        listadoEventos.Add(oBitacora);
                    }
                }

            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }

            return listadoEventos;
        }


    }
}
